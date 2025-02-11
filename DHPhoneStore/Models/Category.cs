using System;
namespace DHPhoneStore.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

