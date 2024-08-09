using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class SalaryChangeLog
{
    public int SalaryChangeLogId { get; set; }

    public int EmployeeId { get; set; }

    public decimal Change { get; set; }

    public DateTime CreatedDate { get; set; }

    public int AccountId { get; set; }

    public string? Note { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
