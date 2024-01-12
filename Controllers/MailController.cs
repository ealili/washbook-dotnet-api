using Microsoft.AspNetCore.Mvc;
using washbook_backend.Utilities.Mail;

namespace washbook_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MailController : ControllerBase
{
    private readonly IMailService _mailService;
    //injecting the IMailService into the constructor
    public MailController(IMailService mailService)
    {
        _mailService = mailService;
    }

    [HttpPost]
    public bool SendMail(MailData mailData)
    {
        return _mailService.SendMail(mailData);
    }
}