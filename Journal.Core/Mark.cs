using System;
using System.Collections.Generic;

namespace Journal.Domain;

public partial class Mark
{
    public Guid Id { get; set; }

    public string ShortName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public virtual ICollection<StudentLesson> StudentLessons { get; set; } = new List<StudentLesson>();
}
