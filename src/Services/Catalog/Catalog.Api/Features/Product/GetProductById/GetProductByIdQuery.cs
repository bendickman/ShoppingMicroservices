using MediatR;

namespace Catalog.Api.Features.Product.GetProductById
{
    public class GetProductByIdQuery : IRequest<GetProductByIdResponse>
    {
        public int ProductId { get; set; }
    }
}
