using Domain.Ports;

namespace Infra.Email.Send
{
    public class SendEmailFake : IEmailService
    {
        public void SendEmail(string from, string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
