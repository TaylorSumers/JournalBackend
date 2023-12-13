﻿using System;
using System.Collections.Generic;

namespace Journal.Core;

public partial class Subject
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid SpecialityId { get; set; }

    public virtual Speciality Speciality { get; set; } = null!;

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
