using Catalog.Api.Data.Entities;
using Catalog.Api.Features.Product.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Index(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { ProductId = id }).ConfigureAwait(false);

            return Ok(result.Product);
        }
    }
}
