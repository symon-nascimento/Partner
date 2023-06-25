using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;
using DotNetEnv;

namespace Partner.Services {
    public class Email {

        public string Provedor { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Email() {
            DotNetEnv.Env.Load();
            DotNetEnv.Env.TraversePath().Load();
            
            Provedor = DotNetEnv.Env.GetString("EMAIL_SMTP");
            Username = DotNetEnv.Env.GetString("EMAIL");
            Password = DotNetEnv.Env.GetString("EMAIL_PASSWORD");
        }

        public void SendEmail(List<string> emailsTo, List<string> attachments) {
            List<string> emailTo = emailsTo;
            string subject = "Nota Fiscal Eletrônica - NFS-e";
            string body = "Olá!\n\nSegue anexo a Nota fiscal.\n\n\nQualquer dúvida, fico a disposição.";
            var message = PrepareteMessage(emailTo, subject, body, attachments);

            SendEmailBySmtp(message);
        }

        private MailMessage PrepareteMessage(List<string> emailTo, string subject, string body, List<string> attachments) {
            var mail = new MailMessage();
            mail.From = new MailAddress(Username);

            foreach (var email in emailTo) {
                if (ValidateEmail(email)) {
                    mail.To.Add(email);
                }
            }

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            foreach (var file in attachments) {
                var data = new Attachment(file, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(file);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(file);

                mail.Attachments.Add(data);
            }
            return mail;
        }

        private bool ValidateEmail(string email) {
            Regex expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            if (expression.IsMatch(email))
                return true;

            return false;
        }

        private void SendEmailBySmtp(MailMessage message) {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Host = Provedor;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 50000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(Username, Password);
            smtpClient.Send(message);
            smtpClient.Dispose();

            Console.WriteLine($"E-mail enviado com sucesso!");
        }

    }
}
