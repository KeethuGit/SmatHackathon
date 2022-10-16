using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOM.API.Entities
{
    public class BomNode
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string NodeName { get; set; }

        [BsonElement("NodeType")]
        public string NodeType { get; set; }

        [BsonElement("ParentNode")]
        public string ParentNode { get; set; }

        public List<BomPosition> positions { get; set; }
    }
}
