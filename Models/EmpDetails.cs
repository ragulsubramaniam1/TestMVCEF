using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LinqQueryEf.Models.DB_EF
{
    public class EmpDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string empusername { get; set; }
        public string empemail { get; set; }
        public string emppassword { get; set; }
    }
}
