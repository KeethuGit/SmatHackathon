using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Requisitions.BusinessLogic.Entities;
using static Requisitions.BusinessLogic.Data.RequisitionContext;

namespace Requisitions.BusinessLogic.Data
{
    public class RequisitionContext : IRequisitionContext
    {
        
            public RequisitionContext(IConfiguration configuration)
            {
                var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

                Requisitions = database.GetCollection<Requisition>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
                
            }
        public RequisitionContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("RequisitionDb");

            Requisitions = database.GetCollection<Requisition>("Requisition");

        }

        public IMongoCollection<Requisition> Requisitions { get; }
        
    }
}
