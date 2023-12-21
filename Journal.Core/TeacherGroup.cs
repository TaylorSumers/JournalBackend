using System;
using System.Collections.Generic;

namespace Journal.Domain;

public partial class TeacherGroup
{
    public Guid Id { get; set; }

    public Guid TeacherId { get; set; }

    public Guid GroupId { get; set; }

    public Guid SubjectId { get; set; }

    public virtual Subject Subject { get; set; }

    public virtual Group Group { get; set; }

    public virtual Teacher Teacher { get; set; }
}
