using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OrganizationMaster.Data;
using OrganizationMaster.Models;

namespace OrganizationMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailServices _emailServices;

        public EmailController(IEmailServices emailServices)
        {
           _emailServices = emailServices;
        }


        [HttpPost]

        public IActionResult SendEmail(Emaildto request, List<IFormFile> attachments)
        {
            _emailServices.SendEmail(request , attachments);

            return Ok("Email Successfully sent to Ethereal Mailbox");



        }

    }
}
