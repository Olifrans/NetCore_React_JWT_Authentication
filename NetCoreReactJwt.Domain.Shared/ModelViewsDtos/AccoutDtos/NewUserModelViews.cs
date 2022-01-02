using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReactJwt.Domain.Shared.ModelViewsDtos.AccoutDtos
{
    /// <summary>
    /// Objeto utilizado para inserção de um novo usuario.
    /// </summary>
    public class NewUserModelViews
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
    }
}
