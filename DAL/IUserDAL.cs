using System.Data.SqlClient;
using api_task.Model;

namespace api_task.DAL
{
    public interface IUserDAL
    {
     
         Task<List<UserModel>> CreateValue(UserModel values);
         Task<List<UserModel>> UpdateValue(UserModel change);
       
    }
}