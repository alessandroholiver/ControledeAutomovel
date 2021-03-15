using ControleAluguel.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Core.Interfaces.Repository
{
   public interface IVeiculoRepository
    {
        List<Veiculo> ListarVeiculos();
        List<Veiculo> ListarVeiculosByCor(string cor);
        List<Veiculo> ListarVeiculosByMarca(string marca);
        Veiculo BuscarVeiculoId(Guid id);
        bool ExcluirVeiculo(Guid id);
        bool AtualizarVeiculo(Veiculo veiculo);
        Guid CriarVeiculo(Veiculo veiculo);
        bool ExisteById(Guid id);
        bool ExisteByPlaca(string Placa);

    }
}
