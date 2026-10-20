using System;
using System.Collections.Generic;

namespace LabWork1.Models;

public partial class Progress
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? LessonId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual User? Student { get; set; }
}
