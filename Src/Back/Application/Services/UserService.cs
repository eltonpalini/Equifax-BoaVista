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

        public async Task<User?> DeleteAsync(int id)
        {
            var _user = await _userRepository.GetByIdAsync(id);

            if (_user == null)
                return default;

            _user.Inactivate();
            await _userRepository.SaveAsync(_user);

            return _user;
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, User user)
        {
            var _user = await _userRepository.GetByIdAsync(id);

            if (_user is null)
                return default;

            _user.Update(user.Login, user.Password);
            await _userRepository.SaveAsync(_user);

            return _user;
        }
    }
}
