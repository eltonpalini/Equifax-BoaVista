using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task SaveAsync(User user)
        {
            if (!user.UpdatedAt.HasValue)
                await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }
    }
}
