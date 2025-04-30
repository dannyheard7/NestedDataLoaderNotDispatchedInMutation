namespace MutationDataLoaderRepro;

public class Query
{
    public Task<ProductCatalog?> GetProductCatalog(
        int id,
        [Service] ProductCatalogByIdDataLoader dataLoader)
    {
        return dataLoader.LoadAsync(id);
    }
}