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
    public class NewUserMappingProfile : Profile
    {
        public NewUserMappingProfile()
        {
            CreateMap<NewUser, User>()
                .ForMember(d => d.DateRegister, o => o.MapFrom(x => DateTime.Now)); //Adcionando a data de cadastro ao campo DataCadastro
                //.ForMember(d => d.DataNascimentoAluno, o => o.MapFrom(x => x.DataNascimentoAluno.Date)); //Removendo a hora do campo data de nascimento

            //CreateMap<NovoAlunoEndereco, Endereco>();
            //CreateMap<NovoTelefone, Telefone>();
        }
    }
}
