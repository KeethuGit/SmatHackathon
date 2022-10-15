using MongoDB.Driver;
using Requisitions.API.Data;
using Requisitions.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Requisitions.API.Repositories
{
    public class RequisitionRepository : IRequisitionRepository
    {
        private readonly IRequisitionContext _context;

        public RequisitionRepository(IRequisitionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Requisition>> GetRequisitions()
        {
            return await _context
                           .Requisitions
                           .Find(p => true)
                           .ToListAsync();
        }

        public async Task<Requisition> GetRequisition(string id)
        {
            return await _context
                           .Requisitions
                           .Find(p => p.RId == id)
                           .FirstOrDefaultAsync();
        }

        public async Task CreateRequisition(Requisition requisition)
        {
            await _context.Requisitions.InsertOneAsync(requisition);
        }

        public async Task<bool> UpdateRequisition(Requisition requisition)
        {
            var updateResult = await _context
                                       .Requisitions
                                       .ReplaceOneAsync(filter: g => g.RId == requisition.RId, replacement: requisition);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteRequisition(string id)
        {
            FilterDefinition<Requisition> filter = Builders<Requisition>.Filter.Eq(p => p.RId, id);

            DeleteResult deleteResult = await _context
                                                .Requisitions
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

    }
}
