using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ReferenceRequestController.Controllers
{
    [Route("api")]
    [ApiController]
    public class ReferenceRequestController : ControllerBase
    {
        private readonly IReferenceRequestsService _referenceRequestsService;
        private readonly IConfiguration _configuration;
        protected ResponseDto _response;

        public ReferenceRequestsController(
            IReferenceRequestsService referenceRequestsService,
            IConfiguration configuration
        )
        {
            _referenceRequestsService = referenceRequestsService;
            _configuration = configuration;
            _response = new();
        }

        [HttpGet("current_user")]
        public async Task<IActionResult> GetCurrentUserData()
        {
            // Logic to get current user data
            // For example: var currentUserData = await YourUserService.GetCurrentUserData();
            return Ok(currentUserData);
        }

        [HttpGet("reference-requests")]
        public async Task<IActionResult> GetReferenceRequests()
        {
            // Logic to get reference requests
            // For example: var referenceRequests = await _referenceRequestsService.GetReferenceRequests();
            return Ok(referenceRequests);
        }

        [HttpGet("mentor-requests/{mentorId}")]
        public async Task<IActionResult> GetMentorReferenceRequests(int mentorId)
        {
            // Implement logic to get reference requests for a mentor
            var referenceRequests = await _referenceRequestsService.GetMentorReferenceRequests(
                mentorId
            );
            _response.Result = referenceRequests;
            return Ok(_response);
        }

        [HttpPost("create-request")]
        public async Task<IActionResult> CreateReferenceRequest(
            [FromBody] ReferenceRequestDto model
        )
        {
            // Implement logic to create a new reference request
            var errorMessage = await _referenceRequestsService.CreateReferenceRequest(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                _response.Result = "Failed";
                return BadRequest(_response);
            }

            _response.Message = "Reference Request Created Successfully";
            _response.Result = "Success";
            return Ok(_response);
        }
    }
}
