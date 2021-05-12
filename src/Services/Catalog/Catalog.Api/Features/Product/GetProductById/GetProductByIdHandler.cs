using Catalog.Api.Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Api.Features.Product.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
    {
        private readonly ICatalogContext _catalogContext;

        public GetProductByIdHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _catalogContext.Products
                .Include(c => c.Category)
                .FirstOrDefaultAsync(p => p.Id == request.ProductId)
                .ConfigureAwait(false);

            return new GetProductByIdResponse { Product = product };
        }
    }
}
