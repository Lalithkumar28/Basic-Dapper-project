using api_task.DAL;
using api_task.Model;

namespace api_task.BAL
{
   
    public class UserBAL:IUserBAL
    {
        private readonly IUserDAL _employee;

        public UserBAL(IUserDAL employee)
        {
            _employee = employee;
        }

        
        public async Task<List<UserModel>> Create(UserModel values)
        {
            return (await _employee.CreateValue(values)).ToList();
        }
        public async Task<List<UserModel>> Update(UserModel values)
        {
            return (await _employee.UpdateValue(values)).ToList();
        }
    }
}