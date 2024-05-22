using Domain;

namespace Application.Interfaces
{
    public  interface IBillingService
    {
        Task AddAsync(Billing billing);
        Task UpdateAsync(Billing billing);
        Task DeleteAsync(Billing billing);
        Task<IList<Billing>> GetAllAsync();
        Task<Billing?> GetByIdAsync(int id);
    }
}
