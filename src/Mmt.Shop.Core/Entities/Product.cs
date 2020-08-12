using System;
using System.Text.Json.Serialization;

namespace Mmt.Shop.Core.Entities
{
    public class Product : IEquatable<Product>
    {
        [JsonPropertyName("Sku")]
        public string ProductSku { get; set; }

        [JsonPropertyName("Name")]
        public string ProductName { get; set; }

        [JsonPropertyName("Description")]
        public string ProductDescription { get; set; }

        [JsonPropertyName("Price")]
        public decimal ProductPrice { get; set; }

        public bool Equals(Product other)
        {
            return other.ProductSku == ProductSku 
                && other.ProductName == ProductName 
                && other.ProductDescription == ProductDescription 
                && other.ProductPrice == ProductPrice;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Product);
        }

        public override int GetHashCode()
        {
            return ProductSku.GetHashCode();
        }
    }
}
