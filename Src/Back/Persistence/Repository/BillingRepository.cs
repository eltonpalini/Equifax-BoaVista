using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Persistence.Repository
{
    public class BillingRepository : IBillingRepository
    {
        private readonly Context _context;

        public BillingRepository(Context context)
        {
            _context = context;
        }

        public async Task<IList<Billing>> GetAllAsync()
        {
            return await _context.Billings.ToListAsync();
        }

        public async Task<Billing?> GetByIdAsync(int id)
        {
            return _context.Billings.FirstOrDefault(f => f.Id == id);
        }

        public async Task SaveAsync(Billing billing)
        {
            if (!billing.UpdatedAt.HasValue)
                await _context.Billings.AddAsync(billing);

            await _context.SaveChangesAsync();
        }
    }
}
