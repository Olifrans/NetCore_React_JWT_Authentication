using Microsoft.EntityFrameworkCore;
using NetCoreReactJwt.BusinessManager.Interfaces;
using NetCoreReactJwt.Domain.Entities;

namespace NetCoreReactJwt.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDBConexao _context;

        public UserRepository(ContextDBConexao context)
        {
            this._context = context;
        }

        public User Create(User create)
        {
            _context.Users.Add(create);
            create.Id = _context.SaveChanges();
            return create;
        }




        public async Task DeleteUsersAsync(int id)
        {
            var authConsult = await _context.Users.FindAsync(id);
            _context.Users.Remove(authConsult);
            await _context.SaveChangesAsync();
        }

       public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();  //AsNoTracking ganho de perfomace
        }


       public async Task<User> GetUsersIdAsync(int id)
        {
            return await _context.Users
               .SingleOrDefaultAsync(c => c.Id == id); //select top dois no BD
                //return await _gestaoEscolar.Alunos.FindAsync(id); //FindAsync ganho de perfomace, porém não permite fazer Join na base de dados
        }

       public async Task<User> InsertUsersAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

       public async Task<User> UpdateUsersAsync(User user)
        {
            var userConsult = await _context.Users.FindAsync(user.Id);
            if (userConsult == null)
            {
                return null; //Not Found
            }
            _context.Entry(userConsult).CurrentValues.SetValues(user);
            //_context.Authrs.Update(alunoConsultado);
            await _context.SaveChangesAsync();
            return userConsult;
        }

        
    }
}
