using onlinePharmacySystem.Web.Models;

namespace onlinePharmacySystem.Web.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategoryID { get; set; }  // Yabancı anahtar
        public Categories ProductCategory { get; set; }
        public int ProductBrandID { get; set; }  // Yabancı anahtar
        public Brands ProductBrand { get; set; }
        public int ProductSupplierID { get; set; }  // Yabancı anahtar
        public Suppliers ProductSupplier { get; set; }
        public int ProductFAQsID { get; set; }  // Yabancı anahtar
        public FAQs ProductFAQs { get; set; }
        public string ProductImageURL { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductPharmaciesID { get; set; }  // Yabancı anahtar
        public Pharmacies ProductPharmacies { get; set; }
    }
}