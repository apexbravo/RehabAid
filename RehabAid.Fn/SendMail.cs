using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;

namespace RehabAid.Fn
{
    public static class SendMail
    {
        [FunctionName("SendEmail")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // Read the request body
            string requestBody = new StreamReader(req.Body).ReadToEnd();

            // Parse the request body to get the email address and message
            string emailAddress = null;
            string message = null;
            foreach (string parameter in requestBody.Split('&'))
            {
                string[] parts = parameter.Split('=');
                if (parts.Length != 2)
                {
                    continue;
                }
                string name = parts[0].ToLowerInvariant();
                string value = WebUtility.UrlDecode(parts[1]);

                if (name == "emailaddress")
                {
                    emailAddress = value;
                }
                else if (name == "message")
                {
                    message = value;
                }
            }

            // Validate the email address and message
            if (string.IsNullOrEmpty(emailAddress))
            {
                return new BadRequestObjectResult("Email address is required");
            }
            if (string.IsNullOrEmpty(message))
            {
                return new BadRequestObjectResult("Message is required");
            }

            // Send the email using SMTP
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("abelrevelation@gmil.com", "Laura08!Mugari");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("abelrevelation@gmil.com");
            mailMessage.To.Add(emailAddress);
            mailMessage.Subject = "New Reservation";
            mailMessage.Body = message;
            smtpClient.Send(mailMessage);

            // Return a success response
            return new OkObjectResult("Email sent successfully");
        }
    }
}
