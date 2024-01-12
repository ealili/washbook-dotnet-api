namespace washbook_backend.Utilities.Mail;

public interface IMailService
{
    bool SendMail(MailData mailData);
}