using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.StudentLessons.Commands.SetMark
{
    public class SetMarkCommand : IRequest
    {
        public Guid StudentLessonId { get; set; }

        public Guid MarkId { get; set; }
    }
}
