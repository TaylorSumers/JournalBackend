using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.StudentLessons.Queries.GetStudentLessonList
{
    public class GetStudentLessonsQuery : IRequest<StudentLessonListVm>
    {
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid GroupId { get; set; }
    }
}
