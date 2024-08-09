using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class EpisodeMovie
{
    public int EpisodeMovieId { get; set; }

    public int CartoonMovieId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? ReleasedDate { get; set; }

    public string? MovieLink { get; set; }

    public int? Duration { get; set; }

    public virtual CartoonMovie CartoonMovie { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
