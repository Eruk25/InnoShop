namespace InnoShop.ProductsService.Application.Products.Filters;

public record ProductSearchCriteria(string? Search, int? MinPrice, int? MaxPrice);