using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? AssignedDate { get; set; }

    public DateTime DeadlineDate { get; set; }

    public int CreaterId { get; set; }

    public int? ReceiverId { get; set; }

    public int StatusId { get; set; }

    public string? Note { get; set; }

    public string? ResourceLink { get; set; }

    public string? SubmitLink { get; set; }

    public int EpisodeMovieId { get; set; }

    public decimal? Cost { get; set; }

    public int? TaskParentId { get; set; }

    public virtual Account Creater { get; set; } = null!;

    public virtual EpisodeMovie EpisodeMovie { get; set; } = null!;

    public virtual ICollection<Task> InverseTaskParent { get; set; } = new List<Task>();

    public virtual Employee? Receiver { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<TaskHistoryLog> TaskHistoryLogs { get; set; } = new List<TaskHistoryLog>();

    public virtual Task? TaskParent { get; set; }
}