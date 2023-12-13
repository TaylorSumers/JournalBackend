using System;
using System.Collections.Generic;

namespace Journal.Core;

public partial class TeacherSubject
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }

    public Guid? SubjectId { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
