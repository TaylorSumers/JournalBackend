using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Domain
{
    public class TeacherSubject
    {
        public Guid Id { get; set; }

        public Guid TeacherId { get; set; }

        public Guid SubjectId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
