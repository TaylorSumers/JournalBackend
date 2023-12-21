using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.TeacherGroups.Queries.GetTeacherGroupList
{
    public class TeacherGroupListVm
    {
        public IList<TeacherGroupDto> TeacherGroups { get; set; }
    }
}
