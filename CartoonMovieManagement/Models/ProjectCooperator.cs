using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class ProjectCooperator
{
    public int ProjectCooperatorId { get; set; }

    public int CooperatorId { get; set; }

    public int ProjectId { get; set; }

    public virtual Cooperator Cooperator { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
