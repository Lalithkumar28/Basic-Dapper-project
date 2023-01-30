using api_task.DAL;
using api_task.Model;

namespace api_task.BAL
{
    public class TodoBAL:ITodoBAL
    {
        private readonly ITodoDAL _todo;

        public TodoBAL(ITodoDAL todo)
        {
            _todo = todo;
        }
        public async Task<List<TodoModel>> GetByUserId(int id)
        {
            return( await _todo.GetValueById(id)).ToList();
        }
         public async Task<List<TodoModel>> GetByTodoId(int id)
        {
            return( await _todo.GetTodoValueById(id)).ToList();
        }
         public async Task<List<TodoModel>> Update(TodoModel values,int id)
        {
            return (await _todo.UpdateValue(values,id)).ToList();
        }
         public async Task<List<TodoModel>> RemoveByTodoId(int id)
        {
            return( await _todo.RemoveTodoValueById(id)).ToList();
        }
         public async Task<List<TodoModel>> Create(TodoModel values,int id)
        {
            return (await _todo.CreateValue(values,id)).ToList();
        }
    }
}