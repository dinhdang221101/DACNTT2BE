using System;
namespace DHPhoneStore.Models
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public string? PromotionName { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class AddProductsPromotion
    {
        public int PromotionID { get; set; }
        public List<int>? ProductIDs { get; set; }
    }
    public class ListAddProductPromotion
    {
        public int PromotionID { get; set; }
        public int ProductID { get; set; }
    }
}

