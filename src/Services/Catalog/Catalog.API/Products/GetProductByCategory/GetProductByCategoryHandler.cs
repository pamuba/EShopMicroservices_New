﻿
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Catgory):IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    internal class GetProductByCategoryQueryHandler
        (IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
            :IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            //logger.LogInformation("GetProductByCategoryQueryHandler.Handle called with {@query}", query);
            var products = await session.Query<Product>()
                .Where(p => p.Category.Contains(query.Catgory))
                .ToListAsync();

            return new GetProductByCategoryResult(products);
        }
    }

}

