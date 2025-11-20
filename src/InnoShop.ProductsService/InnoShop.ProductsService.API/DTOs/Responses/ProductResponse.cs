namespace InnoShop.ProductsService.API.DTOs.Responses;

public record ProductResponse(int Id, string Title, string Description,
    decimal Price);