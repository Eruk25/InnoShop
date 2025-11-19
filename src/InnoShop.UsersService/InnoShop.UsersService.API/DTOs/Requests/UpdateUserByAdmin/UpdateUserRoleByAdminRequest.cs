using System.Text.Json.Serialization;
using InnoShop.UsersService.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace InnoShop.UsersService.API.DTOs.Requests.UpdateUserByAdmin;

public record UpdateUserRoleByAdminRequest
{
    public int Id { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Role? Role { get; set; }
}