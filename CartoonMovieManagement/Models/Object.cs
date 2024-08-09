using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Object
{
    public int ObjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int TypeId { get; set; }

    public int AccountId { get; set; }

    public int CartoonMovieId { get; set; }

    public string? ObjectLink { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual CartoonMovie CartoonMovie { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;
}
