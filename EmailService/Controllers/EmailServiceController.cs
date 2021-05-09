using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using EmailService.Entities;

namespace EmailService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmailServiceController : ControllerBase
    {
        private readonly EmailTemplate _template = new EmailTemplate();

        [HttpPost]
        public void Post([FromBody] Dictionary<string, string> data)
        {
            string from = "goinggreenemailservice@gmail.com"; //To address
            string to = data["to"]; //From address
            MailMessage message = new MailMessage(from, to);

            string mailbody = _template.confirmRequestMail(float.Parse(data["price"]));
            message.Subject = "GoingGreen";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
            NetworkCredential basicCredential1 = new
            NetworkCredential(from, "GoingGreen123!");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
