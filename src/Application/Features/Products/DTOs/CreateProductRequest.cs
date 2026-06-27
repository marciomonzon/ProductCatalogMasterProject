namespace Application.Features.Products.DTOs;

public sealed class CreateProductRequest
{
    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public decimal Price { get; init; }

    public int Stock { get; init; }
}