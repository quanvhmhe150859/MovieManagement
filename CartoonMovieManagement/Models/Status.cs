using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? ForAdmin { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
