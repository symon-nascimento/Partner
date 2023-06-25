using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusNotification
{
    public int Id { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? Status { get; set; }

    public Guid Recipient { get; set; }

    public Guid? Sender { get; set; }

    public string Subject { get; set; } = null!;

    public string? Message { get; set; }

    public string? Collection { get; set; }

    public string? Item { get; set; }

    public virtual DirectusUser RecipientNavigation { get; set; } = null!;

    public virtual DirectusUser? SenderNavigation { get; set; }
}
