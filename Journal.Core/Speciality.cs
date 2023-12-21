using System;
using System.Collections.Generic;

namespace Journal.Domain;

public partial class Speciality
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
