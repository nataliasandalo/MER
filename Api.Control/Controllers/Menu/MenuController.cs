using Api.Control.Interface.IMenuService;
using Api.Control.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Control.Controllers.Menu
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public IActionResult GetMenus()
        {
            var menus = _menuService.GetMenus();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuById(int id)
        {
            var menu = _menuService.GetMenuById(id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        [HttpPost]
        public IActionResult AddMenu([FromBody] TbMenu menu)
        {
            try
            {
                _menuService.AddMenu(menu);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenu(int id, [FromBody] TbMenu menu)
        {
            if (id != menu.IdMenu)
            {
                return BadRequest();
            }

            try
            {
                _menuService.UpdateMenu(menu);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(int id, [FromBody] TbMenu menu)
        {
            try
            {
                _menuService.DeleteMenu(menu);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("portal/{portalId}")]
        public IActionResult GetMenusByPortalId(int portalId)
        {
            try
            {
                var menus = _menuService.GetMenusByPortalId(portalId);
                return Ok(menus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
