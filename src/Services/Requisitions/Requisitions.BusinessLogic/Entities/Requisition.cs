using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Requisitions.BusinessLogic.Entities
{
    public class Requisition
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RId { get; set; }
        public string RequisitionName { get; set; }
        public long Supplement { get; set; }
        public string RequisitionType { get; set; }
        public string PurchaseIndicator { get; set; }
        public string ReqNodePath { get; set; }
        public string Origin { get; set; }
        public string ReqStatusCode { get; set; }
        public string ReleaseContext { get; set; }
        public DateTime? RelToProcDate { get; set; }
        public string RelToProcBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string Originator { get; set; }
        public decimal OriginalBudget { get; set; }
        public string Currency { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<LineItem> LineItems { get; set; }
    }
}
