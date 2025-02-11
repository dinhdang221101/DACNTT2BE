using System;
namespace DHPhoneStore.Models
{
	public class ReportWeek
	{
        public string? DayOfWeek { get; set; }
        public int TotalOrders { get; set; }
        public int TotalAmount { get; set; }
        public int TotalProducts { get; set; }
    }
    public class Top3
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ImageURL { get; set; }
        public decimal Price { get; set; }
        public int TotalQuantity { get; set; }
    }
    public class Orders
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public int PaymentMethodID { get; set; }
        public DateTime PaymentDate { get; set; }
    }
    public class UpdateOrder
    {
        public int OrderID { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

