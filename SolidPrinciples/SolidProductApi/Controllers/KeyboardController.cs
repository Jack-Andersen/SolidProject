using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidProductApi.Data;
using SolidProductApi.Models;
using SolidProductApi.Services.ProductServices;

namespace SolidProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        private readonly IKeyboardService _keyboardService;

        public KeyboardController(IKeyboardService keyboardService)
        {
            _keyboardService = keyboardService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Keyboard>>>> GetKeyboard()
        {
            var keyboards = await _keyboardService.GetKeyboardAsync();

            var response = new ServiceResponse<List<Keyboard>>
            {
                Data = keyboards.Data
            };

            return Ok(response.Data);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Keyboard>>> GetKeyboard([FromRoute] Guid id)
        {
            var keyboard = await _keyboardService.GetKeyboardAsync(id);

            var response = new ServiceResponse<Keyboard>
            {
                Data = keyboard.Data
            };

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Keyboard>>> AddKeyboard(Keyboard keyboard)
        {
            await _keyboardService.AddKeyboardAsync(keyboard);

            var response = new ServiceResponse<Keyboard>
            {
                Data = keyboard
            };

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Keyboard>>> EditKeyboard(Keyboard keyboard)
        {
            await _keyboardService.EditKeyboardAsync(keyboard);

            var response = new ServiceResponse<Keyboard>
            {
                Data = keyboard
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Keyboard>>> DeleteKeyboard([FromRoute] Guid id)
        {
            await _keyboardService.DeleteKeyboardAsync(id);

            var response = new ServiceResponse<Keyboard>();

            return Ok(response);
        }
    }
}
