using Requisitions.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisitions.API.Repositories
{
    public interface IRequisitionRepository
    {
        Task<IEnumerable<Requisition>> GetRequisitions();
        Task<Requisition> GetRequisition(string id);
        Task CreateRequisition(Requisition requisition);
        Task<bool> UpdateRequisition(Requisition requisition);
        Task<bool> DeleteRequisition(string id);
    }
}
