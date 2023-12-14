using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.StudentLessons.Queries.GetStudentLessonList
{
    public class StudentLessonListVm
    {
        public IList<StudentLessonDto> StudentLessons { get; set; }
    }
}
