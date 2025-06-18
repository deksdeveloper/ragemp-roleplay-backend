using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

class Rec_Password : Script
{

    [RemoteEvent("Recovery_Password")]
    public void Recovery_Password(Player Client, string name)
    {


        try
        {

            MySqlConnection connection = new MySqlConnection(Main.myConnectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM users WHERE email='" + name + "' OR socialclubname='" + name + "' OR socialclubname='" + Client.SocialClubName + "'";
            MySqlDataReader reader = command.ExecuteReader();
            string Email = "";
            string password = "";
            string username = "";
            while (reader.Read())
            {
                if (reader.FieldCount <= 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(Client, "~r~Hesap bulunamadı.", true);
                    return;
                }
                Email = reader.GetString("email");
                password = reader.GetString("password");
                username = Client.SocialClubName;
                break;

            }

            if (Email == "0")
            {
                NAPI.Notification.SendNotificationToPlayer(Client, "~r~Kayıtlı bir e-posta adresiniz yok, şifre geri alımı için forumdan talepte bulunun!", true);
                return;
            }
            else if (Email == "")
            {
                NAPI.Notification.SendNotificationToPlayer(Client, "~r~Hesabınız bulunamadı.", true);
                return;
            }
            connection.Close();
            reader.Close();


            OnButtonClick(Email, password, username);

        }
        catch (Exception e)
        {
            NAPI.Util.ConsoleOutput(e.StackTrace);


        }


    }
    private void OnButtonClick(string Email, string password, string username)
    {
        Task.Run(() =>
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpserver = new SmtpClient("smtp.gmail.com");

                smtpserver.UseDefaultCredentials = true;
                mail.From = new MailAddress("supportrpv@gmail.com");
                mail.To.Add(Email);
                mail.Subject = "" + Main.SERVER_NAME + " '" + username + "' Hesap Şifre Kurtarma";


                mail.Body = "Merhaba \n";
                mail.Body += username + ", sayın, \n";
                mail.Body += "Şifre geri alım talebiniz onaylanmıştır.\n";
                mail.Body += "Şifreniz: " + password + "\n";
                mail.Body += "Eğer bu talebi göndermediyseniz, hemen Yönetim ile iletişime geçin.\n";
                mail.Body += "Bu e-posta adresinin kötüye kullanımı ve tüm sonuçlarından siz sorumlusunuz.\n";
                mail.Body += "Şifrenizi veya hesabınızın ismini asla paylaşmayın.\n";
                mail.Body += "Saygılarımızla.";


                mail.Priority = MailPriority.High;

                smtpserver.Port = 587;
                smtpserver.Credentials = new System.Net.NetworkCredential("supportrpv@gmail.com", "şifre");
                smtpserver.EnableSsl = true;

                smtpserver.Send(mail);


            }
            catch (Exception)
            {

            }

        });

    }



}
