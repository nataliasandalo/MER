using Api.Holerite.Interface;
using Api.Holerite.Service.HoleriteService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Holerite.Controllers
{
    [ApiController]
    [Route("api/holerite")]
    public class HoleriteController : ControllerBase
    {
        private readonly IHoleriteService _holeriteService;

        public HoleriteController(IHoleriteService holeriteService)
        {
            _holeriteService = holeriteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Holerite>>> GetHolerite()
        {
            try
            {
                var holerite = await _holeriteService.GetHolerite();
                return Ok(holerite);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                return StatusCode(500, "Ocorreu um erro ao obter os produtos.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Holerite>> GetHoleriteById(int id)
        {
            try
            {
                var holerite = await _holeriteService.GetHoleriteById(id);
                if (holerite == null)
                {
                    return NotFound();
                }

                return Ok(holerite);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                return StatusCode(500, $"Ocorreu um erro ao obter o produto com o ID {id}.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Models.Holerite>> CreateHolerite(Models.Holerite holerite)
        {
            try
            {
                var createdHolerite = await _holeriteService.CreateHolerite(holerite);
                return CreatedAtAction(nameof(GetHoleriteById), new { id = createdHolerite.Id }, createdHolerite);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                return StatusCode(500, "Ocorreu um erro ao criar o produto.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Models.Holerite>> UpdateHolerite(int id, Models.Holerite holerite)
        {
            try
            {
                var updatedHolerite = await _holeriteService.UpdateHolerite(id, holerite);
                if (updatedHolerite == null)
                {
                    return NotFound();
                }

                return Ok(updatedHolerite);
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                return StatusCode(500, $"Ocorreu um erro ao atualizar o produto com o ID {id}.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolerite(int id)
        {
            try
            {
                await _holeriteService.DeleteHolerite(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Tratar o erro conforme necessário
                return StatusCode(500, $"Ocorreu um erro ao deletar o produto com o ID {id}.");
            }
        }
    }
}
