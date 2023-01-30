using api_task.Model;

namespace api_task.BAL
{
    public interface ITodoBAL  
    {
         Task<List<TodoModel>> GetByUserId(int id);
         Task<List<TodoModel>> GetByTodoId(int id);
         Task<List<TodoModel>> Update(TodoModel values,int id);
         Task<List<TodoModel>> RemoveByTodoId(int id);
         Task<List<TodoModel>> Create(TodoModel values,int id);
    }
}