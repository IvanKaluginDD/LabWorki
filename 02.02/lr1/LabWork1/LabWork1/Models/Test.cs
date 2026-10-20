using System;
using System.Collections.Generic;

namespace LabWork1.Models;

public partial class Test
{
    public int Id { get; set; }

    public int? LessonId { get; set; }

    public string? Title { get; set; }

    public decimal? Score { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
