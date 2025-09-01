using System.Collections.Generic;

namespace MercadoLibre.Core.Entities
{
    public class ProductDetail
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public Dictionary<string, string> Specifications { get; set; }
        public string WarrantyInfo { get; set; }
        public string SellerInfo { get; set; }
        public List<string> Features { get; set; }
    }
}