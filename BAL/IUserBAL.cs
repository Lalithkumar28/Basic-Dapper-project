using api_task.Model;

namespace api_task.BAL
{
    public interface IUserBAL
    {
         Task<List<UserModel>> Create(UserModel values);
         Task<List<UserModel>> Update(UserModel values);
         
    }
}