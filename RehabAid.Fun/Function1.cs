using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace RehabAid.Fun
{
    public static class Function1
    {
        [FunctionName("SendEmail")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string json = await req.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            string email = obj.Email;

            // Validate email input
            if (string.IsNullOrEmpty(email))
            {
                return new BadRequestObjectResult("Please provide a valid email address.");
            }

            // Configure SendGrid client
            
            var client = new SendGridClient("");

            // Compose email message
            var from = new EmailAddress("amugari@wcyber.net", "Abel Mugari");
            var to = new EmailAddress(email, "Stranger");
            var subject = "Subject of the email";
            var plainTextContent = "This is the plain text content of the email.";
            var htmlContent = "<p>This is the HTML content of the email.</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            // Send email
             var response = await client.SendEmailAsync(msg);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                return new OkObjectResult("Email sent successfully.");
            }
            else
            {
                return new BadRequestObjectResult($"Failed to send email: {response.StatusCode}");
            }
        }

            
        
    }
}
