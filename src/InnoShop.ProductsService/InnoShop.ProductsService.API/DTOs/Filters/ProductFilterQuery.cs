namespace InnoShop.ProductsService.API.DTOs.Filters;

public record ProductFilterQuery(string? Search, int? MinPrice, int? MaxPrice);