using Api.Control.Interface.IMenuItem;
using Api.Control.Interface.IMenuService;
using Api.Control.Models;
using Api.Control.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Control.Controllers.MenuItem
{
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet]
        public IActionResult GetItemMenus()
        {
            var menus = _menuItemService.GetMenuItem();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuById(int id)
        {
            var menu = _menuItemService.GetMenuItemById(id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        [HttpPost]
        public IActionResult AddMenuItem([FromBody] TbMenuItem menuItem)
        {
            try
            {
                _menuItemService.AddMenuItem(menuItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenuItem(int id, [FromBody] TbMenuItem menuItem)
        {
            if (id != menuItem.IdItem)
            {
                return BadRequest();
            }

            try
            {
                _menuItemService.UpdateMenuItem(menuItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItem(int id, [FromBody] TbMenuItem menuItem)
        {
            try
            {
                _menuItemService.DeleteMenuItem(menuItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("menuitem/{menuId}")]
        public IActionResult GetMenuItemByMenuId(int menuId)
        {
            try
            {
                var menus = _menuItemService.GetMenuItemByMenuId(menuId);
                return Ok(menus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
