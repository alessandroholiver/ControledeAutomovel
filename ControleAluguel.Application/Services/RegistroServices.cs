using AutoMapper;
using ControleAluguel.Application.DTO;
using ControleAluguel.Application.Interfaces.Services;
using ControleAluguel.Core.Entites;
using ControleAluguel.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace ControleAluguel.Application.Services
{
    public class RegistroServices: IRegistroServices
    {

        IRegistroRepository _regRepos;
        IVeiculoRepository _veiculoRepos;
        IMotoristaRepository _motoRepos;
        IMapper _mapper;
        public RegistroServices(IMapper mapper, IRegistroRepository reg,
            IMotoristaRepository moto, IVeiculoRepository vei)
        {
            _regRepos = reg;
            _mapper = mapper;
            _veiculoRepos = vei;
            _motoRepos = moto;

        }

        public RegistroDTO BuscarRegistroById(Guid id)
        {
            return _mapper.Map<RegistroDTO>(_regRepos.BuscarRegistroById(id));
        }

        public int CriarRegistro(RegistroDTO reg)
        {
            var veiculo = _veiculoRepos.BuscarVeiculoId(reg.IdVeiculo);
            if (veiculo == null)
            {  return 2; }
            var motorista = _motoRepos.BuscarMotoristaId(reg.IdMotorista); 
            if (motorista == null)
            { return 1; }

            var existe = _regRepos.ExisteRegistroAtivo(_mapper.Map<Registro>(reg));
            if (existe)
            {
                return 3;
            }

             _regRepos.CriarRegistro(_mapper.Map<Registro>(reg));

            return 0;
        }

        public bool ExisteRegistroById(Guid id)
        {
           return _regRepos.ExisteRegistroById(id);
        }

        public bool FinalizarRegistro(Guid id)
        {
            var existe = _regRepos.ExisteRegistroById(id);
            if (existe)
            {
                _regRepos.FinalizarRegistro(id);
                return true;
            }

            return false;
        }

        public List<RegistroDTO> ListRegistroAtivos()
        {
            return _mapper.Map<List<RegistroDTO>>(_regRepos.ListRegistroAtivos());
        }

      
    }
}
