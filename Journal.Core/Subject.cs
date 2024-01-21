using System;
using System.Collections.Generic;

namespace Journal.Domain;

public partial class Subject
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? SpecialityId { get; set; } = null;

    public virtual Speciality Speciality { get; set; } = null!;

    public virtual ICollection<TeacherGroup> TeacherGroups { get; set; } = new List<TeacherGroup>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
