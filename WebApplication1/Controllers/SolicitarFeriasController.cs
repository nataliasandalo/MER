using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Servico.Interface.IHttpService.ISolicitarFeriasHttpService;
using Api.Servico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Servico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitarFeriasController : ControllerBase
    {
        private readonly ISolicitarFeriasHttpService _solicitarFeriasHttpService;

        public SolicitarFeriasController(ISolicitarFeriasHttpService solicitarFeriasHttpService)
        {
            _solicitarFeriasHttpService = solicitarFeriasHttpService;
        }

        [HttpGet]
        public async Task<IEnumerable<TbSolicitarFerias>> GetSolicitarFerias()
        {
            return await _solicitarFeriasHttpService.GetSolicitarFerias();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbSolicitarFerias>> GetSolicitarFeriasById(int id)
        {
            var solicitarFerias = await _solicitarFeriasHttpService.GetSolicitarFeriasById(id);
            if (solicitarFerias == null)
            {
                return NotFound();
            }
            return solicitarFerias;
        }

        [HttpPost]
        public async Task<ActionResult<TbSolicitarFerias>> CreateSolicitarFerias(TbSolicitarFerias solicitarFerias)
        {
            var createdSolicitarFerias = await _solicitarFeriasHttpService.CreateSolicitarFerias(solicitarFerias);
            return CreatedAtAction(nameof(GetSolicitarFeriasById), new { id = createdSolicitarFerias.Id }, createdSolicitarFerias);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TbSolicitarFerias>> UpdateSolicitarFerias(int id, TbSolicitarFerias solicitarFerias)
        {
            if (id != solicitarFerias.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedSolicitarFerias = await _solicitarFeriasHttpService.UpdateSolicitarFerias(id, solicitarFerias);
                return updatedSolicitarFerias;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitarFerias(int id)
        {
            await _solicitarFeriasHttpService.DeleteSolicitarFerias(id);
            return NoContent();
        }
    }
}