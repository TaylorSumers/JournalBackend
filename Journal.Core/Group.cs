using System;
using System.Collections.Generic;

namespace Journal.Core;

public partial class Group
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid Speciality { get; set; }

    public int AdmisssionYear { get; set; }

    public int GraduationYear { get; set; }

    public virtual Speciality SpecialityNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
