using System.Data.SqlClient;
using api_task.Model;
using Dapper;

namespace api_task.DAL
{
    public class TodoDAL:ITodoDAL
    {
        private readonly IConfiguration _config;

        public TodoDAL(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<TodoModel>> GetValueById(int id)
        {
            using var connection= new SqlConnection(_config.GetConnectionString("TodoConnectionString"));
            var employe= await connection.QueryAsync<TodoModel>("SELECT TodoId,date,context,userId from TodoTable where userId=@Id",new{Id=id});
            return employe.ToList();
        }
          public async Task<List<TodoModel>> GetTodoValueById(int id)
        {
            using var connection= new SqlConnection(_config.GetConnectionString("TodoConnectionString"));
            var employe= await connection.QueryAsync<TodoModel>("SELECT TodoId,date,context,userId from TodoTable where TodoId=@Id",new{Id=id});
            return employe.ToList();
        }
         public async Task<List<TodoModel>> UpdateValue(TodoModel change,int id)
        {
             using var connection= new SqlConnection(_config.GetConnectionString("TodoConnectionString"));
             await connection.ExecuteAsync("update TodoTable set userId=@userId,date=@date,context=@context where TodoId=@Id",
             new{
             date= DateTime.Now,
             context=change.context,
             userId=change.UserId,
             Id = id
             }
             );
             return ((await SelectAllValue(connection)).ToList());
        }
         public async Task<List<TodoModel>> RemoveTodoValueById(int id)
        {
            using var connection= new SqlConnection(_config.GetConnectionString("TodoConnectionString"));
            var employe= await connection.QueryAsync<TodoModel>("Delete from TodoTable where TodoId=@Id",new{Id=id});
            return (await SelectAllValue(connection)).ToList();
        }
         public async Task<List<TodoModel>> CreateValue(TodoModel values,int id)
        {
             using var connection= new SqlConnection(_config.GetConnectionString("TodoConnectionString"));
             await connection.ExecuteAsync("insert into TodoTable(date,context,userId)values(@date,@context,@userId) ",
             new{
             date= DateTime.Now,
             context=values.context,
             userId=values.UserId,
             Id = id
             });
             return (await SelectAllValue(connection)).ToList();
        }

          private static async Task<IEnumerable<TodoModel>> SelectAllValue(SqlConnection connection)
            {
                return await connection.QueryAsync<TodoModel>("select * from TodoTable");
            }
    }
}