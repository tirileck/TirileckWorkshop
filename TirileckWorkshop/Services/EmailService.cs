using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace TirileckWorkshop.Services;

public class EmailConfig
{
    public string SmtpAdress { get; set; }
    public int SmptPort { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}

public class EmailService
{
    private readonly EmailConfig _config;
    
    public EmailService(EmailConfig config)
    {
        _config = config;
    }
    
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        using var emailMessage = new MimeMessage();
 
        emailMessage.From.Add(new MailboxAddress("Администрация сайта MagicCompany", "tirilecki@yandex.ru"));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = message,
        };
             
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_config.SmtpAdress, _config.SmptPort, true);
            await client.AuthenticateAsync(_config.Login, _config.Password);
            await client.SendAsync(emailMessage);
 
            await client.DisconnectAsync(true);
        }
    }
}