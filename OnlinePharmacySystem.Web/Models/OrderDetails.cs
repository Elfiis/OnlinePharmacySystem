using onlinePharmacySystem.Web.Models;

namespace onlinePharmacySystem.Web.Models
{
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; } // Yabancı anahtar
        public Orders OrderDetailOrder { get; set; }
        public int ProductID { get; set; } // Yabancı anahtar
        public Products OrderDetailProduct { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxRate { get; set; }
    }
}