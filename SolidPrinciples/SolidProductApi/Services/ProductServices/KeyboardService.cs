using Microsoft.EntityFrameworkCore;
using SolidProductApi.Models;
using SolidProductApi.Services.ProductServices;

namespace SolidProductApi.Services.ProductServices
{
    public class KeyboardService : ProductService, IKeyboardService
    {
        private readonly DataContext _context;

        public KeyboardService(DataContext DataContext) : base(DataContext)
        {
            _context = DataContext;
        }

        public async Task<ServiceResponse<List<Keyboard>>> GetKeyboardAsync()
        {
            var serviceResponse = new ServiceResponse<List<Keyboard>>();

            var keyboards = await _context.Keyboards.ToListAsync();
            serviceResponse.Data = keyboards;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Keyboard>> AddKeyboardAsync(Keyboard keyboard)
        {
            var response = new ServiceResponse<Keyboard>();

            keyboard.Id = Guid.NewGuid();

            await _context.Keyboards.AddAsync(keyboard);
            await _context.SaveChangesAsync();

            response.Data = keyboard;

            return response;
        }

        public async Task<ServiceResponse<Keyboard>> GetKeyboardAsync(Guid id)
        {
            var response = new ServiceResponse<Keyboard>();

            var keyboard = await _context.Keyboards.FirstOrDefaultAsync(p => p.Id == id);

            response.Data = keyboard;

            return response;
        }

        public async Task<ServiceResponse<Keyboard>> EditKeyboardAsync(Keyboard keyboard)
        {
            var response = new ServiceResponse<Keyboard>();

            var keyboardToUpdate = await _context.Keyboards.FirstOrDefaultAsync(p => p.Id == keyboard.Id);

            keyboardToUpdate.Title = keyboard.Title;
            keyboardToUpdate.Description = keyboard.Description;
            keyboardToUpdate.Price = keyboard.Price;
            keyboardToUpdate.Type = keyboard.Type;
            keyboardToUpdate.Features = keyboard.Features;

            await _context.SaveChangesAsync();
            response.Data = keyboardToUpdate;

            return response;
        }

        public async Task<ServiceResponse<Keyboard>> DeleteKeyboardAsync(Guid id)
        {
            var response = new ServiceResponse<Keyboard>();
            var keyboardToDelete = await _context.Keyboards.FirstOrDefaultAsync(p => p.Id == id);

            _context.Keyboards.Remove(keyboardToDelete);
            await _context.SaveChangesAsync();
            response.Data = keyboardToDelete;

            return response;
        }
    }
}
