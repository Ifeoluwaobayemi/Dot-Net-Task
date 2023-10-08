using Core.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicationFormService _applicationFormService;

        public ApplicationFormController(IApplicationFormService applicationFormService)
        {
            _applicationFormService = applicationFormService;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetApplicationForm(string id)
        {
            var appForm = await _applicationFormService.GetByIdAsync(id);
            if (appForm == null)
            {
                return NotFound($"Application Form with ID {id} not found.");
            }

            return Ok(appForm);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetApplicationForms()
        {
            var appForms = await _applicationFormService.GetAllAsync();

            if (appForms == null)
            {
                return NotFound("Application Form not found");
            }
            return Ok(appForms);
        }

        
    }
}
