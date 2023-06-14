using Api.Control.Models;

namespace Api.Control.Interface.IPortalService
{
    public interface IPortalService
    {
        IEnumerable<TbPortal> GetPortals();
        TbPortal GetPortalById(int id);
        void AddPortal(TbPortal portal);
        void UpdatePortal(TbPortal portal);
        void DeletePortal(TbPortal portal);
        IEnumerable<TbMenu> GetMenusByPortalId(int portalId);
    }
}
