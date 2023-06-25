using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusFile
{
    public Guid Id { get; set; }

    public string Storage { get; set; } = null!;

    public string? FilenameDisk { get; set; }

    public string FilenameDownload { get; set; } = null!;

    public string? Title { get; set; }

    public string? Type { get; set; }

    public Guid? Folder { get; set; }

    public Guid? UploadedBy { get; set; }

    public DateTime UploadedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public string? Charset { get; set; }

    public long? Filesize { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public int? Duration { get; set; }

    public string? Embed { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public string? Tags { get; set; }

    public string? Metadata { get; set; }

    public virtual ICollection<DirectusSetting> DirectusSettingProjectLogoNavigations { get; set; } = new List<DirectusSetting>();

    public virtual ICollection<DirectusSetting> DirectusSettingPublicBackgroundNavigations { get; set; } = new List<DirectusSetting>();

    public virtual ICollection<DirectusSetting> DirectusSettingPublicForegroundNavigations { get; set; } = new List<DirectusSetting>();

    public virtual DirectusFolder? FolderNavigation { get; set; }

    public virtual DirectusUser? ModifiedByNavigation { get; set; }

    public virtual DirectusUser? UploadedByNavigation { get; set; }
}
