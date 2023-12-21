using System;
using System.Collections.Generic;

namespace Journal.Domain;

public partial class Lesson
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public int NumberOfLesson { get; set; }

    public Guid Group { get; set; }

    public Guid TeacherId { get; set; }

    public Guid SubjectId { get; set; }

    public virtual ICollection<StudentLesson> StudentLessons { get; set; } = new List<StudentLesson>();

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
