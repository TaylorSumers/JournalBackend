using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.Teachers.Queries.GetTeacherInfo
{
    public class GetTeacherInfoQuery : IRequest<TeacherInfoVm>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
