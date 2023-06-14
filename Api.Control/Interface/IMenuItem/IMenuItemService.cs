using Api.Control.Models;

namespace Api.Control.Interface.IMenuItem
{
    public interface IMenuItemService
    {
        IEnumerable<TbMenuItem> GetMenuItem();
        TbMenuItem GetMenuItemById(int id);
        IEnumerable<TbMenuItem> GetMenuItemByMenuId(int portalId);
        void AddMenuItem(TbMenuItem menu);
        void UpdateMenuItem(TbMenuItem menu);
        void DeleteMenuItem(TbMenuItem menu);
        void Dispose();
    }
}
