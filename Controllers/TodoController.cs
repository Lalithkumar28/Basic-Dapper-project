using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_task.Model;
using api_task.BAL;


namespace api_task.TodoControllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {

       private readonly ITodoBAL _result;

        public TodoController(ITodoBAL result)
        {
            _result = result;
        }
        
        [HttpGet("{userid}")]
        public async Task<ActionResult<List<TodoModel>>> GetListByUser(int userid)
        {
            return Ok(await _result.GetByUserId(userid));
        }
        [HttpGet("/{todoid}")]
        public async Task<ActionResult<List<TodoModel>>> GetListByTodoId(int todoid)
        {
            return Ok(await _result.GetByTodoId(todoid));
        }
        [HttpPut("/update/{todoid}")]
        public async Task<ActionResult<List<TodoModel>>> UpdateUserList(TodoModel values,int todoid)
        {
            return Ok(await _result.Update(values,todoid));
        }
        [HttpDelete("/delete/{todoid}")]
        public async Task<ActionResult<List<TodoModel>>> RemoveTodoList(int todoid)
        {
            return Ok(await _result.RemoveByTodoId(todoid));
        }
        [HttpPost("/create/{todoid}")]
        public async Task<ActionResult<List<TodoModel>>> CreateTodoList(TodoModel value,int todoid)
        {
            if(value==null)
            {
                return NoContent();
            }
            return Ok(await _result.Create(value,todoid));
        }



        
    }
}