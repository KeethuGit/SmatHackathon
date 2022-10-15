using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Requisitions.API.Entities;
using static Requisitions.API.Data.RequisitionContext;

namespace Requisitions.API.Data
{
    public class RequisitionContext : IRequisitionContext
    {
        
            public RequisitionContext(IConfiguration configuration)
            {
                var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

                Requisitions = database.GetCollection<Requisition>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
                
            }

            public IMongoCollection<Requisition> Requisitions { get; }
        
    }
}
