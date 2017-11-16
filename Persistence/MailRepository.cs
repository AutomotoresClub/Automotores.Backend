using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Automotores.Backend.Core;

namespace Automotores.Backend.Persistence
{
    public class MailRepository : IMailRepository
    {

        private readonly IAmazonSimpleEmailService simpleEmailService;

        static readonly string senderAddress = "noreply@automotoresclub.com";

        static readonly string receiverAddress = "alejandro.garay94@gmail.com";

        static readonly string configSet = "ConfigSet";

        static readonly string subject = "Amazon SES test (AWS SDK for .NET)";

        static readonly string textBody = "Amazon SES Test (.NET)\r\n"
                                        + "This email was sent through Amazon SES "
                                        + "using the AWS SDK for .NET.";
        static readonly string htmlBody = @"<html>
<head></head>
<body>
  <h1>Amazon SES Test (AWS SDK for .NET)</h1>
  <p>This email was sent with
    <a href='https://aws.amazon.com/ses/'>Amazon SES</a> using the
    <a href='https://aws.amazon.com/sdk-for-net/'>
      AWS SDK for .NET</a>.</p>
</body>
</html>";
        private readonly IErrorReporter reporter;

        public MailRepository(IErrorReporter reporter)
        {
            this.reporter = reporter;
            this.simpleEmailService = new AmazonSimpleEmailServiceClient(RegionEndpoint.USWest2);
        }

        public async Task<bool> SendEmail()
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
                var response = await simpleEmailService.SendEmailAsync(sendRequest);
                return true;
            }
            catch (Exception ex)
            {
                await reporter.CaptureAsync(ex);
                return false;
            }
        }
    }
}