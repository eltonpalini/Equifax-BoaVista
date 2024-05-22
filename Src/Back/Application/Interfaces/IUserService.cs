using Domain;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<IList<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
    }
}
