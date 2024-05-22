using Domain;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<IList<User>> GetAllAsync();
        Task SaveAsync(User user);
    }
}
