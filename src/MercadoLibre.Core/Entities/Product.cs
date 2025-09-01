using System.Collections.Generic;

namespace MercadoLibre.Core.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<string> Images { get; set; }
        public int Stock { get; set; }
        public string Condition { get; set; }
        public decimal Rating { get; set; }
        public ProductDetail Details { get; set; }
    }
}