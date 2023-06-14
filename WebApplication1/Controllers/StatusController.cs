using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Servico.Interface.IHttpService.IStatusHttpService;
using Api.Servico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Servico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusHttpService _statusHttpService;

        public StatusController(IStatusHttpService statusHttpService)
        {
            _statusHttpService = statusHttpService;
        }

        [HttpGet]
        public async Task<IEnumerable<TbStatus>> GetStatus()
        {
            return await _statusHttpService.GetStatus();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbStatus>> GetStatusById(int id)
        {
            var status = await _statusHttpService.GetStatusById(id);
            if (status == null)
            {
                return NotFound();
            }
            return status;
        }

        [HttpPost]
        public async Task<ActionResult<TbStatus>> CreateStatus(TbStatus status)
        {
            var createdStatus = await _statusHttpService.CreateStatus(status);
            return CreatedAtAction(nameof(GetStatusById), new { id = createdStatus.Id }, createdStatus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TbStatus>> UpdateStatus(int id, TbStatus status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedStatus = await _statusHttpService.UpdateStatus(id, status);
                return updatedStatus;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            await _statusHttpService.DeleteStatus(id);
            return NoContent();
        }
    }
}