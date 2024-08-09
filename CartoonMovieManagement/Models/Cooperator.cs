using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Cooperator
{
    public int CooperatorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<ProjectCooperator> ProjectCooperators { get; set; } = new List<ProjectCooperator>();
}
