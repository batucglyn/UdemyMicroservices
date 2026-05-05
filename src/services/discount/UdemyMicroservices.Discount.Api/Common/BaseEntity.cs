using MongoDB.Bson.Serialization.Attributes;

namespace UdemyMicroservices.Discount.Api.Common
{
    public class BaseEntity
    {
        [BsonElement("_id")] public Guid Id { get; set; }
    }
}
