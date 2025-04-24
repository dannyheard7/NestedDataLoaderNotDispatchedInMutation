namespace MutationDataLoaderRepro;

public sealed class ProductCatalogValidator(ProductCatalogByIdDataLoader dataLoader)
{
    public async Task<bool> Validate(ProductCatalogInput input)
    {
        return await dataLoader.LoadAsync(input.Id) is null;
    }
}