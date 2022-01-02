using NetCoreReactJwt.Domain.Entities;

namespace NetCoreReactJwt.BusinessManager.Interfaces
{
    public interface IUserRepository
    {
        Task DeleteUsersAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUsersIdAsync(int id);

        Task<User> InsertUsersAsync(User user);
        Task<User> UpdateUsersAsync(User user);


        User Create(User users);

    }
}
