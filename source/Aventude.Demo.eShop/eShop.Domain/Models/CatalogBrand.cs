using Aventude.Demo.eShop.Core;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Aventude.Demo.eShop.Domain.Models
{
    public class CatalogBrand : Entity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
