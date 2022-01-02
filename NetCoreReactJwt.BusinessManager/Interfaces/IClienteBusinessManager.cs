using NetCoreReactJwt.Domain.Clientcs;

namespace NetCoreReactJwt.BusinessManager.Interfaces
{
    public interface IClienteBusinessManager
    {
        Task DeleteClientsAsync(int id);
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientsIdAsync(int id);
        Task<Client> InsertClientsAsync(Client client);
        Task<Client> UpdateClientsAsync(Client client);
    }
}
