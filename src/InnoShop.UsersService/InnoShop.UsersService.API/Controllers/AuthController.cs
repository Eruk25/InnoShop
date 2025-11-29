using InnoShop.UsersService.API.DTOs.Requests.Login;
using InnoShop.UsersService.API.DTOs.Requests.Register;
using InnoShop.UsersService.API.DTOs.Responses.Register;
using InnoShop.UsersService.Application.EmailVerificationToken.VerifyEmail;
using InnoShop.UsersService.Application.PasswordVerificationToken;
using InnoShop.UsersService.Application.Users.Login;
using InnoShop.UsersService.Application.Users.Register;
using InnoShop.UsersService.Application.Users.Update.UpdateUserPassword;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace InnoShop.UsersService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterUserResponse>> RegisterAsync([FromBody] RegisterUserRequest request)
    {
        var user = await _mediator.Send(new RegisterUserCommand(
            request.Name, request.Email, request.Password));
        return Ok(new RegisterUserResponse(user.Id, user.Name, user.Email));
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> LoginAsync([FromBody] LoginUserRequest request)
    {
        var token = await _mediator.Send(new LoginUserCommand(
            request.Email, request.Password));
        return Ok(token);
    }

    [HttpGet("verify-email")]
    public async Task<IActionResult> VerifyEmailAsync(Guid token)
    {
        var success = await _mediator.Send(new VerifyEmailCommand(token));
        return success ? Ok() : BadRequest();
    }
    
    [HttpPost]
    [Route("forgot-password")]
    public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordRequest request)
    {
        await _mediator.Send(new ForgotPasswordCommand(request.Email));
        return Ok();
    }
    
    [HttpPatch]
    [Route("reset-password")]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequest request)
    {
        await _mediator.Send(new UpdateUserPasswordCommand(
            request.Email,
            request.ResetCode,
            request.NewPassword));
        return Ok();
    }
}