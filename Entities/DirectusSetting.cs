using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusSetting
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? ProjectUrl { get; set; }

    public string? ProjectColor { get; set; }

    public Guid? ProjectLogo { get; set; }

    public Guid? PublicForeground { get; set; }

    public Guid? PublicBackground { get; set; }

    public string? PublicNote { get; set; }

    public int? AuthLoginAttempts { get; set; }

    public string? AuthPasswordPolicy { get; set; }

    public string? StorageAssetTransform { get; set; }

    public string? StorageAssetPresets { get; set; }

    public string? CustomCss { get; set; }

    public Guid? StorageDefaultFolder { get; set; }

    public string? Basemaps { get; set; }

    public string? MapboxKey { get; set; }

    public string? ModuleBar { get; set; }

    public string? ProjectDescriptor { get; set; }

    public string? TranslationStrings { get; set; }

    public string DefaultLanguage { get; set; } = null!;

    public string? CustomAspectRatios { get; set; }

    public virtual DirectusFile? ProjectLogoNavigation { get; set; }

    public virtual DirectusFile? PublicBackgroundNavigation { get; set; }

    public virtual DirectusFile? PublicForegroundNavigation { get; set; }

    public virtual DirectusFolder? StorageDefaultFolderNavigation { get; set; }
}
