using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReactJwt.Domain.Shared.ModelViewsDtos.ClientDtos
{
    /// <summary>
    /// Objeto utilizado para inserção de um novo usuario.
    /// </summary>
    public class NewUser
    {
        /// <summary>
        /// Nome do usuario
        /// </summary>
        /// <example>Olifrans</example>
        public string Name { get; set; }

       
        /// <summary>
        /// Senha do usuario
        /// </summary>
        /// <example>peT24@cF</example>
        public string Password { get; set; }

        

        /// <summary>
        /// Email do usuario
        /// </summary>
        /// <example>olifrans@gmail.com</example>
        public string Email { get; set; }



        /// <summary>
        /// Data de cadastro do Usuario
        /// </summary>
        /// <example>1979-02-16</example>
        public DateTime DateRegister { get; set; } = DateTime.Now;


        /// <summary>
        /// Data da última atualização do Usuario
        /// </summary>
        /// <example>1979-02-16</example>
        public DateTime LastUpdateDate { get; set; }



        public bool IsAtivo { get; set; }
    }
}
