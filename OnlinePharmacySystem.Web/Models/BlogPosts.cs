using System;

namespace onlinePharmacySystem.Web.Models
{
    public class BlogPosts
    {
        public int BlogPostID { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public string PostAuthorName { get; set; }
        public string PostAuthorEmail { get; set; }
        public string PostDescription { get; set; }
        public DateTime PostDate { get; set; }
        public string PostURL { get; set; }
    }
}