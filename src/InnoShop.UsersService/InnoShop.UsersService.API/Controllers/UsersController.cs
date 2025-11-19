using System.Security.Claims;
using InnoShop.UsersService.API.DTOs.Requests.UpdateProfile;
using InnoShop.UsersService.API.DTOs.Requests.UpdateUserByAdmin;
using InnoShop.UsersService.API.DTOs.Responses.UpdateUserByAdmin;
using InnoShop.UsersService.API.Extensions;
using InnoShop.UsersService.Application.Users.Update.UpdateUserByAdmin;
using InnoShop.UsersService.Application.Users.Update.UpdateUserByAdmin.UpdateUserRole;
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

    [HttpPatch]
    [Authorize(Roles = "Admin")]
    [Route("{id}/status")]
    public async Task<ActionResult<UpdateUserByAdminResponse>> UpdateStatusAsync([FromBody] UpdateUserStatusByAdminRequest request)
    {
        var result = await _mediator.Send(new UpdateUserStatusByAdminCommand(
            request.Id, request.Status));
        var response = new UpdateUserByAdminResponse
        {
            Id = result.Id,
            Status = result.Status,
            Role = result.Role,
        };
        return Ok(response);
    }

    [HttpPatch]
    [Authorize(Roles = "Admin")]
    [Route("{id}/role")]
    public async Task<ActionResult<UpdateUserByAdminResponse>> UpdateRoleAsync([FromBody] UpdateUserRoleByAdminRequest request)
    {
        var result = await _mediator.Send(new UpdateUserRoleByAdminCommand(
            request.Id,
            request.Role));
        var response = new UpdateUserByAdminResponse
        {
            Id = result.Id,
            Role = result.Role,
            Status = result.Status,
        };
        return Ok(response);
    }
}