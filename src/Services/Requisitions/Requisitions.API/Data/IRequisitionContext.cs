using MongoDB.Driver;
using Requisitions.API.Entities;

namespace Requisitions.API.Data
{
    public interface IRequisitionContext
    {
        IMongoCollection<Requisition> Requisitions { get; }
    }
}
