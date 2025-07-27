using MailKit.Net.Smtp;
using MimeKit;

namespace ProjetoAspNet.Service {
    public class SendCodeInEmailService {

        private string Subject { get; set; }
        private string Body { get; set; }
        public string Email { get; set; }
        public int Code { get; set; }

        public SendCodeInEmailService(string email, int code) {
            Email = email;
            Code = code;
            Subject = "Código de Verificação";
            Body = $"<p>{Code}</p>";
        }

        EmailService _settings = new EmailService(
            "smtp.gmail.com",//Server
            587,//Port
            "limsjones8@gmail.com",//User/Email
            "jftq aawk arsq hzfq"//Password
            );

        public async Task SendEmailAsync() {
            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(_settings.Username));
            message.To.Add(MailboxAddress.Parse(Email));
            message.Subject = Subject;
            message.Body = new TextPart("html") { Text = Body };

            try {
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_settings.Server, _settings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_settings.Username, _settings.Password);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

            } catch (Exception ex) {
                throw new InvalidOperationException("O erro foi o seguinte: " + ex.Message);
            }
        }

    }
}
