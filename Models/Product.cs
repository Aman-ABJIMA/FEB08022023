#nullable disable
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public string Product_Image { get; set;}
        public int Product_Price { get; set; }

    }
}
