using Microsoft.EntityFrameworkCore;
using SalesSystem.DAL.DBContext;
using SalesSystem.DAL.Interfaces;
using SalesSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.DAL.Implementations
{

    public class SalesRepository : GenericRepository<Sale>, ISalesRepository
    {
        private readonly SALESDBContext _dbContext;
        public SalesRepository(SALESDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Sale> Register(Sale entity)
        {
            Sale generatedSale = new Sale();
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (SaleDetail detail in entity.SaleDetails)
                    {
                        Product find_product = _dbContext.Products.Where(p => p.IdProduct == detail.IdProduct).First();
                        find_product.Stock = find_product.Stock - detail.Quantity;
                        _dbContext.Products.Update(find_product);
                    }
                    await _dbContext.SaveChangesAsync();


                    CorrelativeNumber correlativeNumber = _dbContext.CorrelativeNumbers.Where(n => n.Management == "sale").First();
                    correlativeNumber.LastNumber = correlativeNumber.LastNumber + 1;
                    correlativeNumber.UpdateDate = DateTime.Now;
                    _dbContext.CorrelativeNumbers.Update(correlativeNumber);
                    await _dbContext.SaveChangesAsync();


                    string ceros = string.Concat(Enumerable.Repeat("0", correlativeNumber.DigitCount.Value));
                    string saleNumber = ceros + correlativeNumber.LastNumber.ToString();
                    saleNumber = saleNumber.Substring(saleNumber.Length - correlativeNumber.DigitCount.Value, correlativeNumber.DigitCount.Value);
                    entity.SaleNumber = saleNumber;

                    await _dbContext.Sales.AddAsync(entity);
                    await _dbContext.SaveChangesAsync();

                    generatedSale = entity;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                return generatedSale;
            }
        }

        public async Task<List<SaleDetail>> Report(DateTime StartDate, DateTime EndDate)
        {
            List<SaleDetail> resumeList = await _dbContext.SaleDetails
                .Include(s => s.IdSaleNavigation)
                .ThenInclude(u => u.IdUserNavigation)
                .Include(s => s.IdSaleNavigation)
                .ThenInclude(sdt => sdt.IdSalesDocumentType)
                .Where(sd => sd.IdSaleNavigation.RegistrationDate.Value.Date >= StartDate.Date &&
                sd.IdSaleNavigation.RegistrationDate.Value.Date <= EndDate.Date).ToListAsync();

            return resumeList;
        }
    }
}
