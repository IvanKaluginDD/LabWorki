using System;
using System.Collections.Generic;

namespace LabWork1.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? PassowrdHash { get; set; }

    public string? FullName { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
