using NetCoreReactJwt.BusinessManager.Interfaces;
using NetCoreReactJwt.Domain.Clientcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReactJwt.BusinessManager.Implementation
{
    public class ClienteBusinessManager : IClienteBusinessManager
    {
        private readonly IClientRepository _clientRepository;
        public ClienteBusinessManager(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task DeleteClientsAsync(int id)
        {
            await _clientRepository.DeleteClientsAsync(id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _clientRepository.GetClientsAsync();
        }

        public async Task<Client> GetClientsIdAsync(int id)
        {
            return await _clientRepository.GetClientsIdAsync(id);
        }

        public async Task<Client> InsertClientsAsync(Client client)
        {
            return await _clientRepository.InsertClientsAsync(client);
        }

        public async Task<Client> UpdateClientsAsync(Client client)
        {
            return await _clientRepository.UpdateClientsAsync(client);
        }
    }
}
