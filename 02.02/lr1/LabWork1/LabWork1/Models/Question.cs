using System;
using System.Collections.Generic;

namespace LabWork1.Models;

public partial class Question
{
    public int Id { get; set; }

    public int? TestId { get; set; }

    public string? Question1 { get; set; }

    public bool? Correct { get; set; }

    public virtual Test? Test { get; set; }
}
