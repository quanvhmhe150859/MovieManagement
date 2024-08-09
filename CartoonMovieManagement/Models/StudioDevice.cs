using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class StudioDevice
{
    public int DeviceId { get; set; }

    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsOwner { get; set; }

    public decimal? MoneyValue { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
