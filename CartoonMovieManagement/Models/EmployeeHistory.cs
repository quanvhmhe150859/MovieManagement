using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class EmployeeHistory
{
    public int EmployeeHistoryId { get; set; }

    public int EmployeeId { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
