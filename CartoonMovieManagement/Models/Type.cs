using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Type
{
    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
