using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.TeacherGroups.Queries.GetTeacherGroupList
{
    public class GetTeacherGroupListQuery : IRequest<TeacherGroupListVm>
    {
        public Guid TeacherId { get; set; }
    }
}
