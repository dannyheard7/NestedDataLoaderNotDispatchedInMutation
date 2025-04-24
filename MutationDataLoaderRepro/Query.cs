namespace MutationDataLoaderRepro;

public class Query
{
    public Task<bool> ValidateProductCatalogInput(
        ProductCatalogInput input,
        [Service] ProductCatalogValidator validator)
    {
        return validator.Validate(input);
    }
}