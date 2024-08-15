using onlinePharmacySystem.Web.Models;
using System;
using System.Collections.Generic;

namespace onlinePharmacySystem.Web.Models
{
    public class Basket
    {
        public int BasketID { get; set; }
        public ICollection<OrderDetails> BasketOrderDetails { get; set; }
        public int BasketUserID { get; set; }  // Yabancı anahtar
        public Users BasketUser { get; set; }
        public DateTime BasketDate { get; set; }
    }
}