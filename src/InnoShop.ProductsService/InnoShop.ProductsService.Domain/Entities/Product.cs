using InnoShop.ProductsService.Domain.Enums;

namespace InnoShop.ProductsService.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Status Status { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public Product(string title, string description, decimal price, int userId)
    {
        UpdateTitle(title);
        UpdateDescription(description);
        UpdatePrice(price);
        UpdateStatus(Status.IsActive);
        UpdateUserId(userId);
        CreatedAt = DateTime.UtcNow;
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

    public void UpdateStatus(Status status)
    {
        Status = status;
    }

    public void UpdateUserId(int userId)
    {
        if(userId <= 0)
            throw new ArgumentException("UserId cannot be negative", nameof(userId));
        UserId = userId;
    }
}
