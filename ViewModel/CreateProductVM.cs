using E_Commerce.Data.Enum;
#nullable disable
namespace E_Commerce.ViewModel
{
    public class CreateProductVM
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public IFormFile Product_Image { get; set; }
        public int Product_Price { get; set; }
        public ProductCategory Product_Category { get; set; }

    }
}
