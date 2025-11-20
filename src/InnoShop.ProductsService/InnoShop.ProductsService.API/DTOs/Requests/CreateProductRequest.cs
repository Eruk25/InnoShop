namespace InnoShop.ProductsService.API.DTOs.Requests;

public record CreateProductRequest(string Title, string Description,
    decimal Price);