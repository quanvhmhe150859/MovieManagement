using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Studio
{
    public int StudioId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
