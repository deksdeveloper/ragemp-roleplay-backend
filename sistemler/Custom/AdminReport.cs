using GTANetworkAPI;
using System.Collections.Generic;
using System.Linq;

class AdminReport : Script
{
    public class ReportClass
    {
        public int rid;
        public int category;
        public int PlayerID;
        public string PlayerName;
        public int PlayerId;
        public string reporttext;
    }

    public static Dictionary<int, ReportClass> ReportList = new Dictionary<int, ReportClass>();

    public static void OnPlayerDisconnected(Player client)
    {
        if (client.HasData("report_id") && client.GetData<dynamic>("report_id") != -1)
        {
            int reportId = client.GetData<dynamic>("report_id");

            if (!ReportList.TryGetValue(reportId, out ReportClass report))
            {
                client.SetData<dynamic>("report_id", -1);
                client.SetData<dynamic>("Respone_Report", -1);
                return;
            }

            if (client.HasData("Respone_Report") && client.GetData<dynamic>("Respone_Report") != -1)
            {
                Player target = Main.getClientFromId(client, client.GetData<dynamic>("Respone_Report"));
                Main.SendCustomChatMessasge(target, "~y~[Rapor Sistemi] ~r~Birisi bu raporu çözdü ve rapor otomatik olarak kapatıldı.");
            }

            ReportList.Remove(reportId);

            // Tüm çevrimiçi adminlere raporun kaldırıldığını bildir
            foreach (var admin in NAPI.Pools.GetAllPlayers().Where(p => AccountManage.GetPlayerAdmin(p) >= 1))
            {
                Main.SendCustomChatMessasge(admin, $"~y~[Rapor Sistemi] ~r~Oyuncu {AccountManage.GetCharacterName(client)} sunucudan çıktı ve raporu (ID: {reportId}) silindi.");
            }

            client.SetData<dynamic>("report_id", -1);
            client.SetData<dynamic>("Respone_Report", -1);
        }
    }

    [Command("destek", "~y~[!]:~w~ /destek [Destek Mesajı]", GreedyArg = true)]
    public void CMD_Report(Player Client, string message)
    {
        if (Client.GetData<dynamic>("status") == true)
        {
            if (Client.HasData("report_id") && Client.GetData<dynamic>("report_id") != -1)
            {
                Main.DisplayErrorMessage(Client, "error", "Zaten bir destek talebi gönderdiniz, kapatmak için: /destekiptal kullanın!");
                return;
            }
            if (message.Length <= 1)
            {
                Main.DisplayErrorMessage(Client, "error", "Destek talebiniz en az 1 karakter içermelidir!");
                return;
            }
            int admins = 0;
            List<Player> Admins = new List<Player>();
            foreach (var pl in NAPI.Pools.GetAllPlayers())
            {
                if (AccountManage.GetPlayerAdmin(pl) >= 1)
                {
                    Admins.Add(pl);
                    admins++;
                }
            }

            if (admins == 0)
            {
                Main.DisplayErrorMessage(Client, "error", "Şu anda soruları yanıtlayan admin yok.");
                return;
            }

            foreach (var item in Admins)
            {
                Main.DisplayErrorMessage(item, "info", "Yeni bir destek talebi geldi!");
            }

            int reportId = GenerateUniqueReportId();
            int playerid = Main.getIdFromClient(Client);
            NAPI.Util.ConsoleOutput("playerid: " + playerid);
            ReportList.Add(reportId, new ReportClass { rid = reportId, PlayerID = Client.Value, PlayerId = playerid, PlayerName = AccountManage.GetCharacterName(Client), reporttext = message });
            Client.SetData<dynamic>("report_id", reportId);

            Main.DisplayErrorMessage(Client, "success", "Destek talebi oluşturuldu, lütfen sabırla bekleyin! Rapor ID: " + Client.GetData<dynamic>("report_id"));
        }
    }

    private int GenerateUniqueReportId()
    {
        int reportId = 0;
        while (ReportList.ContainsKey(reportId))
        {
            reportId++;
        }
        return reportId;
    }


    [Command("destekiptal")]
    public void Cancel_Report(Player client)
    {
        if (client.GetData<dynamic>("status") == true)
        {
            if (client.HasData("Respone_Report") && client.GetData<dynamic>("Respone_Report") != -1)
            {
                Main.DisplayErrorMessage(client, "error", "Şu anda destek talebini iptal edemezsiniz.");
                return;
            }

            if (client.HasData("report_id") && client.GetData<dynamic>("report_id") == -1)
            {
                Main.DisplayErrorMessage(client, "error", "Aktif destek talebiniz bulunmuyor.");
                return;
            }

            int reportId = client.GetData<dynamic>("report_id");

            if (!ReportList.TryGetValue(reportId, out ReportClass report))
            {
                Main.DisplayErrorMessage(client, "error", "Aktif destek talebiniz bulunmuyor.");
                return;
            }

            Main.DisplayErrorMessage(client, "success", "Başarıyla destek talebini iptal ettiniz.");

            ReportList.Remove(reportId);

            client.SetData<dynamic>("report_id", -1);
            client.SetData<dynamic>("Respone_Report", -1);
        }
    }


    [Command("tal", Alias = "talepler")]
    public void Show_Reports(Player client)
    {
        if (client.GetData<dynamic>("status") == true)
        {
            if (client.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
                return;
            }

            if (AccountManage.GetPlayerAdmin(client) < 1)
            {
                Main.DisplayErrorMessage(client, "error", "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
                return;
            }

            if (ReportList.Count == 0)
            {
                Main.DisplayErrorMessage(client, "error", "Aktif destek talebi bulunmuyor.");
                return;
            }

            client.TriggerEvent("SendReport", ReportList.Values.ToList());

        }
    }


    [RemoteEvent("lpanswer")]
    public void Accept_Report(Player client, int id, string text)
    {
        if (client.GetData<dynamic>("status") == true)
        {
            if (client.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
                return;
            }

            if (AccountManage.GetPlayerAdmin(client) < 1)
            {
                Main.DisplayErrorMessage(client, "error", "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
                return;
            }

            if (!ReportList.TryGetValue(id, out ReportClass report))
            {
                Main.DisplayErrorMessage(client, "error", "Geçersiz talep numarası!");
                return;
            }

            Player target = Main.getClientFromId(client, report.PlayerID);

            if (target != null)
            {
                Main.SendCustomChatMessasge(target, "~y~[Destek Talebi] " + AccountManage.GetCharacterName(client) + ": " + text + "");
                Main.SendCustomChatMessasge(target, "~y~[Destek Talebi] Destek talebiniz kapatıldı.");
                ReportList.Remove(id);
                target.SetData<dynamic>("report_id", -1);
                target.SetData<dynamic>("Respone_Report", -1);
                client.TriggerEvent("SendReport", ReportList.Values.ToList());
            }
        }
    }

    [RemoteEvent("dreport")]
    public void Close_Report(Player client, int id)
    {
        if (client.GetData<dynamic>("status") == true)
        {
            if (client.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
                return;
            }

            if (AccountManage.GetPlayerAdmin(client) < 1)
            {
                Main.DisplayErrorMessage(client, "error", "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
                return;
            }

            if (!ReportList.TryGetValue(id, out ReportClass report))
            {
                Main.DisplayErrorMessage(client, "error", "Hatalı talep numarası!");
                return;
            }

            if (AccountManage.GetPlayerAdmin(client) < 1)
            {
                if (ReportList[id].category != 1)
                {
                    Main.DisplayErrorMessage(client, "error", "Hatalı talep numarası!");
                    return;
                }
            }

            Player target = Main.getClientFromId(client, ReportList[id].PlayerID);

            Main.SendCustomChatMessasge(client, "~y~[Destek Talebi] " + id + " ID'li talep kapatıldı.");


            ReportList.Remove(id);

            client.SetData<dynamic>("report_id", -1);
            client.SetData<dynamic>("Respone_Report", -1);

        }
    }

    public void Close_Report_Response(Player client)
    {
        if (client.GetData<dynamic>("status") == true)
        {
            if (client.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
                return;
            }

            if (AccountManage.GetPlayerAdmin(client) < 1)
            {
                Main.DisplayErrorMessage(client, "error", "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
                return;
            }

            if (client.HasData("report_id") && client.GetData<dynamic>("report_id") == -1)
            {
                Main.DisplayErrorMessage(client, "error", "Hatalı talep numarası!");
                return;
            }

            if (client.HasData("Respone_Report") && client.GetData<dynamic>("Respone_Report") == -1)
            {
                Main.DisplayErrorMessage(client, "error", "Hatalı talep numarası!");
                return;
            }

            Player target = Main.getClientFromId(client, client.GetData<dynamic>("Respone_Report"));

            if (target != null)
            {
                Main.SendCustomChatMessasge(target, "~y~[Destek Talebi] Destek talebiniz ~r~kapatıldı~y~.");
                target.SetData<dynamic>("report_id", -1);
                target.SetData<dynamic>("Respone_Report", -1);
            }

            Main.SendCustomChatMessasge(client, "~y~[Destek Talebi] " + client.GetData<dynamic>("report_id") + " ID'li talep kapatıldı.");
            client.SetData<dynamic>("report_id", -1);
            client.SetData<dynamic>("Respone_Report", -1);
        }
    }


}
