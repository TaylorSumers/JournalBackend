using Journal.Application.Marks.Queries.GetMarks;
using Microsoft.AspNetCore.Mvc;

namespace UetkJournal.WebApi.Controllers
{
    public class MarksController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MarkListVm>> GetAll()
        {
            var query = new GetMarksQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
