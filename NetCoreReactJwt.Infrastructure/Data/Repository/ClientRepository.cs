using Microsoft.EntityFrameworkCore;
using NetCoreReactJwt.BusinessManager.Interfaces;
using NetCoreReactJwt.Domain.Clientcs;

namespace NetCoreReactJwt.Infrastructure.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ContextDBConexao _context;
        public ClientRepository(ContextDBConexao context)
        {
            this._context = context;
        }

        public async Task DeleteClientsAsync(int id)
        {
            var clientConsult = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(clientConsult);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();  //AsNoTracking ganho de perfomace
        }

        public async Task<Client> GetClientsIdAsync(int id)
        {
            return await _context.Clients
                .SingleOrDefaultAsync(c => c.Id == id); //select top dois no BD
                 //return await _gestaoEscolar.Alunos.FindAsync(id); //FindAsync ganho de perfomace, porém não permite fazer Join na base de dados
        }

        public async Task<Client> InsertClientsAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClientsAsync(Client client)
        {
            var clientConsult = await _context.Clients.FindAsync(client.Id);
            if (clientConsult == null)
            {
                return null; //Not Found
            }
            _context.Entry(clientConsult).CurrentValues.SetValues(client);
            //_context.Clients.Update(clientConsult);
            await _context.SaveChangesAsync();
            return clientConsult;
        }
    }
}
