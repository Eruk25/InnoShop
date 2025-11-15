using System.Security.Claims;
using InnoShop.UsersService.API.DTOs.Requests.UpdateProfile;
using InnoShop.UsersService.API.Extensions;
using InnoShop.UsersService.Application.Users.Update.UpdateUserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoShop.UsersService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPatch]
    [Authorize]
    [Route("me")]
    public async Task<IActionResult> UpdateUserProfileAsync([FromBody] UpdateUserProfileRequest request)
    {
        var userId = User.GetUserId();
        await _mediator.Send(new UpdateUserProfileCommand(userId, request.Name,
            request.Email, request.Password));
        return NoContent();
    }
}