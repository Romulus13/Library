using Library_BL.Model;

namespace Library_BL.Interfaces
{
    public interface IUserService
    {
       public Task<UserModel> Get(int id);

      public Task<List<UserModel>> GetAll();

        public Task<UserModel> Create(UserModel userModel);
        public Task<UserModel> Update(UserModel model);

        public Task Delete(int id);
    }
}
