using System;

namespace onlinePharmacySystem.Web.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public DateTime UserCreatedAt { get; set; }
        public int UserRoleID { get; set; }  // Yabancı anahtar
        //public Roles UserRole { get; set; }
    }
}