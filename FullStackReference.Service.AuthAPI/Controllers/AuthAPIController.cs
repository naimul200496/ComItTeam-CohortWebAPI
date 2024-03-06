﻿
using FullStackReference.Service.AuthAPI.Models.Dto;
using FullStackReference.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackReference.Service.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        //private readonly IMessageBus _messageBus;
        private readonly IConfiguration _configuration;
        protected ResponseDto _response;
        public AuthAPIController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
           // _messageBus = messageBus;
            _response = new();
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {

            var errorMessage = await _authService.Register(model);
           
            if (!string.IsNullOrEmpty(errorMessage) )
            {
                _response.IsSuccess = false;
                _response.Message= errorMessage;
                _response.Result = "Faild";
                return BadRequest(_response);
            }
            // await _messageBus.PublishMessage(model.Email, _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue"));
            _response.Message = "User Created Successfully";
            _response.Result = "Success";
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            //if (!assignRoleSuccessful)
            //{
            //    _response.IsSuccess = false;
            //    _response.Message = "Error encountered";
            //    return BadRequest(_response);
            //}
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);

        }

        //[HttpPost("AssignRole")]
        //public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        //{
        //    var assignRoleSuccessful = await _authService.AssignRole(model.Email,model.Role.ToUpper());
        //    if (!assignRoleSuccessful)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = "Error encountered";
        //        return BadRequest(_response);
        //    }
        //    return Ok(_response);

        //}


    }
}
