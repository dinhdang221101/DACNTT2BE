namespace DHPhoneStore.Models
{
	public class Product
	{
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int CategoryID { get; set; }
        public string? Brand { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalCount { get; set; }
    }

    public class ProductSale : Product
    {
        public int DiscountPercent { get; set; }
    }

    public class ProductOrder : Product
    {
        public int OrderID { get; set; }
        public int Quantity { get; set; }
    }

    public class ReviewsProduct
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public string? FullName { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

