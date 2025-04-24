namespace MutationDataLoaderRepro;

public sealed class ProductCatalogValidator(ProductCatalogByIdDataLoader productCatalog)
{
    public async Task<bool> Validate(ProductCatalogInput input)
    {
        return await productCatalog.LoadAsync(input.Id) is null;
    }
}