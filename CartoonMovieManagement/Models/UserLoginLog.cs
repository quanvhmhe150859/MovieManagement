using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class UserLoginLog
{
    public int LoginLogId { get; set; }

    public int AccountId { get; set; }

    public string IpAddress { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public DateTime LoginTime { get; set; }

    public string Country { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string City { get; set; } = null!;

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string TimeZone { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;
}
