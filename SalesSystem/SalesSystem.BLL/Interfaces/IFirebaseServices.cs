using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.BLL.Interfaces
{
    public interface IFirebaseServices
    {
        Task<string> UpdateStorage(Stream streamFile, string destinyFolder, string fileName);
        Task<bool> DeleteStorage(string destinyFolder, string fileName);
    }
}
