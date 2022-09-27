namespace ClothingStore.Application.Contracts.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string message);
    }
}
