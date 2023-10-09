using System;
using System.Collections.Generic;

namespace TaskApp.Models;

public partial class Tasks
{
    public int IdTask { get; set; }

    public string? Description { get; set; }

    public DateTime? RegisterDate { get; set; }
}
