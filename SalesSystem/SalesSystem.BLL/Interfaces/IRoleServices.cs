using SalesSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.BLL.Interfaces
{
    public interface IRoleServices
    {
        Task<List<Role>> List();
    }
}
