using System;
using System.Collections.Generic;

namespace CartoonMovieManagement.Models;

public partial class TaskHistoryLog
{
    public int TaskHistoryLogId { get; set; }

    public int TaskId { get; set; }

    public string? LogAction { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? EpisodeName { get; set; }

    public string? ReceiverName { get; set; }

    public DateTime? DeadlineDate { get; set; }

    public DateTime? SubmitedDate { get; set; }

    public string? ResourceLink { get; set; }

    public string? SubmitLink { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    public virtual Task Task { get; set; } = null!;
}