using Api.Control.Models;

namespace Api.Control.Interface.IMenuService
{
    public interface IMenuService
    {
        IEnumerable<TbMenu> GetMenus();
        TbMenu GetMenuById(int id);
        IEnumerable<TbMenu> GetMenusByPortalId(int portalId);
        void AddMenu(TbMenu menu);
        void UpdateMenu(TbMenu menu);
        void DeleteMenu(TbMenu menu);
        void Dispose();
    }
}
