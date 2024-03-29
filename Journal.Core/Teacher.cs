﻿using System;
using System.Collections.Generic;

namespace Journal.Domain;

public partial class Teacher
{
    public Guid Id { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public byte[] Photo { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<TeacherGroup> TeacherGroups { get; set; } = new List<TeacherGroup>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
