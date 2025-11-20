namespace InnoShop.ProductsService.Application.Products;

public record ProductDto(int Id, string Title, string Description,
    decimal Price, DateTime CreatedAt);