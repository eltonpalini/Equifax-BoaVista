using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
