using System;
using System.Collections.Generic;

namespace Journal.Domain;

public partial class Student
{
    public Guid Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public Guid GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<StudentLesson> StudentLessons { get; set; } = new List<StudentLesson>();
}
