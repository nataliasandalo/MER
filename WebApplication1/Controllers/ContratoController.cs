using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Servico.Interface.IHttpService.IContratoHttpService;
using Api.Servico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Servico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoHttpService _contratoHttpService;

        public ContratoController(IContratoHttpService contratoHttpService)
        {
            _contratoHttpService = contratoHttpService;
        }

        [HttpGet]
        public async Task<IEnumerable<TbContrato>> GetContratos()
        {
            return await _contratoHttpService.GetContratos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbContrato>> GetContratoById(int id)
        {
            var contrato = await _contratoHttpService.GetContratoById(id);
            if (contrato == null)
            {
                return NotFound();
            }
            return contrato;
        }

        [HttpPost]
        public async Task<ActionResult<TbContrato>> CreateContrato(TbContrato contrato)
        {
            var createdContrato = await _contratoHttpService.CreateContrato(contrato);
            return CreatedAtAction(nameof(GetContratoById), new { id = createdContrato.Id }, createdContrato);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TbContrato>> UpdateContrato(int id, TbContrato contrato)
        {
            if (id != contrato.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedContrato = await _contratoHttpService.UpdateContrato(id, contrato);
                return updatedContrato;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrato(int id)
        {
            await _contratoHttpService.DeleteContrato(id);
            return NoContent();
        }
    }
}