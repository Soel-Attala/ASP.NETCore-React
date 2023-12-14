using SalesSystem.BLL.Interfaces;
using SalesSystem.DAL.Interfaces;
using SalesSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.BLL.Implementations
{
    public class RoleServices : IRoleServices
    {
        private readonly IGenericRepository<Role> _repository;

        public RoleServices(IGenericRepository<Role> repository)
        {
            _repository = repository;
        }


        public async Task<List<Role>> List()
        {
            IQueryable<Role> query = await _repository.GetAll();
            return query.ToList();
        }
    }
}
