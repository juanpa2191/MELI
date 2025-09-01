using System.Collections.Generic;

namespace MercadoLibre.Core.Entities
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string[] Images { get; set; }
        public string[] Specifications { get; set; }
        public string Model { get; set; }
        public Dictionary<string, string> WarrantyInfo { get; set; }
        public string SellerInfo { get; set; }
        public List<string> Features { get; set; }
    }
}