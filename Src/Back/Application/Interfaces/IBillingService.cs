using Domain;

namespace Application.Interfaces
{
    public  interface IBillingService
    {
        Task AddAsync(Billing billing);
        Task<Billing?> UpdateAsync(int id, Billing billing);
        Task<Billing?> DeleteAsync(int id);
        Task<IList<Billing>> GetAllAsync();
        Task<Billing?> GetByIdAsync(int id);
    }
}
