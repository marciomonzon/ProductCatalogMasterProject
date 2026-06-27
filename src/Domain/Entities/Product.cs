using Domain.Common;
using Domain.Exceptions;

namespace Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public int Stock { get; private set; }

    private Product()
    {
    }

    public Product(
        string name,
        string description,
        decimal price,
        int stock)
    {
        Validate(name, description, price, stock);

        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }

    private static void Validate(
        string name,
        string description,
        decimal price,
        int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Product name is required.");

        if (name.Length > 200)
            throw new DomainException("Product name cannot exceed 200 characters.");

        if (description.Length > 1000)
            throw new DomainException("Description cannot exceed 1000 characters.");

        if (price <= 0)
            throw new DomainException("Price must be greater than zero.");

        if (stock < 0)
            throw new DomainException("Stock cannot be negative.");
    }
}