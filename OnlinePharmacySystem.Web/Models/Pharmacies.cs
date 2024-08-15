using onlinePharmacySystem.Web.Models;
using System.Collections.Generic;

namespace onlinePharmacySystem.Web.Models
{
    public class Pharmacies
    {
        public int PharmacyID { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyPhoneNumber { get; set; }
        public string PharmacyWorkingDays { get; set; }
        public string PharmacyWorkingHours { get; set; }
        public ICollection<Products> PharmacyProducts { get; set; }
    }
}