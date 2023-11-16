using SalesSystem.BLL.Interfaces;
using SalesSystem.DAL.Interfaces;
using SalesSystem.Entity;
using Firebase.Storage;
using Firebase.Auth;
using Firebase.Auth.Providers;

namespace SalesSystem.BLL.Implementations
{
    public class FirebaseServices : IFirebaseServices
    {
        private readonly IGenericRepository<Configuration> _repository;
        public FirebaseServices(IGenericRepository<Configuration> repository)
        {
            _repository = repository;
        }
        public async Task<string> UpdateStorage(Stream streamFile, string destinyFolder, string fileName)
        {
            string UrlImage = "";
            try
            {
                IQueryable<Configuration> query = await _repository.GetAll(c => c.Resource.Equals("FireBase_Storage"));

                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Property, elementSelector: c => c.Value);

                var auth = new FirebaseAuthProvider(new FirebaseConfig(Config["api_key"]));
                var a = await auth.SignInWithEmailAndPasswordAsync(Config["email"], Config["password"]);
                var cancellation = new CancellationTokenSource();
                var task = new FirebaseStorage(
                    Config["path"],
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                .Child(Config[destinyFolder])
                .Child(Config[fileName])
                .PutAsync(streamFile, cancellation.Token);

                UrlImage = await task;
                return UrlImage;
            }
            catch
            {
                return UrlImage = "";
            }
        }
        public async Task<bool> DeleteStorage(string destinyFolder, string fileName)
        {
            try
            {
                IQueryable<Configuration> query = await _repository.GetAll(c => c.Resource.Equals("FireBase_Storage"));

                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Property, elementSelector: c => c.Value);

                var auth = new FirebaseAuthProvider(new FirebaseConfig(Config["api_key"]));
                var a = await auth.SignInWithEmailAndPasswordAsync(Config["email"], Config["password"]);
                var cancellation = new CancellationTokenSource();


                var task = new FirebaseStorage(
                    Config["path"],
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                .Child(Config[destinyFolder])
                .Child(Config[fileName])
                .DeleteAsync();
                await task;
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}








