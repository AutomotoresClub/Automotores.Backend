using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Automotores.Backend.Core.Services
{
    public class MailService : IMailService
    {
        static readonly string senderAddress = "noreply@automotoresclub.com";
        private readonly IAmazonSimpleEmailService simpleEmailService;
        private readonly IErrorReporter reporter;

        public MailService(IErrorReporter reporter)
        {
            this.reporter = reporter;
            this.simpleEmailService = new AmazonSimpleEmailServiceClient(RegionEndpoint.USWest2);
        }

        public async void SendEmail(string receiverAddress, string subject, string htmlBody, string textBody)
        {
            var sendRequest = new SendEmailRequest
            {
                Source = senderAddress,
                Destination = new Destination
                {
                    ToAddresses =
                    new List<string> { receiverAddress }
                },
                Message = new Message
                {
                    Subject = new Content(subject),
                    Body = new Body
                    {
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = htmlBody
                        },
                        Text = new Content
                        {
                            Charset = "UTF-8",
                            Data = textBody
                        }
                    }
                }
            };
            try
            {
                await simpleEmailService.SendEmailAsync(sendRequest);
            }
            catch (AmazonSimpleEmailServiceException amazonSimpleEmailServiceException)
            {
                await reporter.CaptureAsync(amazonSimpleEmailServiceException);
            }
        }
    }
}
