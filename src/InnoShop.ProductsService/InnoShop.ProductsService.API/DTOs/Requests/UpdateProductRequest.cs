namespace InnoShop.ProductsService.API.DTOs.Requests;

public record UpdateProductRequest(string? Title, string? Description,
    decimal? Price);