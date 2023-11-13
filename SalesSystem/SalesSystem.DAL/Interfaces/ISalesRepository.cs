using SalesSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.DAL.Interfaces
{
    public interface ISalesRepository : IGenericRepository<Sale>
    {
        Task<Sale> Register(Sale entity);
        Task<List<SaleDetail>> Report(DateTime StartDate, DateTime EndDate);

    }
}
