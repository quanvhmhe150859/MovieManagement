using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? SocialMediaLink { get; set; }

    public string? Avatar { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public decimal Salary { get; set; }

    public int? DepartmentId { get; set; }

    public int? StudioId { get; set; }

    public string CitizenIdentification { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<EmployeeHistory> EmployeeHistories { get; set; } = new List<EmployeeHistory>();

    public virtual ICollection<SalaryChangeLog> SalaryChangeLogs { get; set; } = new List<SalaryChangeLog>();

    public virtual Studio? Studio { get; set; }

    public virtual ICollection<StudioDevice> StudioDevices { get; set; } = new List<StudioDevice>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
