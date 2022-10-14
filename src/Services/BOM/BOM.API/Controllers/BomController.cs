using BOM.API.Entities;
using BOM.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BOM.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BomController : ControllerBase
    {
        private readonly IBomNodeRepository _repository;
        private readonly ILogger<BomController> _logger;

        public BomController(IBomNodeRepository repository, ILogger<BomController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BomNode>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BomNode>>> GetNodes() 
        {
            var nodes = await _repository.GetNodes();
            return Ok(nodes);
        }

        [HttpGet("{id:length(24)}", Name = "GetNode")]
        [ProducesResponseType(typeof(BomNode), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<BomNode>> GetNodeById(string id)
        {
            var node = await _repository.GetNode(id);
            if (node == null)
            {
                _logger.LogError($"Node with Id {id} is not found.");
                return NotFound();
            }
            return Ok(node);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BomNode), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BomNode>> CreateNode([FromBody] BomNode node)
        {
            await _repository.CreateNode(node);

            return CreatedAtRoute("GetNode", new { id = node.Id }, node);
        }

        [HttpPut]
        [ProducesResponseType(typeof(BomNode), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateNode([FromBody] BomNode node)
        {
            return Ok(await _repository.UpdateNode(node));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BomNode), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteNode(string id)
        {
            return Ok(await _repository.DeleteNode(id));
        }
    }
}
