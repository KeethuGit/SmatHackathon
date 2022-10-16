using MongoDB.Driver;
using Requisitions.BusinessLogic.Entities;

namespace Requisitions.BusinessLogic.Data
{
    public interface IRequisitionContext
    {
        IMongoCollection<Requisition> Requisitions { get; }
    }
}
