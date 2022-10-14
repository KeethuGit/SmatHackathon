using BOM.API.Data;
using BOM.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOM.API.Repositories
{
    public class BomNodeRepository : IBomNodeRepository
    {
        private readonly IBomContext _context;
        public BomNodeRepository(IBomContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<BomNode>> GetNodes()
        {
            return await _context.BomNodes.Find(p => true).ToListAsync();
        }
        public async Task<BomNode> GetNode(string id)
        {
            return await _context
                                .BomNodes
                                .Find(p => p.Id == id)
                                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BomNode>> GetNodeByName(string name)
        {
            return await _context
                                .BomNodes
                                .Find(p => p.NodeName == name)
                                .ToListAsync();
        }
        public async Task CreateNode(BomNode node)
        {
            await _context.BomNodes.InsertOneAsync(node);
        }
        public async Task<bool> UpdateNode(BomNode node)
        {
            var res = await _context
                        .BomNodes
                        .ReplaceOneAsync(filter: n => n.Id == node.Id, replacement: node);
            return res.IsAcknowledged && res.ModifiedCount > 0;
        }
        public async Task<bool> DeleteNode(string id)
        {
            DeleteResult res = await _context
                                .BomNodes
                                .DeleteOneAsync(n => n.Id == id);
            return res.IsAcknowledged && res.DeletedCount > 0;
        }
    }
}
