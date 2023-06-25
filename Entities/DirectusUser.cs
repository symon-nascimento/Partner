using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusUser
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Location { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Tags { get; set; }

    public Guid? Avatar { get; set; }

    public string? Language { get; set; }

    public string? Theme { get; set; }

    public string? TfaSecret { get; set; }

    public string Status { get; set; } = null!;

    public Guid? Role { get; set; }

    public string? Token { get; set; }

    public DateTime? LastAccess { get; set; }

    public string? LastPage { get; set; }

    public string Provider { get; set; } = null!;

    public string? ExternalIdentifier { get; set; }

    public string? AuthData { get; set; }

    public bool? EmailNotifications { get; set; }

    public virtual ICollection<DirectusDashboard> DirectusDashboards { get; set; } = new List<DirectusDashboard>();

    public virtual ICollection<DirectusFile> DirectusFileModifiedByNavigations { get; set; } = new List<DirectusFile>();

    public virtual ICollection<DirectusFile> DirectusFileUploadedByNavigations { get; set; } = new List<DirectusFile>();

    public virtual ICollection<DirectusFlow> DirectusFlows { get; set; } = new List<DirectusFlow>();

    public virtual ICollection<DirectusNotification> DirectusNotificationRecipientNavigations { get; set; } = new List<DirectusNotification>();

    public virtual ICollection<DirectusNotification> DirectusNotificationSenderNavigations { get; set; } = new List<DirectusNotification>();

    public virtual ICollection<DirectusOperation> DirectusOperations { get; set; } = new List<DirectusOperation>();

    public virtual ICollection<DirectusPanel> DirectusPanels { get; set; } = new List<DirectusPanel>();

    public virtual ICollection<DirectusPreset> DirectusPresets { get; set; } = new List<DirectusPreset>();

    public virtual ICollection<DirectusSession> DirectusSessions { get; set; } = new List<DirectusSession>();

    public virtual ICollection<DirectusShare> DirectusShares { get; set; } = new List<DirectusShare>();

    public virtual DirectusRole? RoleNavigation { get; set; }
}
