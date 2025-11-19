using System.Text.Json.Serialization;
using InnoShop.UsersService.Domain.Enums;

namespace InnoShop.UsersService.API.DTOs.Responses.UpdateUserByAdmin;

public record UpdateUserByAdminResponse
{
    public int Id { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Role Role { get; set; }
}