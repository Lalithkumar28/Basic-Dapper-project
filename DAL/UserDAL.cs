using System.Data.SqlClient;
using api_task.Model;
using Dapper;
namespace api_task.DAL
{
    public class UserDAL:IUserDAL
    {
        private readonly IConfiguration _config;

        public UserDAL(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<UserModel>> CreateValue(UserModel values)
        {
             using var connection= new SqlConnection(_config.GetConnectionString("TodoConnectionString"));
             await connection.ExecuteAsync("insert into UserData(name) values(@name)",values);
             return(await SelectAllValue(connection)).ToList();
        }
        public async Task<List<UserModel>> UpdateValue(UserModel change)
        {
             using var connection= new SqlConnection(_config.GetConnectionString("TodoConnectionString"));
             await connection.ExecuteAsync("update UserData set userId=@userId,name=@name where userId=@userId",change);
             return ((await SelectAllValue(connection)).ToList());
        }
        
           private static async Task<IEnumerable<UserModel>> SelectAllValue(SqlConnection connection)
            {
                return await connection.QueryAsync<UserModel>("select * from UserData");
            }
    }
}