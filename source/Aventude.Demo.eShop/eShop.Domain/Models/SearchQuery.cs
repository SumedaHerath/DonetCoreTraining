using Aventude.Demo.eShop.Core;
using System.Collections.Generic;

namespace Aventude.Demo.eShop.Domain.Models
{
    public class SearchQuery
    {
        public string CatalogItemName { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }
        
        public PageOptions PageOption { get; set; }
    }
}
