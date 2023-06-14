using Api.Servico.Interface.IRepository;
using Api.Servico.Interface.IService.IStatusService;
using Api.Servico.Interface.IUnitOfWork;
using Api.Servico.Models;

namespace Api.Servico.Service.StatusService
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TbStatus> _statusRepository;

        public StatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _statusRepository = _unitOfWork.GetRepository<TbStatus>();
        }

        public void AddStatus(TbStatus portal)
        {
            _statusRepository.Add(portal);
            _unitOfWork.SaveChanges();
        }

        public void DeleteStatus(TbStatus portal)
        {
            _statusRepository.Delete(portal);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<TbStatus> GetStatus()
        {
            return _statusRepository.GetAll();
        }

        public TbStatus GetStatusById(int id)
        {
            return _statusRepository.GetById(id);
        }

        public void UpdateStatus(TbStatus portal)
        {
            _statusRepository.Update(portal);
            _unitOfWork.SaveChanges();
        }
    }
}
