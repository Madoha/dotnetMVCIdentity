using dotnetMVCIdentity.Dto;

namespace dotnetMVCIdentity.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
