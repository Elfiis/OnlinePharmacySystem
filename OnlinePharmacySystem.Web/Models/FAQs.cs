using System;

namespace onlinePharmacySystem.Web.Models
{
    public class FAQs
    {
        public int FaqID { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}