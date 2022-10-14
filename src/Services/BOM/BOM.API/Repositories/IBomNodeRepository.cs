using BOM.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOM.API.Repositories
{
    public interface IBomNodeRepository
    {
        Task<IEnumerable<BomNode>> GetNodes();
        Task<BomNode> GetNode(string id);
        Task<IEnumerable<BomNode>> GetNodeByName(string name);
        Task CreateNode(BomNode node);
        Task<bool> UpdateNode(BomNode node);
        Task<bool> DeleteNode(string id);
    }
}
