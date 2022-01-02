using NetCoreReactJwt.Domain.Entities;
using NetCoreReactJwt.Domain.Shared.ModelViewsDtos.AccoutDtos;

namespace NetCoreReactJwt.BusinessManager.Interfaces
{
    public interface IUserBusinessManager
    {
        Task DeleteUsersAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUsersIdAsync(int id);


        Task<User> InsertUsersAsync(NewUserModelViews newUser);
        Task<User> UpdateUsersAsync(UpdateUserModelViews userUpdate);


        User Create(User users);
        //User Create(NewUserModelViews newUserModel);
    }
}
