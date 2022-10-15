using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;
using Requisitions.API.Repositories;
using Requisitions.API.Entities;

namespace Requisitions.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RequisitionsController : ControllerBase
    {
        private readonly IRequisitionRepository _repository;
        private readonly ILogger<RequisitionsController> _logger;

        public RequisitionsController(IRequisitionRepository repository, ILogger<RequisitionsController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Requisition>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Requisition>>> GetRequisitions()
        {
            var products = await _repository.GetRequisitions();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetRequisition")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Requisition), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Requisition>> GetRequisitionById(string id)
        {
            var requisition = await _repository.GetRequisition(id);
            if (requisition == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }
            return Ok(requisition);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Requisition), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Requisition>> CreateRequisition([FromBody] Requisition requisition)
        {
            await _repository.CreateRequisition(requisition);

            return CreatedAtRoute("GetRequisition", new { id = requisition.RId }, requisition);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Requisition), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateRequisition([FromBody] Requisition requisition)
        {
            return Ok(await _repository.UpdateRequisition(requisition));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteRequisition")]
        [ProducesResponseType(typeof(Requisition), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteRequisitionById(string id)
        {
            return Ok(await _repository.DeleteRequisition(id));
        }
    }
}
