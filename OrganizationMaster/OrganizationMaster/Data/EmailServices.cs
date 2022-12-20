
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Asn1.Ocsp;
using OrganizationMaster.Models;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace OrganizationMaster.Data
{
    public class EmailServices : IEmailServices
    {
        private readonly  IConfiguration _config;
        private readonly IWebHostEnvironment _environment;

        public EmailServices(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _config = configuration;
            _environment = webHostEnvironment;

        }


        public void SendEmail(Emaildto request, IFormFile[] attachments)
        {



            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };




            //BodyBuilder bodyBuilder = new BodyBuilder();
            //bodyBuilder.HtmlBody = "<h1>Hello World..!!</h1>";
            //bodyBuilder.TextBody = "Hello World";
            //bodyBuilder.Attachments.Add(request.Attachment.FileName + "\\Upload");
            //email.Attachments = new TextPart(TextFormat.Html) { Text = request.Body };
            //bodyBuilder.Attachments.Add(_config.WebRootPath + "\\file.png");
            //bodyBuilder.Attachments.Add(env.WebRootPath + "\\file.png");

            //if (request.Attachment != null && request.Attachment.Length > 0)
            //{

            ////if(attachments != null)
            ////{
            ////    foreach(var files in attachments)
            ////    {
            ////        email.Attachments.Add(new Attachment(attachments));
            ////    }
            ////}

            List<string> filenames = null;
            filenames = new List<string>();
            if (attachments != null && attachments.Length > 0)
            {
                filenames = new List<string>();
                foreach (IFormFile formFile in attachments)
                {
                    var path = Path.Combine(_environment.WebRootPath, "Upload", formFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        formFile.CopyToAsync(stream);
                    }
                    filenames.Add(path);
                }
            }


            //if (request.Attachment != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in request.Attachment)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }
            //            request.Attachment.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}

            //if (request.Attachment.Length > 0)
            //{
            //    try
            //    {
            //        if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\")) ;
            //        {
            //            Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
            //        }
            //        using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\" + request.Attachment.FileName)) ;
            //        {
            //            Stream filestream = null;
            //            request.Attachment.CopyTo(filestream);
            //            filestream.Flush();
            //            return "\\Images\\" + request.Attachment.FileName;
            //        }

            //    }


            //    catch (Exception ex)
            //    {

                //        return ex.ToString();
                //    }
                //}
                //else
                //{
                //    return "Upload Failed";
                //}

                //if (request.Attachment.Length > 0)
                //{
                //    string filename = Path.GetFileName(request.Attachment.FileName);
                //    email.Attachments.Add(new Attachment(request.Attachment.OpenReadStream(), filename);
                //}

                //email.Attachments.Add(MailboxAddress.Parse(request.Attachment.FileName));
                //if (request.Attachment.Length > 0)
                //{
                //    string fileName = Path.GetFileName(request.Attachment.FileName);
                //    email.Attachments.Add(new request.Attachment(request.Attachment.OpenReadStream(), fileName));

                //}
                //TextBoxFor(model => model.Attachment, new { type = "file" }
                //email.Attachments = new TextPart(TextFormat.Plain) { type = request.Body };



            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }

      
    }
}
