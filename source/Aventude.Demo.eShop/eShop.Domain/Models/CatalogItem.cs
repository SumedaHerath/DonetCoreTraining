using Aventude.Demo.eShop.Core;

namespace Aventude.Demo.eShop.Domain.Models
{
    public class CatalogItem : Entity
    {
        public int TypeId { get; set; }

        public int BrandId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int ReorderLevel { get; set; }

        public CatalogType Type { get; set; }

        public CatalogBrand Brand { get; set; }
    }
}
