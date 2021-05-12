using Catalog.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Data.Interfaces
{
    public interface ICatalogContext
    {
        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<ProductDto> Products { get; set; }
    }
}
