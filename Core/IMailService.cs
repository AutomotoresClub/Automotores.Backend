namespace Automotores.Backend.Core
{
    public interface IMailService
    {
        void SendEmail(string receiverAddress, string subject, string htmlBody, string textBody);
    }
}