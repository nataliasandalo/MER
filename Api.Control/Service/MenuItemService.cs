using Api.Control.Interface.IMenuItem;
using Api.Control.Interface.IRepository;
using Api.Control.Interface.IUnitOfWork;
using Api.Control.Models;

namespace Api.Control.Service
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TbMenuItem> _menuItemRepository;
        private readonly IRepository<TbMenu> _menuRepository;

        public MenuItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _menuItemRepository = _unitOfWork.GetRepository<TbMenuItem>();
            _menuRepository = _unitOfWork.GetRepository<TbMenu>();
        }

        public IEnumerable<TbMenuItem> GetMenuItem()
        {
            return _menuItemRepository.GetAll();
        }

        public TbMenuItem GetMenuItemById(int id)
        {
            return _menuItemRepository.GetById(id);
        }

        public void AddMenuItem(TbMenuItem menuItem)
        {
            _menuItemRepository.Add(menuItem);
            _unitOfWork.SaveChanges();
        }

        public void UpdateMenuItem(TbMenuItem menuItem)
        {
            _menuItemRepository.Update(menuItem);
            _unitOfWork.SaveChanges();
        }

        public void DeleteMenuItem(TbMenuItem menuItem)
        {
            _menuItemRepository.Delete(menuItem);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<TbMenuItem> GetMenuItemByMenuId(int menuId)
        {
            var portal = _menuRepository.GetById(menuId);

            if (portal == null)
            {
                throw new Exception("Portal not found.");
            }

            var menus = _menuItemRepository.GetAll().Where(x => x.IdMenu == menuId).ToList();
            return menus;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
