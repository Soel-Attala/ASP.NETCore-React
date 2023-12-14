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
                throw new TaskCanceledException("The email already exist");
            }
            try
            {
                string generated_key = _utilityServices.PasswordGenerate();
                entity.Password = _utilityServices.Sha265Convertion(generated_key);
                entity.PhotoName = PictureName;
                if (Picture != null)
                {
                    string urlPicture = await _firebaseServices.UpdateStorage(Picture, "user_folder", PictureName);
                    entity.PhotoUrl = urlPicture;
                }

                UserData created_user = await _repository.Create(entity);
                if (created_user.IdUser == 0)
                {
                    throw new TaskCanceledException("User create error");
                }

                if (UrlMailTemplate != "")
                {
                    UrlMailTemplate = UrlMailTemplate.Replace("[email]", created_user.Email).Replace("[password]", generated_key);
                    string emailhtml = "";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlMailTemplate);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream dataStream = response.GetResponseStream())
                        {
                            StreamReader? readerStream = null;
                            if (response.CharacterSet != null)
                            {
                                readerStream = new StreamReader(dataStream);
                            }
                            else
                            {
                                readerStream = new StreamReader(dataStream, Encoding.GetEncoding(response.CharacterSet));
                            }

                            emailhtml = readerStream.ReadToEnd();
                            response.Close();
                            readerStream.Close();

                        }
                    }

                    if (emailhtml != "")
                    {
                        await _mailServices.SendMail(created_user.Email, "Account created", emailhtml);
                    }
                }

                IQueryable<UserData> query = await _repository.GetAll(u => u.IdUser == created_user.IdUser);
                created_user = query.Include(r => r.IdRoleNavigation).First();

                return created_user;
            }
            catch (Exception ex)
            {
                throw;
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
