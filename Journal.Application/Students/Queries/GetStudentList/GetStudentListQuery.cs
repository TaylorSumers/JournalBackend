using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.Students.Queries.GetStudentList
{
    public class GetStudentListQuery : IRequest<StudentListVm>
    {
        public Guid GroupId { get; set; }
    }
}
