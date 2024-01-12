using System.Net.Mail;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace washbook_backend.Utilities.Mail;

public class MailService : IMailService
{
    private readonly MailSettings _mailSettings;

    public MailService(IOptions<MailSettings> mailSettingsOptions)
    {
        _mailSettings = mailSettingsOptions.Value;
    }

    public bool SendMail(MailData mailData)
    {
        try
        {
            using (MimeMessage emailMessage = new MimeMessage())
            {
                MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                emailMessage.From.Add(emailFrom);
                MailboxAddress emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                emailMessage.To.Add(emailTo);

                // emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                // emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

                emailMessage.Subject = mailData.EmailSubject;

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                // emailBodyBuilder.TextBody = mailData.EmailBody;

                // Add HTML content with a button and link
                emailBodyBuilder.HtmlBody = $@"
                        <p>{mailData.EmailBody}</p><br/>
                        <a href='https://www.bs.ch/' style=""padding: 10px; background-color: #007bff; color: #ffffff; text-decoration: none; border-radius: 5px;"">
                            Check out Basel</a>
                    ";

                emailMessage.Body = emailBodyBuilder.ToMessageBody();


                //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                using (SmtpClient mailClient = new SmtpClient())
                {
                    mailClient.Connect(_mailSettings.Server, _mailSettings.Port,
                        MailKit.Security.SecureSocketOptions.StartTls);
                    mailClient.Authenticate(_mailSettings.UserName, _mailSettings.Password);
                    mailClient.Send(emailMessage);
                    mailClient.Disconnect(true);
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            // Exception Details
            return false;
        }
    }
}