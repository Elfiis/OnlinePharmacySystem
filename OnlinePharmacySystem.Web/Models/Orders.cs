using onlinePharmacySystem.Web.Models;
using System;

namespace onlinePharmacySystem.Web.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int OrderUserID { get; set; }  // Yabancı anahtar
        public Users OrderUser { get; set; }
        public int OrderPaymentID { get; set; }  // Yabancı anahtar
        public Payments OrderPayment { get; set; }
        public int OrderPharmacyID { get; set; }  // Yabancı anahtar
        public Pharmacies OrderPharmacy { get; set; }
        public string OrderInvoiceNo { get; set; }
        public DateTime OrderCreatedAt { get; set; }
        public int OrderDeliveryID { get; set; }  // Yabancı anahtar
        public Deliveries OrderDelivery { get; set; }
    }
}