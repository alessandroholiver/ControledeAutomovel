using ControleAluguel.Core.Entites;
using ControleAluguel.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleAluguel.Infrastructure.Data
{
    public class VeiculoQuery: IVeiculoRepository
    {

        List<Veiculo> veiculoList;
        public VeiculoQuery()
        {
            veiculoList = new List<Veiculo>();
        }

        public Guid CriarVeiculo(Veiculo veiculoNovo)
        {
            var veiculo = new Veiculo
            {
                Id = Guid.NewGuid(),
                Marca = veiculoNovo.Marca,
                Placa = veiculoNovo.Placa,
                Cor = veiculoNovo.Cor
            };

            veiculoList.Add(veiculo);
            return veiculo.Id;
        }

        public bool AtualizarVeiculo(Veiculo veiculo)
        {
            foreach (var item in veiculoList)
            {
                if (item.Placa == veiculo.Placa)
                {
                    item.Placa = veiculo.Placa;
                    item.Cor = veiculo.Cor;
                    item.Marca = veiculo.Marca;
                    return true;
                }
            }
            return false;
        }

        public bool ExcluirVeiculo(Guid id)
        {
            veiculoList.Remove(BuscarVeiculoId(id));
            return true;
        }

        public Veiculo BuscarVeiculoId(Guid id)
        {
            return veiculoList.Find(c => c.Id == id);
        }

        public List<Veiculo> ListarVeiculos()
        {
            var veiculo1 = new Veiculo
            {
                Id = new Guid("{3fa85f64-5717-4562-b3fc-2c963f66afa3}"),
                Cor = "Branco",
                Marca = "Volks",
                Placa = "JYK0090"
            };

            var veiculo = new Veiculo
            {
                Id = new Guid("{3fa85f64-5717-4562-b3fc-2c963f66afa0}"),
                Cor = "Vermelho",
                Marca = "Viat",
                Placa = "BRR2342"
            };

            var veiculo2 = new Veiculo
            {
                Cor = "Preto",
                Marca = "Titanum",
                Placa = "KFS8764"

            };

            var veiculo3 = new Veiculo
            {
                Id = new Guid("{3fa85f64-5718-4562-b3fc-2c963f66afa8}"),
                Cor = "Branco",
                Marca = "Viat",
                Placa = "QQJ9293"
            };

            var veiculo4 = new Veiculo
            {
                Id = new Guid("{3fa85f64-5717-4562-b3fc-2c963f66afa0}"),
                Cor= "Preto",
                Marca = "Volks",
                Placa = "JJK0090"
            };
            veiculoList.Add(veiculo1);
            veiculoList.Add(veiculo);
            veiculoList.Add(veiculo2);
            veiculoList.Add(veiculo3);
            veiculoList.Add(veiculo4);

            return veiculoList;
        }

        public bool ExisteById(Guid id)
        {

            return veiculoList.Exists(c => c.Id == id);
        }

        public bool ExisteByPlaca(string Placa)
        {

            return veiculoList.Exists(c => c.Placa == Placa);
        }

        public List<Veiculo> ListarVeiculosByCor(string cor)
        {
            return veiculoList.FindAll(c => c.Cor == cor).ToList();
        }
        public List<Veiculo> ListarVeiculosByMarca(string marca)
        {
            return veiculoList.FindAll(c => c.Marca == marca).ToList();
        }

        
    }
}
