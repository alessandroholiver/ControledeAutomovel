using AutoMapper;
using ControleAluguel.Application.DTO;
using ControleAluguel.Application.Interfaces.Services;
using ControleAluguel.Core.Entites;
using ControleAluguel.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Application.Services
{
   public class MotoristaService: IMotoristaServices
    {
        private readonly IMotoristaRepository _motorista;
        IMapper _mapper;
        public MotoristaService(IMotoristaRepository moto, IMapper mapper)
        {
            _motorista = moto;
            _mapper = mapper;

        }

        public bool AtualizarMotorista(MotoristaDTO veiculo)
        {
            return _motorista.AtualizarMotorista(_mapper.Map<Motorista>(veiculo));
        }

        public MotoristaDTO BuscarMotoristaId(Guid id)
        {
            return _mapper.Map<MotoristaDTO>(_motorista.BuscarMotoristaId(id));
        }

        public Guid CriarMotorista(MotoristaDTO motorista)
        {
            return _motorista.CriarMotorista(_mapper.Map<Motorista>(motorista));
        }

        public bool ExcluirMotorista(Guid id)
        {
            return _motorista.ExcluirMotorista(id);
        }

        public List<MotoristaDTO> ListarMotoristas()
        {
            return _mapper.Map<List<MotoristaDTO>>(_motorista.ListarMotorista());
        }

        public bool ExisteById(Guid id)
        {
            return _motorista.ExisteById(id);
        }
        public bool ExisteByCPF(int CPF)
        {
            return _motorista.ExisteByCPF(CPF);
        }
    }
}
