using Journal.Application.Teachers.Queries.GetTeacherInfo;
using Journal.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UetkJournal.WebApi.Controllers
{
    public class TeachersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<TeacherInfoVm>> Get(string login, string password)
        {
            var query = new GetTeacherInfoQuery()
            {
                Login = login,
                Password = password
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
