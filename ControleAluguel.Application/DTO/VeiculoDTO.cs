using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Application.DTO
{
   public class VeiculoDTO
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }

    }
}
