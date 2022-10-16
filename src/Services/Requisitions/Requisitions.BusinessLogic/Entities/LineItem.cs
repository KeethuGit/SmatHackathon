using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Requisitions.BusinessLogic.Entities
{
    public class LineItem
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string RliId { get; set; }
        ////public string RId { get; set; }
        public long Position { get; set; }
        public long SubPosition { get; set; }
        public string IdentCode { get; set; }
        public string CommodityCode { get; set; }
        public string ItemType { get; set; }
        public decimal ReleasedQty { get; set; }
        public string ReleaseQtyUnit { get; set; }
        public DateTime? ROSDate { get; set; }
        public decimal UnitWeight { get; set; }
        public decimal Budget { get; set; }
        public string Currency { get; set; }
        public string DeliveryDesignation { get; set; }
    }
}
