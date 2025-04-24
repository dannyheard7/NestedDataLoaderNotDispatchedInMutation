namespace MutationDataLoaderRepro;

public static class DataLoaders
{
    [DataLoader]
    public static Task<Dictionary<int, Product>> GetProductByIdAsync(
        IReadOnlyList<int> productIds,
        CancellationToken cancellationToken)
        => Task.FromResult(TestData.Products.Where(x => productIds.Contains(x.Id)).ToDictionary(x => x.Id));

    [DataLoader]
    public static async Task<Dictionary<int, ProductCatalog>> GetProductCatalogByIdAsync(
        IReadOnlyList<int> catalogIds,
        ProductByIdDataLoader dataLoader,
        CancellationToken cancellationToken)
    {
        var catalogs = TestData.Catalogs.Where(x => catalogIds.Contains(x.Id));

        var productIds = catalogs.SelectMany(x => x.ProductIds).ToArray();
        var products = await dataLoader.LoadAsync(productIds, cancellationToken);

        return catalogs
            .GroupJoin(
                products.OfType<Product>(),
                x => x.Id,
                y => y.Id,
                (x, y) => new ProductCatalog(x.Id, y.ToArray()))
            .ToDictionary(x => x.Id);
    }
    
    private static class TestData
    {
        public static IReadOnlyList<ProductCatalogDto> Catalogs { get; } = new List<ProductCatalogDto>
        {
            new ProductCatalogDto(1, [1, 2]),
            new ProductCatalogDto(2, [2, 3]),
        };

        public static IReadOnlyList<Product> Products { get; } = new List<Product>
        {
            new Product(1),
            new Product(2),
            new Product(3)
        };
    }
}

public sealed record Product(int Id);

public sealed record ProductCatalogDto(int Id, IReadOnlyCollection<int> ProductIds);

public sealed record ProductCatalog(int Id, IReadOnlyCollection<Product> Products);