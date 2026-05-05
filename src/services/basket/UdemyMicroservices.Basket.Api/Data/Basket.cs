namespace UdemyMicroservices.Basket.Api.Data;

public class Basket
{


    public Guid UserId { get; set; }
    public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

    public float? DiscountRate { get; set; }
    public string? Coupon { get; set; }

    public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);


    public decimal TotalPrice => BasketItems.Sum(x => x.Price);



    public Basket(Guid userId,List<BasketItem> basketItems)
    {
        UserId = userId;
        BasketItems = basketItems;

    }
    public Basket()
    {
        
    }

    public decimal? TotalPriceWithDiscount
    {
        get
        {
            if (!IsApplyDiscount) return null;

            return BasketItems.Sum(x => x.PriceByApplyDiscountRate);

        }
    }









    public void ApplyDiscount(float discountRate, string coupon)
    {
        DiscountRate = discountRate;
        Coupon = coupon;
        foreach (var item in BasketItems)
        {
            item.PriceByApplyDiscountRate = item.Price - (item.Price * (decimal)(discountRate / 100));
        }
    }
    public void RemoveDiscount()
    {
        DiscountRate = null;
        Coupon = null;
        foreach (var item in BasketItems)
        {
            item.PriceByApplyDiscountRate = null;
        }
    }
    public void ApplyAvaliableDiscount()
    {
        if (!IsApplyDiscount)
            return;

        foreach (var item in BasketItems)
        {
            item.PriceByApplyDiscountRate = item.Price - (item.Price * (decimal)(DiscountRate! / 100));
        }

    }







}

