using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.Students.Queries.GetStudentList
{
    public class StudentListVm
    {
        public IList<StudentDto> Students { get; set; }
    }
}
