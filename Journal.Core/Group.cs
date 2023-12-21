using System;
using System.Collections.Generic;

namespace Journal.Domain;

public partial class Group
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid SpecialityId { get; set; }

    public int AdmisssionYear { get; set; }

    public int GraduationYear { get; set; }

    public virtual Speciality Speciality { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<TeacherGroup> TeacherGroups { get; set; } = new List<TeacherGroup>();
}
