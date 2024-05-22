using Application.Interfaces;
using Domain;
using Repository;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(User user)
        {
            await _userRepository.SaveAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            user.Inactivate();
            await _userRepository.SaveAsync(user);
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            user.UpdatedAt = DateTime.UtcNow;
            await _userRepository.SaveAsync(user);
        }
    }
}
