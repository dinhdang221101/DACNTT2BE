using System;
namespace DHPhoneStore.Models
{
	public class User
	{
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }

    public class AddToCart
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }

    public class CartUser
    {
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? ImageURL { get; set; }
        public int DiscountPercent { get; set; }
    }

    public class StockProduct
    {
        public int Stock { get; set; }
        public int ProductID { get; set; }
        public StockProduct() { }
        public StockProduct(int Stock, int ProductID)
        {
            this.Stock = Stock;
            this.ProductID = ProductID;
        }
    }

    public class UserOrder
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int UserID { get; set; }
        public List<ProductOrder> Products { get; set; }
        public int PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class UserHistory
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Price { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PaymentTransactionID { get; set; }
        public int PaymentMethodID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? ProductName { get; set; }
        public string? ImageURL { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int Rating { get; set; }
    }

    public class ReviewProduct
    {
        public int UserID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
    public class VNPayRequest
    {
        public int OrderID { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

