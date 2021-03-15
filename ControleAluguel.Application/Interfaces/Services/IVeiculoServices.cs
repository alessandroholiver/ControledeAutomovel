using ControleAluguel.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Application.Interfaces.Services
{
    public interface IVeiculoServices
    {
        List<VeiculoDTO> ListarVeiculos();
        List<VeiculoDTO> ListarVeiculosByCor(string cor);
        List<VeiculoDTO> ListarVeiculosByMarca(string marca);
        VeiculoDTO BuscarVeiculoId(Guid id);
        bool ExcluirVeiculo(Guid id);
        bool AtualizarVeiculo(VeiculoDTO veiculo);
        Guid CriarVeiculo(VeiculoDTO veiculo);
        bool ExisteById(Guid id);
        bool ExisteByPlaca(string Placa);
    }
}
