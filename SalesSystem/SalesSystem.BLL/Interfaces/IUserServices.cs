using SalesSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.BLL.Interfaces
{
    public interface IUserServices
    {
        Task<List<UserData>> List();
        Task<UserData> Create(UserData entity, Stream Picture = null, String PictureName = "", string UrlMailTemplate = "");
        Task<UserData> Edit(UserData entity, Stream Picture = null, String PictureName = "");
        Task<bool> Delete(int IdUser);
        Task<UserData> GetByCredentials(string email, string password);
        Task<UserData> GetById(int IdUser);
        Task<bool> SaveProfile(UserData entity);
        Task<bool> ChangePassword(int IdUser, string ActualPassword, string NewPassword);
        Task<bool> ResetPassword(string Email, string UrlMailTemplate);

    }
}
