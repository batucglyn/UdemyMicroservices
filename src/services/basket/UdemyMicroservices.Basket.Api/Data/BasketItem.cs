using AutoMapper.Configuration;
using System.Xml.Linq;

namespace UdemyMicroservices.Basket.Api.Data
{
    public class BasketItem
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; } = default!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? PriceByApplyDiscountRate { get; set; }


        public BasketItem(Guid courseId, string courseName, string? imageUrl, decimal price, decimal? priceByApplyDiscountRate)
        {
            CourseId = courseId;
            CourseName = courseName;
            ImageUrl = imageUrl;
            Price = price;
            PriceByApplyDiscountRate = priceByApplyDiscountRate;
        }

       


    }
}
