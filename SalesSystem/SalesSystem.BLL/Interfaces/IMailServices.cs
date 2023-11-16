using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.BLL.Interfaces
{
    public interface IMailServices
    {
        Task<bool> SendMail(string MailDestiny, string About, string Message);

    }
}
