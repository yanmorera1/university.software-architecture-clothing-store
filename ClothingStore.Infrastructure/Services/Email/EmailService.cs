using ClothingStore.Application.Contracts.Services;

namespace ClothingStore.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string to, string message)
        {
            throw new NotImplementedException();
        }
    }
}
