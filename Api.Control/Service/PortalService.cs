using Api.Control.Interface.IPortalService;
using Api.Control.Interface.IRepository;
using Api.Control.Interface.IUnitOfWork;
using Api.Control.Models;

namespace Api.Control.Service
{
    public class PortalService : IPortalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TbPortal> _portalRepository;
        private readonly IRepository<TbMenu> _menuRepository;

        public PortalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _portalRepository = _unitOfWork.GetRepository<TbPortal>();
            _menuRepository = _unitOfWork.GetRepository<TbMenu>();
        }

        public IEnumerable<TbPortal> GetPortals()
        {
            return _portalRepository.GetAll();
        }

        public TbPortal GetPortalById(int id)
        {
            return _portalRepository.GetById(id);
        }

        public void AddPortal(TbPortal portal)
        {
            _portalRepository.Add(portal);
            _unitOfWork.SaveChanges();
        }

        public void UpdatePortal(TbPortal portal)
        {
            _portalRepository.Update(portal);
            _unitOfWork.SaveChanges();
        }

        public void DeletePortal(TbPortal portal)
        {
            _portalRepository.Delete(portal);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<TbMenu> GetMenusByPortalId(int portalId)
        {
            return _menuRepository.Find(x => x.IdPortal == portalId);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }

}
