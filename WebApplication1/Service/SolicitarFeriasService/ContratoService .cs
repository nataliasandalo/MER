using Api.Servico.Interface.IRepository;
using Api.Servico.Interface.IRepository.IContratoRepository;
using Api.Servico.Interface.IService.IContratoService;
using Api.Servico.Interface.IService.ISolicitarFeriasService;
using Api.Servico.Interface.IUnitOfWork;
using Api.Servico.Models;

namespace Api.Servico.Service.SolicitarFeriasService
{
    public class ContratoService : IContratoHttpService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TbContrato> _contratoRepository;

        public ContratoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _contratoRepository = _unitOfWork.GetRepository<TbContrato>();
        }

        public void AddContrato(TbContrato portal)
        {
            _contratoRepository.Add(portal);
            _unitOfWork.SaveChanges();
        }

        public void DeleteContrato(TbContrato portal)
        {
            _contratoRepository.Delete(portal);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<TbContrato> GetContrato()
        {
            return _contratoRepository.GetAll();
        }

        public TbContrato GetContratoById(int id)
        {
            return _contratoRepository.GetById(id);
        }

        public void UpdateContrato(TbContrato portal)
        {
            _contratoRepository.Update(portal);
            _unitOfWork.SaveChanges();
        }
    }
}
