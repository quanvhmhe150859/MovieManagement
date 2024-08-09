using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public int RoleId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Notification> NotificationCreaters { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationReceivers { get; set; } = new List<Notification>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SalaryChangeLog> SalaryChangeLogs { get; set; } = new List<SalaryChangeLog>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<UserLoginLog> UserLoginLogs { get; set; } = new List<UserLoginLog>();
}
