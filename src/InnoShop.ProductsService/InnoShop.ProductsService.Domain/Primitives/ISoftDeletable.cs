namespace InnoShop.ProductsService.Domain.Primitives;

public interface ISoftDeletable
{
    bool IsDeleted { get; }
}