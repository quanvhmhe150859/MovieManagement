using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
