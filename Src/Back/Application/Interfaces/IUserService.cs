using Domain;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(User user);
        Task<User?> UpdateAsync(int id, User user);
        Task<User?> DeleteAsync(int id);
        Task<IList<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
    }
}
