using System;
using System.Collections.Generic;

namespace LabWork1.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? AuthorId { get; set; }

    public decimal? Price { get; set; }

    public virtual User? Author { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
