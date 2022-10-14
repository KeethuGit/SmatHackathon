using BOM.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOM.API.Data
{
    public class BomContext : IBomContext
    {
        public BomContext(IConfiguration config) 
        {
            var client = new MongoClient(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<string>("DatabaseSettings.DatabaseName"));

            BomNodes = database.GetCollection<BomNode>(config.GetValue<string>("DatabaseSettings.CollectionName"));

        }
        public IMongoCollection<BomNode> BomNodes { get; }
    }
}
