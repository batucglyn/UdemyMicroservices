using System.Text.Json.Serialization;

namespace UdemyMicroservices.Basket.Api.Dtos
{
    public record BasketDto
    {
        public BasketDto(Guid userId, List<BasketItemDto> basketItems)
        {
            UserId = userId;
            BasketItems = basketItems;
        }
        public BasketDto()
        {
        }

        public List<BasketItemDto> BasketItems { get; set; } = new();

        [JsonIgnore]
        public Guid UserId { get; init; }
        [JsonIgnore]
        public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
        public float? DiscountRate { get; set; }
        public string? Coupon { get; set; }


        public decimal TotalPrice => BasketItems.Sum(x => x.Price);

        public decimal? TotalPriceWithDiscount
        {
            get
            {
                if (!IsApplyDiscount) return null;

                return BasketItems.Sum(x => x.PriceByApplyDiscountRate);

            }
        }

      

      
    }
}
