using Api.Control.Interface.IPortalService;
using Api.Control.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Control.Controllers.Portal
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortalController : ControllerBase
    {
        private readonly IPortalService _portalService;
        public PortalController(IPortalService portalService)
        {
            _portalService = portalService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbPortal>> GetPortals()
        {
            var portals = _portalService.GetPortals();
            return Ok(portals);
        }

        [HttpGet("{id}")]
        public ActionResult<TbPortal> GetPortalById(int id)
        {
            var portal = _portalService.GetPortalById(id);

            if (portal == null)
            {
                return NotFound();
            }

            return Ok(portal);
        }

        [HttpPost]
        public ActionResult<TbPortal> AddPortal(TbPortal portal)
        {
            _portalService.AddPortal(portal);
            return CreatedAtAction(nameof(GetPortalById), new { id = portal.IdPortal }, portal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePortal(int id, TbPortal portal)
        {
            if (id != portal.IdPortal)
            {
                return BadRequest();
            }

            _portalService.UpdatePortal(portal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePortal(int id)
        {
            var aux = new TbPortal() { 

                IdPortal = id
            };

            _portalService.DeletePortal(aux);

            return NoContent();
        }

        [HttpGet("{id}/menus")]
        public ActionResult<IEnumerable<TbMenu>> GetMenusByPortalId(int id)
        {
            var menus = _portalService.GetMenusByPortalId(id);

            if (menus == null)
            {
                return NotFound();
            }

            return Ok(menus);
        }
    }
}
