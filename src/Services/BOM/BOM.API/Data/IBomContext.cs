using BOM.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOM.API.Data
{
    public interface IBomContext
    {
        IMongoCollection<BomNode> BomNodes { get; }
    }
}
