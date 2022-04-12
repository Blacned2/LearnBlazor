using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    [BsonIgnoreExtraElements]
    public class Category
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("categoryName")]
        public string CategoryName { get; set; }
        [BsonElement("description")]
        public string Description { get; set; } 
    }
}
