namespace MutationDataLoaderRepro;

public class Mutation
{
    public async Task<bool> AddProductCatalog(
        ProductCatalogInput input,
        [Service] ProductCatalogByIdDataLoader dataLoader)
    {
         return await dataLoader.LoadAsync(input.Id) is null;
    }
}