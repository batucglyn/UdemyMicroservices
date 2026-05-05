using MongoDB.Bson.Serialization.Attributes;

namespace UdemyMicroservices.Catalog.Api.Repositories
{
    public class BaseEntity
    {
        [BsonElement("_id")] public Guid Id { get; set; }
    }
}
