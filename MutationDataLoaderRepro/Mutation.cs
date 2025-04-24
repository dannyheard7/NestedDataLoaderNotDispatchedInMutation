namespace MutationDataLoaderRepro;

public class Mutation
{
    public async Task<bool> AddProductCatalog(
        ProductCatalogInput input,
        [Service] ProductCatalogValidator validator)
    {
        return await validator.Validate(input);
    }
    
    public async Task<bool> AddProductCatalogDirect(
        ProductCatalogInput input,
        [Service] ProductByIdDataLoader dataLoader)
    {
        return await dataLoader.LoadAsync(input.Id) is null;
    }
}