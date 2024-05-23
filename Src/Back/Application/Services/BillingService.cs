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

        public async Task<Billing?> DeleteAsync(int id)
        {
            var _billing = await _billingRepository.GetByIdAsync(id);

            if (_billing is null)
                return default;
            
            _billing.Inactivate();
            await _billingRepository.SaveAsync(_billing);

            return _billing;
        }

        public async Task<IList<Billing>> GetAllAsync()
        {
            return await _billingRepository.GetAllAsync();
        }

        public async Task<Billing?> GetByIdAsync(int id)
        {
            return await (_billingRepository.GetByIdAsync(id));
        }

        public async Task<Billing?> UpdateAsync(int id, Billing billing)
        {
            var _billing = await _billingRepository.GetByIdAsync(id);

            if (_billing is null)
                return default;

            _billing.Update(billing.StudentId, billing.CourseId, billing.PaymentTypeId, billing.Amount);
            await _billingRepository.SaveAsync(billing);
            
            return _billing;
        }
    }
}
