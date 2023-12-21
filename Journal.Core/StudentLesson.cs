using System;
using System.Collections.Generic;

namespace Journal.Domain;

public partial class StudentLesson
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid LessonId { get; set; }

    public Guid MarkId { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual Mark Mark { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
