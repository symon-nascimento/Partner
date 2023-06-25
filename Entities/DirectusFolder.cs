using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusFolder
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? Parent { get; set; }

    public virtual ICollection<DirectusFile> DirectusFiles { get; set; } = new List<DirectusFile>();

    public virtual ICollection<DirectusSetting> DirectusSettings { get; set; } = new List<DirectusSetting>();

    public virtual ICollection<DirectusFolder> InverseParentNavigation { get; set; } = new List<DirectusFolder>();

    public virtual DirectusFolder? ParentNavigation { get; set; }
}
