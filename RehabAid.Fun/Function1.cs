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
using RehabAid.Lib;
using System;

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
            string rehabCenterName = obj.Facility;
            int messageType = (int) obj.MessageType;

            // Validate email input
            if (string.IsNullOrEmpty(email))
            {
                return new BadRequestObjectResult("Please provide a valid email address.");
            }

            // Configure SendGrid client
             
            var client = new SendGridClient("");

            // Compose email message
            var from = new EmailAddress("amugari@wcyber.net", rehabCenterName);
            var to = new EmailAddress(email, "Stranger");
            var subject = "Confirmation of Application Received for Rehabilitation Services at " + rehabCenterName;
            string plainTextContent = "Demo";
            string htmlContent= "Sra";

            switch (messageType)
            {
                case (int)EmailType.Accept:
                    plainTextContent = "Dear Client,\n\n" +
               "We are delighted to inform you that your reservation at " + rehabCenterName + " has been accepted.\n\n" +
               
               "- Date: " + DateTime.UtcNow.ToString("MM/dd/yyyy") + "\n" +
          
               "We are excited to have you join us on the scheduled date. Our dedicated team is committed to providing you with the best care and support throughout your rehabilitation journey.\n\n" +
               "Should you have any questions or require any additional information, please do not hesitate to reach out to us. We are here to assist you and ensure that your experience at " + rehabCenterName + " is comfortable and beneficial.\n\n" +
               "Thank you for choosing " + rehabCenterName + ". We look forward to seeing you soon!\n\n" +
               "Best regards,\n" +
               "Your Name\n" +
               rehabCenterName;

                    htmlContent = "<p>Dear Client,</p>" +
                        "<p>We are delighted to inform you that your reservation at " + rehabCenterName + " has been accepted.</p>" +
                        
                       
                        "<li><strong>Date:</strong> " + DateTime.Today.ToString("MM/dd/yyyy") + "</li>" +
                   
                        "</ul>" +
                        "<p>We are excited to have you join us on the scheduled date. Our dedicated team is committed to providing you with the best care and support throughout your rehabilitation journey.</p>" +
                        "<p>Should you have any questions or require any additional information, please do not hesitate to reach out to us. We are here to assist you and ensure that your experience at " + rehabCenterName + " is comfortable and beneficial.</p>" +
                        "<p>Thank you for choosing " + rehabCenterName + ". We look forward to seeing you soon!</p>" +
                        "<p>Best regards,</p>" +
                        "<p>Your Name<br>" +
                        rehabCenterName + "</p>";
                    break;

                case (int)EmailType.Reject:
                    plainTextContent = "Dear Client,\n\n" +
     "We are sorry to inform you that your reservation at " + rehabCenterName + " has been rejected.\n\n" +
     "We understand that this may come as disappointing news, and we apologize for any inconvenience caused. Our team carefully considered your needs and the availability of resources to ensure the best care for all our clients. Unfortunately, we are unable to accommodate your reservation at this time.\n\n" +
     "If you have any questions or would like to discuss alternative options, please do not hesitate to reach out to us. We are here to support you in your rehabilitation journey and will do our best to assist you.\n\n" +
     "Thank you for considering " + rehabCenterName + " for your rehabilitation needs. We appreciate your understanding and hope to have the opportunity to serve you in the future.\n\n" +
     "Best regards,\n" +
     "Your Name\n" +
     rehabCenterName;

                    htmlContent = "<p>Dear Client,</p>" +
                        "<p>We are sorry to inform you that your reservation at " + rehabCenterName + " has been rejected.</p>" +
          
                        "<p>We understand that this may come as disappointing news, and we apologize for any inconvenience caused. Our team carefully considered your needs and the availability of resources to ensure the best care for all our clients. Unfortunately, we are unable to accommodate your reservation at this time.</p>" +
                        "<p>If you have any questions or would like to discuss alternative options, please do not hesitate to reach out to us. We are here to support you in your rehabilitation journey and will do our best to assist you.</p>" +
                        "<p>Thank you for considering " + rehabCenterName + " for your rehabilitation needs. We appreciate your understanding and hope to have the opportunity to serve you in the future.</p>" +
                        "<p>Best regards,</p>" +
                        "<p>Your Name<br>" +
                        rehabCenterName + "</p>";
                    break;

                case (int)EmailType.Acknow:
                    plainTextContent = "Dear Client ,\n\n" +
                   "I hope this email finds you well. I am writing to inform you that we have received your application for rehabilitation services at " + rehabCenterName + ".\n\n" +
                   "We are pleased to receive your application, and our team is currently reviewing it to ensure that we understand your unique needs and requirements. Our goal is to provide you with the best possible care, and we are committed to making sure that we are the right fit for you.\n\n" +
                   "Please know that we take our responsibility to our clients very seriously, and we are committed to maintaining the highest standards of care and professionalism. We understand that seeking help can be difficult, and we are here to support you every step of the way.\n\n" +
                   "We will be in touch with you soon to discuss your application in more detail and to answer any questions that you may have. In the meantime, please do not hesitate to contact us if you have any further concerns.\n\n" +
                   "Thank you for considering " + rehabCenterName + " for your rehabilitation needs. We look forward to speaking with you soon.\n\n" +
                   "Best regards,\n\n" +
                   "Your Name\n" +
                   rehabCenterName; 
                    htmlContent = "<p>Dear Client,</p>" +
                              "<p>I hope this email finds you well. I am writing to inform you that we have received your application for rehabilitation services at " + rehabCenterName + ".</p>" +
                              "<p>We are pleased to receive your application, and our team is currently reviewing it to ensure that we understand your unique needs and requirements. Our goal is to provide you with the best possible care, and we are committed to making sure that we are the right fit for you.</p>" +
                              "<p>Please know that we take our responsibility to our clients very seriously, and we are committed to maintaining the highest standards of care and professionalism. We understand that seeking help can be difficult, and we are here to support you every step of the way.</p>" +
                              "<p>We will be in touch with you soon to discuss your application in more detail and to answer any questions that you may have. In the meantime, please do not hesitate to contact us if you have any further concerns.</p>" +
                              "<p>Thank you for considering " + rehabCenterName + " for your rehabilitation needs. We look forward to speaking with you soon.</p>" +
                              "<p>Best regards,</p>" +
                              "<p>Your Name<br>" +
                              rehabCenterName + "</p>";
                    break;
            }

                   
           
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
