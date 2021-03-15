using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Core.Entites
{
   public class Veiculo
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
    }
}
