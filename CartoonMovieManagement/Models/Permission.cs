using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Permission
{
    public int PermissionId { get; set; }

    public int RoleId { get; set; }

    public int TypeId { get; set; }

    public bool Create { get; set; }

    public bool Read { get; set; }

    public bool Update { get; set; }

    public bool Delete { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;
}
