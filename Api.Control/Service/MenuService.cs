using Api.Control.Interface.IMenuService;
using Api.Control.Interface.IRepository;
using Api.Control.Interface.IUnitOfWork;
using Api.Control.Models;

namespace Api.Control.Service
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TbMenu> _menuRepository;
        private readonly IRepository<TbPortal> _portalRepository;

        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _menuRepository = _unitOfWork.GetRepository<TbMenu>();
            _portalRepository = _unitOfWork.GetRepository<TbPortal>();
        }

        public IEnumerable<TbMenu> GetMenus()
        {
            return _menuRepository.GetAll();
        }

        public TbMenu GetMenuById(int id)
        {
            return _menuRepository.GetById(id);
        }

        public void AddMenu(TbMenu menu)
        {
            _menuRepository.Add(menu);
            _unitOfWork.SaveChanges();
        }

        public void UpdateMenu(TbMenu menu)
        {
            _menuRepository.Update(menu);
            _unitOfWork.SaveChanges();
        }

        public void DeleteMenu(TbMenu menu)
        {
            _menuRepository.Delete(menu);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<TbMenu> GetMenusByPortalId(int portalId)
        {
            var portal = _portalRepository.GetById(portalId);

            if (portal == null)
            {
                throw new Exception("Portal not found.");
            }

            var menus = _menuRepository.GetAll().Where(x => x.IdPortal == portalId).ToList();
            return menus;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
