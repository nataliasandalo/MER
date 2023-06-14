using Api.Servico.Interface.IRepository;
using Api.Servico.Interface.IService.ISolicitarFeriasService;
using Api.Servico.Interface.IUnitOfWork;
using Api.Servico.Models;

namespace Api.Servico.Service.SolicitarFeriasService
{
    public class SolicitarFeriasService : ISolicitarFeriasService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TbSolicitarFerias> _solicitarFeriasRepository;

        public SolicitarFeriasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _solicitarFeriasRepository = _unitOfWork.GetRepository<TbSolicitarFerias>();
        }

        public void AddSolicitarFerias(TbSolicitarFerias portal)
        {
            _solicitarFeriasRepository.Add(portal);
            _unitOfWork.SaveChanges();
        }

        public void DeleteSolicitarFerias(TbSolicitarFerias portal)
        {
            _solicitarFeriasRepository.Delete(portal);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<TbSolicitarFerias> GetSolicitarFerias()
        {
            return _solicitarFeriasRepository.GetAll();
        }

        public TbSolicitarFerias GetSolicitarFeriasById(int id)
        {
            return _solicitarFeriasRepository.GetById(id);
        }

        public void UpdateSolicitarFerias(TbSolicitarFerias portal)
        {
            _solicitarFeriasRepository.Update(portal);
            _unitOfWork.SaveChanges();
        }
    }
}
