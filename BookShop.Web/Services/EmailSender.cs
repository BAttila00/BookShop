using BookShop.Web.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Ati: Itt implementáljuk a IEmailSender interface-t (ami a Register.cshtml.cs-ben hívódik pl)
//A Startup.cs-ben fgojuk ezen osztályt hozzákapcsolni az IEmailSender interfészhez, ezzel:
//services.AddTransient<IEmailSender, Services.EmailSender>(); 


//Itt lesz a  tényleges emailküldés.
namespace BookShop.Web.Services {
    public class EmailSender : IEmailSender {

        private readonly MailSettings mailSettings;
        public EmailSender(IOptions<MailSettings> mailSettings) {           //Ati: Ez IOptions nélkül nem működik? Kipróbálni az alsót!
            this.mailSettings = mailSettings.Value;
        }
        //public EmailSender(MailSettings mailSettings) {
        //    this.mailSettings = mailSettings;
        //}

        //Register.cshtml.cs-ben hívódik pl
        public async Task SendEmailAsync(string email, string subject, string htmlMessage) {        //email param: az  emailcím amire küldünk
            var emailMessage = new MimeMessage {
                Sender = MailboxAddress.Parse(mailSettings.Mail),                                   //Az email cím amiröl küldünk
                Subject = subject
            };

            emailMessage.To.Add(MailboxAddress.Parse(email));

            var builder = new BodyBuilder { HtmlBody = htmlMessage };       //Ati: Ezzel tudnánk pl attachment-et (meg sok mást) hozzáadni az email-hez

            emailMessage.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient()) {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls /*Ez azt mondja h HTTPS-el menjen*/);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);

                await smtp.SendAsync(emailMessage);

                smtp.Disconnect(true);
            }
        }
    }
}
