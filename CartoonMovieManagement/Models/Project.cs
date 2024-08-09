using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int CategoryId { get; set; }

    public decimal? Budget { get; set; }

    public virtual ICollection<CartoonMovie> CartoonMovies { get; set; } = new List<CartoonMovie>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProjectCooperator> ProjectCooperators { get; set; } = new List<ProjectCooperator>();
}
