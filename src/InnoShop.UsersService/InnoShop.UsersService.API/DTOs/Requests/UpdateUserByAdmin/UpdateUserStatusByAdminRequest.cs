using System.Text.Json.Serialization;
using InnoShop.UsersService.Domain.Enums;

namespace InnoShop.UsersService.API.DTOs.Requests.UpdateUserByAdmin;

public class UpdateUserStatusByAdminRequest
{
    public int Id { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status? Status { get; set; }
}