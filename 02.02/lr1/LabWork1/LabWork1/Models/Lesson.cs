using System;
using System.Collections.Generic;

namespace LabWork1.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public string? Title { get; set; }

    public string? Type { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Progress? CourseNavigation { get; set; }

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
