using PruebaTecnica.Application.DTOs.Email;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
