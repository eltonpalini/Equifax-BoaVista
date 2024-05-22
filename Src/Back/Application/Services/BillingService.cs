using Application.Interfaces;
using Domain;
using Repository;

namespace Application.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _billingRepository;

        public BillingService(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public async Task AddAsync(Billing billing)
        {
            await _billingRepository.SaveAsync(billing);
        }

        public async Task DeleteAsync(Billing billing)
        {
            billing.Inactivate();
            await _billingRepository.SaveAsync(billing);
        }

        public async Task<IList<Billing>> GetAllAsync()
        {
            return await _billingRepository.GetAllAsync();
        }

        public async Task<Billing?> GetByIdAsync(int id)
        {
            return await (_billingRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(Billing billing)
        {
            billing.UpdatedAt = DateTime.UtcNow;
            await _billingRepository.SaveAsync(billing);
        }
    }
}
