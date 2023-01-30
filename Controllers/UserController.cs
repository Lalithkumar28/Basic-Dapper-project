using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_task.BAL;
using api_task.Model;
using Microsoft.AspNetCore.Mvc;

namespace api_task.UserControllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBAL _result;

        
        public UserController(IUserBAL result)
        {
            _result = result;
        }

      
        [HttpPost("")]
        public async Task<ActionResult<List<UserModel>>> CreateUserList(UserModel value)
        {
            if(value==null)
            {
                return NoContent();
                
            }
            var res=await _result.Create(value);
            return Created("",res);
        }
        
        [HttpPut("{id}")]

        public async Task<ActionResult<List<UserModel>>> UpdateUserList(UserModel values)
        {
            return Ok(await _result.Update(values));
        }
    }


}
