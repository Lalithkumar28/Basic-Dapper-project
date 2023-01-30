using api_task.Model;

namespace api_task.DAL
{
    public interface ITodoDAL
    {
         Task<List<TodoModel>> GetValueById(int id);
         Task<List<TodoModel>> GetTodoValueById(int id);
         Task<List<TodoModel>> RemoveTodoValueById(int id);
         Task<List<TodoModel>> CreateValue(TodoModel values,int id);
         Task<List<TodoModel>> UpdateValue(TodoModel change,int id);
    }
}