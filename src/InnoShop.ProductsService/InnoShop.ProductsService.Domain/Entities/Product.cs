
using InnoShop.ProductsService.Domain.Primitives;

namespace InnoShop.ProductsService.Domain.Entities;

public class Product : ISoftDeletable
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsDeleted { get; private set; }
    public int UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Product(string title, string description, decimal price, int userId)
    {
        UpdateTitle(title);
        UpdateDescription(description);
        UpdatePrice(price);
        UpdateStatus(false);
        UpdateUserId(userId);
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string? title, string? description, decimal? price)
    {
        if(!string.IsNullOrWhiteSpace(title))
            UpdateTitle(title);
        if(!string.IsNullOrWhiteSpace(description))
            UpdateDescription(description);
        if(price.HasValue)
            UpdatePrice(price.Value);
    }
    
    public void UpdateTitle(string title)
    {
        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));
        Title = title;
    }

    public void UpdateDescription(string description)
    {
        if(string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));
        Description = description;
    }

    public void UpdatePrice(decimal price)
    {
        if(price <= 0)
            throw new ArgumentException("Price cannot be negative", nameof(price));
        Price = price;
    }

    public void UpdateStatus(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }

    public void UpdateUserId(int userId)
    {
        if(userId <= 0)
            throw new ArgumentException("UserId cannot be negative", nameof(userId));
        UserId = userId;
    }
}
