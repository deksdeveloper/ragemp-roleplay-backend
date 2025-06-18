

using GTANetworkAPI;
using Infinity.Logger;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Discord;
using Discord.WebSocket;

internal class DiscordIntegration : Script
{

    static DiscordSocketClient discord = null;
    private static string m_strToken = null;
    public static event Action OnBotReady;
    private static string m_strBotGameName = null;
    private static ActivityType m_eActivityType = ActivityType.Playing;
    private static UserStatus m_eUsterStatus = UserStatus.Online;


    public static string botToken = "bot_token";
    public static ulong integrationChannelID = 1381743977073479731;
    public static string userStatusText = "L.S Noire";

    public static void SetUpBotInstance(string strToken, string strBotGameName = null, ActivityType eActivityType = ActivityType.CustomStatus, UserStatus eUserStatus = UserStatus.Online)
    {
        if (!IsSetupCompleted)
        {
            m_strToken = strToken;
            m_strBotGameName = strBotGameName;
            m_eActivityType = eActivityType;
            m_eUsterStatus = eUserStatus;

            InitAsync();
            IsSetupCompleted = true;
        }
        else
        {
            ThrowErrorMessage("Yalnızca bir adet bot çalıştırabilirsiniz.");
        }
    }

    private static async void InitAsync()
    {
        if (!string.IsNullOrEmpty(m_strToken))
        {
            discord = new DiscordSocketClient();

            discord.Ready += () =>
            {
                OnBotReady?.Invoke();
                return Task.CompletedTask;
            };

            discord.MessageReceived += OnMessageReceived;

            await discord.LoginAsync(TokenType.Bot, m_strToken).ConfigureAwait(true);
            await discord.StartAsync().ConfigureAwait(true);
        }
        else
        {
            ThrowErrorMessage("Bot yapılandırması tamamlanmamış, bot çalıştırılamadı.");
        }
    }


    private static Task OnMessageReceived(SocketMessage message)
    {
        if (IsSetupCompleted)
        {
            NAPI.Task.Run(() =>
            {
                try
                {
                    if (message.Channel.Id == integrationChannelID)
                    {
                        if (message.Content.Length > 0)
                        {
                            if (!message.Author.IsBot)
                            {
                                DiscordIntegration.GetChatMessage(message.Author.Username, message.Author.Id, message.Content, message.Id);
                            }
                        }
                    }
                }
                catch
                {

                }
            });

            Task task = Task.Run(() => { });
            return task;
        }
        return null;
    }

    public static async Task DeleteMessageAsync(ulong channelId, ulong messageId)
    {
        try
        {
            var channel = discord.GetChannel(channelId) as IMessageChannel;
            if (channel == null)
            {
                return;
            }

            var message = await channel.GetMessageAsync(messageId);
            if (message == null)
            {
                return;
            }

            await message.DeleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Mesaj silinirken hata oluştu: {ex.Message}");
        }
    }

    public static async Task SendMessage(ulong discordChannelID, string strMessage, bool bStripMentions = true, ulong messageReference = 0, bool success = true, string name = "")
    {
        if (IsSetupCompleted)
        {
            try
            {
                ISocketMessageChannel channel = (ISocketMessageChannel)discord.GetChannel(discordChannelID);

                if (channel != null)
                {
                    string content = bStripMentions ? CleanFromTags(strMessage) : strMessage;

                    var embed = new EmbedBuilder()
                       .WithTitle(name)
                       .WithDescription(content)
                       .WithFooter(footer => footer.Text = "Discord Doğrulama")
                       .WithColor(success ? Discord.Color.Green : Discord.Color.Red)
                       .Build();

                    MessageReference reference = null;
                    if (messageReference != 0)
                    {
                        reference = new MessageReference(messageReference);
                    }

                    var sentMessage = await channel.SendMessageAsync(embed: embed, messageReference: reference).ConfigureAwait(false);
                    await Task.Delay(5000);
                    await DeleteMessageAsync(discordChannelID, sentMessage.Id);
                }
                else
                {
                    ThrowErrorMessage("Discord kanal ID bulunamadı.");
                    return;
                }
            }
            catch (Exception ex)
            {
                ThrowErrorMessage("SendMessage fonksiyonunda hata oluştu: " + ex.Message);
            }
        }
    }

    public static async Task UpdateStatus(string strBotGameName, ActivityType eActivityType, UserStatus eUserStatus)
    {
        m_strBotGameName = strBotGameName;
        m_eActivityType = eActivityType;
        m_eUsterStatus = eUserStatus;

        Game game = new Game(m_strBotGameName, m_eActivityType);
        await discord.SetStatusAsync(m_eUsterStatus).ConfigureAwait(true);
        await discord.SetActivityAsync(game).ConfigureAwait(true);
    }

    public static bool RegisterChannelForListenting(ulong channelID)
    {
        if (g_lstSubscribedChannels.Contains(channelID))
        {
            ThrowErrorMessage("Kanal zaten dinlendiği için tekrardan listeye eklenemedi.");
            return false;
        }

        ISocketMessageChannel channel = (ISocketMessageChannel)discord.GetChannel(channelID);
        if (channel != null)
        {
            g_lstSubscribedChannels.Add(channelID);
            return true;
        }
        else
        {
            ThrowErrorMessage("Kanal düzgün şekilde ayarlanmamış.");
        }

        return false;
    }

    public static bool RemoveChannelFromListening(ulong channelID)
    {
        if (g_lstSubscribedChannels.Contains(channelID))
        {
            g_lstSubscribedChannels.Remove(channelID);
            return true;
        }
        return false;
    }

    private static string CleanFromTags(string strInput)
    {
        return strInput.Replace("@", "@‎‏‏‎ ‎");
    }

    private static void ThrowErrorMessage(string StrErrorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(StrErrorMessage);
        Console.ResetColor();
    }


    public static bool IsSetupCompleted { get; private set; } = false;
    private static List<ulong> g_lstSubscribedChannels = new List<ulong>();

    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        SetUpBotInstance(botToken, "L.S Noire", Discord.ActivityType.Playing, Discord.UserStatus.DoNotDisturb);

        OnBotReady += async () =>
        {
            bool bSuccess = RegisterChannelForListenting(1381743977073479731);
            await UpdateStatus(userStatusText, ActivityType.Playing, UserStatus.DoNotDisturb).ConfigureAwait(false);
        };
    }

    public static bool useRegex(String input)
    {
        Regex regex = new Regex(@"^LSN-\d{7}$");
        return regex.IsMatch(input);
    }

    [Command("discord")]
    public static void DiscordCommand(Player player)
    {
        if (player.GetData<string>("DiscordID") != "Yok")
        {
            Main.SendErrorMessage(player, "Zaten Discord hesabınızla oyun hesabınızı eşleştirmişsiniz!");
            return;
        }
        Random rnd = new Random();
        int code = rnd.Next(1111111, 9999999);
        string formattedCode = "LSN-" + code;
        player.SetData("DiscordCode", formattedCode);
        Main.SendInfoMessage(player, "Doğrulama kodunuz: " + formattedCode);
    }

    public static async void GetChatMessage(string username, ulong userid, string message, ulong messageid)
    {
        var players = NAPI.Pools.GetAllPlayers();
        int count = 0;
        foreach (var player in players)
        {
            if (NAPI.Player.IsPlayerConnected(player))
            {
                if (!string.IsNullOrEmpty(message))
                {
                    if (useRegex(message))
                    {
                        if (player.GetData<string>("DiscordCode") == message)
                        {
                            count++;
                            player.SetData("DiscordUsername", username);
                            player.SetData("DiscordID", userid.ToString());
                            Main.SendSuccessMessage(player, "Discord hesabınızı başarıyla oyun hesabınızla eşleştirdiniz!");
                            Main.SendSuccessMessage(player, "----------------------------------");
                            Main.SendSuccessMessage(player, "Discord hesap bilgilerin:");
                            Main.SendSuccessMessage(player, "Kullanıcı Adı: " + username + " ID: " + userid);
                            Main.SendSuccessMessage(player, "----------------------------------");

                            string strFormatted = $"Oyun içi hesabınız Discord hesabınızla başarıyla eşleştirildi!";
                            AccountManage.SaveDiscordInfo(player);
                            await SendMessage(integrationChannelID, strFormatted, true, messageid, true, player.Name).ConfigureAwait(true);
                            await DeleteMessageAsync(integrationChannelID, messageid);
                            break;
                        }
                    }
                }
            }
        }

        if (count <= 0)
        {
            if (useRegex(message))
            {
                string strFormatted = $"Geçersiz kod girişi yaptınız!";
                await SendMessage(integrationChannelID, strFormatted, true, messageid, false, "HATA!").ConfigureAwait(true);
            }

            await DeleteMessageAsync(integrationChannelID, messageid);
        }
    }

}
