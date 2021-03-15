using AutoMapper;
using ControleAluguel.Application.DTO;
using CoreEntity = ControleAluguel.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleAluguel.Application.Mapper
{
   public class Mapping:Profile
    {

        public Mapping()
        {
            CreateMap<RegistroDTO,CoreEntity.Registro>().ReverseMap();
            CreateMap<VeiculoDTO,CoreEntity.Veiculo>().ReverseMap();
            CreateMap<MotoristaDTO, CoreEntity.Motorista>().ReverseMap();
           
        }
      


    }
}
