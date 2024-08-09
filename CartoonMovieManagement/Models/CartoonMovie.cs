using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class CartoonMovie
{
    public int CartoonMovieId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int ProjectId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? ReleasedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<EpisodeMovie> EpisodeMovies { get; set; } = new List<EpisodeMovie>();

    public virtual Project Project { get; set; } = null!;
}
