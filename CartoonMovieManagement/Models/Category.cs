using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public int? CategoryParentId { get; set; }

    public virtual Category? CategoryParent { get; set; }

    public virtual ICollection<Category> InverseCategoryParent { get; set; } = new List<Category>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
