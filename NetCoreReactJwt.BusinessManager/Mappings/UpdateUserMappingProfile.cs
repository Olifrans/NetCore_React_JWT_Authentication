using AutoMapper;
using NetCoreReactJwt.Domain.Entities;
using NetCoreReactJwt.Domain.Shared.ModelViewsDtos.ClientDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReactJwt.BusinessManager.Mappings
{
    public class UpdateUserMappingProfile : Profile
    {
        public UpdateUserMappingProfile()
        {
            CreateMap<UpdateUser, User>()
                .ForMember(d => d.LastUpdateDate, o => o.MapFrom(x => DateTime.Now)); //Adcionando a data de cadastro ao campo DataCadastro
                //.ForMember(d => d.DataNascimentoAluno, o => o.MapFrom(x => x.DataNascimentoAluno.Date)); //Removendo a hora do campo data de nasciment
        }
    }
}
