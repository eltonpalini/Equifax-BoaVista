using Domain;

namespace Repository
{
    public interface IBillingRepository
    {
        Task<Billing?> GetByIdAsync(int id);
        Task<IList<Billing>> GetAllAsync();
        Task SaveAsync(Billing billing);
    }
}
