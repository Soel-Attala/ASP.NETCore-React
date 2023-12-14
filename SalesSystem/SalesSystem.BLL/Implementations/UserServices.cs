using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Net;
using SalesSystem.BLL.Interfaces;
using SalesSystem.DAL.Interfaces;
using SalesSystem.Entity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesSystem.BLL.Implementations
{
    public class UserServices : IUserServices
    {
        private readonly IGenericRepository<UserData> _repository;
        private readonly IFirebaseServices _firebaseServices;
        private readonly IUtilityServices _utilityServices;
        private readonly IMailServices _mailServices;

        public UserServices(IGenericRepository<UserData> repository,
            IFirebaseServices firebaseServices,
            IUtilityServices utilityServices,
            IMailServices mailServices)
        {
            _repository = repository;
            _firebaseServices = firebaseServices;
            _utilityServices = utilityServices;
            _mailServices = mailServices;
        }



        public async Task<List<UserData>> List()
        {
            IQueryable<UserData> query = await _repository.GetAll();
            return query.Include(r => r.IdRoleNavigation).ToList();
        }

        public async Task<UserData> Create(UserData entity, Stream Picture = null, string PictureName = "", string UrlMailTemplate = "")
        {
            UserData userExist = await _repository.Get(u => u.Email == entity.Email);
            if (userExist == null)
            {

            }
        }
        public Task<UserData> Edit(UserData entity, Stream Picture = null, string PictureName = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int IdUser)
        {
            throw new NotImplementedException();
        }

        public Task<UserData> GetByCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserData> GetById(int IdUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveProfile(UserData entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangePassword(int IdUser, string ActualPassword, string NewPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPassword(string Email, string UrlMailTemplate)
        {
            throw new NotImplementedException();
        }


    }
}
