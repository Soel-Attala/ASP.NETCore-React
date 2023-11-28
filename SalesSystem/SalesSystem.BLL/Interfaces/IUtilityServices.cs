using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.BLL.Interfaces
{
    public interface IUtilityServices
    {
        string PasswordGenerate();
        string Sha265Convertion(string text);
    }
}
