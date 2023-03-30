using SolidProductApi.Models;

namespace SolidProductApi.Services.ProductServices
{
    public interface IKeyboardService
    {
        Task<ServiceResponse<List<Keyboard>>> GetKeyboardAsync();
        Task<ServiceResponse<Keyboard>> GetKeyboardAsync(Guid id);
        Task<ServiceResponse<Keyboard>> AddKeyboardAsync(Keyboard keyboard);
        Task<ServiceResponse<Keyboard>> EditKeyboardAsync(Keyboard keyboard);
        Task<ServiceResponse<Keyboard>> DeleteKeyboardAsync(Guid id);
    }
}
