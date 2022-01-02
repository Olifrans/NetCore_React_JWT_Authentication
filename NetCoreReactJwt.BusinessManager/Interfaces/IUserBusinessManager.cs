using NetCoreReactJwt.Domain.Entities;
using NetCoreReactJwt.Domain.Shared.ModelViewsDtos.ClientDtos;

namespace NetCoreReactJwt.BusinessManager.Interfaces
{
    public interface IUserBusinessManager
    {
        Task DeleteUsersAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUsersIdAsync(int id);
        Task<User> InsertUsersAsync(NewUser newUser);
        Task<User> UpdateUsersAsync(UpdateUser userUpdate);


        User CreateUser(User create);
    }
}
