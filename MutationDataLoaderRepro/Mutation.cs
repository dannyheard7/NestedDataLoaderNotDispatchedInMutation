namespace MutationDataLoaderRepro;

public class Mutation
{
    public async Task<bool> AddProductCatalog(
        ProductCatalogInput input,
        [Service] ProductCatalogValidator validator)
    {
        return await validator.Validate(input);
    }
}