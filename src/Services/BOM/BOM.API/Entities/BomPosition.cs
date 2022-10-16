using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOM.API.Entities
{
    public class BomPosition
    {
        [BsonId]
        public string PositionId { get; set; }
        public string NodeId { get; set; }
        public long PositionNumber { get; set; }
        public string ItemType { get; set; }
        public string IssueStatus { get; set; }
        public string ListStatus { get; set; }
        public decimal Quantity { get; set; }
        public string QuantityUnit { get; set; }
        public string CommodityCode { get; set; }
        public string IdentCode { get; set; }

    }
}
