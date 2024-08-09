using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int CreaterId { get; set; }

    public int ReceiverId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? ReadedDate { get; set; }

    public string Message { get; set; } = null!;

    public string NotificationType { get; set; } = null!;

    public virtual Account Creater { get; set; } = null!;

    public virtual Account Receiver { get; set; } = null!;
}
