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
    public class VeiculoServices: IVeiculoServices
    {
        IVeiculoRepository _veiculo;
        IMapper _mapper;
        public VeiculoServices(IVeiculoRepository veiculo, IMapper mapper)
        {
            _veiculo = veiculo;
            _mapper = mapper;

        }

        public bool AtualizarVeiculo(VeiculoDTO veiculo)
        {
            return _veiculo.AtualizarVeiculo(_mapper.Map<Veiculo>(veiculo));
        }

        public VeiculoDTO BuscarVeiculoId(Guid id)
        {
            return _mapper.Map<VeiculoDTO>(_veiculo.BuscarVeiculoId(id));
        }

        public Guid CriarVeiculo(VeiculoDTO veiculo)
        {
            return _veiculo.CriarVeiculo(_mapper.Map<Veiculo>(veiculo));
        }

        public bool ExcluirVeiculo(Guid id)
        {
            return _veiculo.ExcluirVeiculo(id);
        }

        public List<VeiculoDTO> ListarVeiculos()
        {
            return _mapper.Map<List<VeiculoDTO>>(_veiculo.ListarVeiculos());
        }

        public List<VeiculoDTO> ListarVeiculosByCor(string cor)
        {
            return _mapper.Map<List<VeiculoDTO>>(_veiculo.ListarVeiculosByCor(cor));
        }

        public List<VeiculoDTO> ListarVeiculosByMarca(string marca)
        {
            return _mapper.Map<List<VeiculoDTO>>(_veiculo.ListarVeiculosByMarca(marca));
        }
        public bool ExisteById(Guid id)
        {
            return _veiculo.ExisteById(id);
        }
        public bool ExisteByPlaca(string Placa)
        {
            return _veiculo.ExisteByPlaca(Placa);
        }
    }
}

