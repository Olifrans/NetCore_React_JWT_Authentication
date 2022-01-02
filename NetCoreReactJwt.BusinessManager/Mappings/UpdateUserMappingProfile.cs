using AutoMapper;
using NetCoreReactJwt.Domain.Entities;
using NetCoreReactJwt.Domain.Shared.ModelViewsDtos.AccoutDtos;
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
            CreateMap<UpdateUserModelViews, User>()
                //.ForMember(d => d.DateRegister, o => o.MapFrom(x => DateTime.Now)) //Adcionando a data de cadastro ao campo DataCadastro
                .ForMember(d => d.Password, o => o.MapFrom(x => x.Password))
                .ForMember(d => d.Name, o => o.MapFrom(x => x.Name))
                .ForMember(d => d.Email, o => o.MapFrom(x => x.Email));
        }
    }
}
