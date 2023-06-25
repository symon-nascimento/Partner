using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Partner.Entities;

public partial class PartnerContext : DbContext
{
    public PartnerContext()
    {
    }

    public PartnerContext(DbContextOptions<PartnerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<DirectusActivity> DirectusActivities { get; set; }

    public virtual DbSet<DirectusCollection> DirectusCollections { get; set; }

    public virtual DbSet<DirectusDashboard> DirectusDashboards { get; set; }

    public virtual DbSet<DirectusField> DirectusFields { get; set; }

    public virtual DbSet<DirectusFile> DirectusFiles { get; set; }

    public virtual DbSet<DirectusFlow> DirectusFlows { get; set; }

    public virtual DbSet<DirectusFolder> DirectusFolders { get; set; }

    public virtual DbSet<DirectusMigration> DirectusMigrations { get; set; }

    public virtual DbSet<DirectusNotification> DirectusNotifications { get; set; }

    public virtual DbSet<DirectusOperation> DirectusOperations { get; set; }

    public virtual DbSet<DirectusPanel> DirectusPanels { get; set; }

    public virtual DbSet<DirectusPermission> DirectusPermissions { get; set; }

    public virtual DbSet<DirectusPreset> DirectusPresets { get; set; }

    public virtual DbSet<DirectusRelation> DirectusRelations { get; set; }

    public virtual DbSet<DirectusRevision> DirectusRevisions { get; set; }

    public virtual DbSet<DirectusRole> DirectusRoles { get; set; }

    public virtual DbSet<DirectusSession> DirectusSessions { get; set; }

    public virtual DbSet<DirectusSetting> DirectusSettings { get; set; }

    public virtual DbSet<DirectusShare> DirectusShares { get; set; }

    public virtual DbSet<DirectusUser> DirectusUsers { get; set; }

    public virtual DbSet<DirectusWebhook> DirectusWebhooks { get; set; }

    public virtual DbSet<PortalsCredential> PortalsCredentials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LAACJD8,17001;Initial Catalog=partner;User ID=partner;Password=partner2023!;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients__3213E83FFAE8F2C5");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .HasColumnName("alias");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.Uin)
                .HasMaxLength(255)
                .HasColumnName("uin");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contract__3213E83F72C6F63B");

            entity.ToTable("contracts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clients).HasColumnName("clients");
            entity.Property(e => e.ContractEnd).HasColumnName("contract_end");
            entity.Property(e => e.ContractStart).HasColumnName("contract_start");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.EmailSendDate).HasColumnName("email_send_date");
            entity.Property(e => e.Manager)
                .HasMaxLength(255)
                .HasColumnName("manager");
            entity.Property(e => e.MonthlyFees)
                .HasMaxLength(255)
                .HasColumnName("monthly_fees");
            entity.Property(e => e.ServiceDescription)
                .HasMaxLength(255)
                .HasColumnName("service_description");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(255)
                .HasColumnName("telephone_number");
            entity.Property(e => e.WhatsappNumber)
                .HasMaxLength(255)
                .HasColumnName("whatsapp_number");

            entity.HasOne(d => d.ClientsNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Clients)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("contracts_clients_foreign");
        });

        modelBuilder.Entity<DirectusActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__directus__3213E83F8F388308");

            entity.ToTable("directus_activity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(45)
                .HasColumnName("action");
            entity.Property(e => e.Collection)
                .HasMaxLength(64)
                .HasColumnName("collection");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("ip");
            entity.Property(e => e.Item)
                .HasMaxLength(255)
                .HasColumnName("item");
            entity.Property(e => e.Origin)
                .HasMaxLength(255)
                .HasColumnName("origin");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("timestamp");
            entity.Property(e => e.User).HasColumnName("user");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(255)
                .HasColumnName("user_agent");
        });

        modelBuilder.Entity<DirectusCollection>(entity =>
        {
            entity.HasKey(e => e.Collection).HasName("directus_collections_pkey");

            entity.ToTable("directus_collections");

            entity.Property(e => e.Collection)
                .HasMaxLength(64)
                .HasColumnName("collection");
            entity.Property(e => e.Accountability)
                .HasMaxLength(255)
                .HasDefaultValueSql("('all')")
                .HasColumnName("accountability");
            entity.Property(e => e.ArchiveAppFilter)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasColumnName("archive_app_filter");
            entity.Property(e => e.ArchiveField)
                .HasMaxLength(64)
                .HasColumnName("archive_field");
            entity.Property(e => e.ArchiveValue)
                .HasMaxLength(255)
                .HasColumnName("archive_value");
            entity.Property(e => e.Collapse)
                .HasMaxLength(255)
                .HasDefaultValueSql("('open')")
                .HasColumnName("collapse");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasColumnName("color");
            entity.Property(e => e.DisplayTemplate)
                .HasMaxLength(255)
                .HasColumnName("display_template");
            entity.Property(e => e.Group)
                .HasMaxLength(64)
                .HasColumnName("group");
            entity.Property(e => e.Hidden)
                .IsRequired()
                .HasDefaultValueSql("('0')")
                .HasColumnName("hidden");
            entity.Property(e => e.Icon)
                .HasMaxLength(30)
                .HasColumnName("icon");
            entity.Property(e => e.ItemDuplicationFields).HasColumnName("item_duplication_fields");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Singleton)
                .IsRequired()
                .HasDefaultValueSql("('0')")
                .HasColumnName("singleton");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.SortField)
                .HasMaxLength(64)
                .HasColumnName("sort_field");
            entity.Property(e => e.Translations).HasColumnName("translations");
            entity.Property(e => e.UnarchiveValue)
                .HasMaxLength(255)
                .HasColumnName("unarchive_value");

            entity.HasOne(d => d.GroupNavigation).WithMany(p => p.InverseGroupNavigation)
                .HasForeignKey(d => d.Group)
                .HasConstraintName("directus_collections_group_foreign");
        });

        modelBuilder.Entity<DirectusDashboard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directus_dashboards_pkey");

            entity.ToTable("directus_dashboards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasColumnName("color");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("date_created");
            entity.Property(e => e.Icon)
                .HasMaxLength(30)
                .HasDefaultValueSql("('dashboard')")
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.UserCreated).HasColumnName("user_created");

            entity.HasOne(d => d.UserCreatedNavigation).WithMany(p => p.DirectusDashboards)
                .HasForeignKey(d => d.UserCreated)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("directus_dashboards_user_created_foreign");
        });

        modelBuilder.Entity<DirectusField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__directus__3213E83F5C4CEF05");

            entity.ToTable("directus_fields");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Collection)
                .HasMaxLength(64)
                .HasColumnName("collection");
            entity.Property(e => e.Conditions).HasColumnName("conditions");
            entity.Property(e => e.Display)
                .HasMaxLength(64)
                .HasColumnName("display");
            entity.Property(e => e.DisplayOptions).HasColumnName("display_options");
            entity.Property(e => e.Field)
                .HasMaxLength(64)
                .HasColumnName("field");
            entity.Property(e => e.Group)
                .HasMaxLength(64)
                .HasColumnName("group");
            entity.Property(e => e.Hidden)
                .IsRequired()
                .HasDefaultValueSql("('0')")
                .HasColumnName("hidden");
            entity.Property(e => e.Interface)
                .HasMaxLength(64)
                .HasColumnName("interface");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Options).HasColumnName("options");
            entity.Property(e => e.Readonly)
                .IsRequired()
                .HasDefaultValueSql("('0')")
                .HasColumnName("readonly");
            entity.Property(e => e.Required)
                .HasDefaultValueSql("('0')")
                .HasColumnName("required");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Special)
                .HasMaxLength(64)
                .HasColumnName("special");
            entity.Property(e => e.Translations).HasColumnName("translations");
            entity.Property(e => e.Validation).HasColumnName("validation");
            entity.Property(e => e.ValidationMessage).HasColumnName("validation_message");
            entity.Property(e => e.Width)
                .HasMaxLength(30)
                .HasDefaultValueSql("('full')")
                .HasColumnName("width");
        });

        modelBuilder.Entity<DirectusFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directus_files_pkey");

            entity.ToTable("directus_files");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Charset)
                .HasMaxLength(50)
                .HasColumnName("charset");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Embed)
                .HasMaxLength(200)
                .HasColumnName("embed");
            entity.Property(e => e.FilenameDisk)
                .HasMaxLength(255)
                .HasColumnName("filename_disk");
            entity.Property(e => e.FilenameDownload)
                .HasMaxLength(255)
                .HasColumnName("filename_download");
            entity.Property(e => e.Filesize).HasColumnName("filesize");
            entity.Property(e => e.Folder).HasColumnName("folder");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Metadata).HasColumnName("metadata");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("modified_on");
            entity.Property(e => e.Storage)
                .HasMaxLength(255)
                .HasColumnName("storage");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UploadedBy).HasColumnName("uploaded_by");
            entity.Property(e => e.UploadedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("uploaded_on");
            entity.Property(e => e.Width).HasColumnName("width");

            entity.HasOne(d => d.FolderNavigation).WithMany(p => p.DirectusFiles)
                .HasForeignKey(d => d.Folder)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("directus_files_folder_foreign");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.DirectusFileModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("directus_files_modified_by_foreign");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.DirectusFileUploadedByNavigations)
                .HasForeignKey(d => d.UploadedBy)
                .HasConstraintName("directus_files_uploaded_by_foreign");
        });

        modelBuilder.Entity<DirectusFlow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directus_flows_pkey");

            entity.ToTable("directus_flows");

            entity.HasIndex(e => e.Operation, "directus_flows_operation_unique")
                .IsUnique()
                .HasFilter("([operation] IS NOT NULL)");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Accountability)
                .HasMaxLength(255)
                .HasDefaultValueSql("('all')")
                .HasColumnName("accountability");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasColumnName("color");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("date_created");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Icon)
                .HasMaxLength(30)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Operation).HasColumnName("operation");
            entity.Property(e => e.Options).HasColumnName("options");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValueSql("('active')")
                .HasColumnName("status");
            entity.Property(e => e.Trigger)
                .HasMaxLength(255)
                .HasColumnName("trigger");
            entity.Property(e => e.UserCreated).HasColumnName("user_created");

            entity.HasOne(d => d.UserCreatedNavigation).WithMany(p => p.DirectusFlows)
                .HasForeignKey(d => d.UserCreated)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("directus_flows_user_created_foreign");
        });

        modelBuilder.Entity<DirectusFolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directus_folders_pkey");

            entity.ToTable("directus_folders");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Parent).HasColumnName("parent");

            entity.HasOne(d => d.ParentNavigation).WithMany(p => p.InverseParentNavigation)
                .HasForeignKey(d => d.Parent)
                .HasConstraintName("directus_folders_parent_foreign");
        });

        modelBuilder.Entity<DirectusMigration>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("directus_migrations_pkey");

            entity.ToTable("directus_migrations");

            entity.Property(e => e.Version)
                .HasMaxLength(255)
                .HasColumnName("version");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<DirectusNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__directus__3213E83F60C42D13");

            entity.ToTable("directus_notifications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Collection)
                .HasMaxLength(64)
                .HasColumnName("collection");
            entity.Property(e => e.Item)
                .HasMaxLength(255)
                .HasColumnName("item");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Recipient).HasColumnName("recipient");
            entity.Property(e => e.Sender).HasColumnName("sender");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValueSql("('inbox')")
                .HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("subject");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.RecipientNavigation).WithMany(p => p.DirectusNotificationRecipientNavigations)
                .HasForeignKey(d => d.Recipient)
                .HasConstraintName("directus_notifications_recipient_foreign");

            entity.HasOne(d => d.SenderNavigation).WithMany(p => p.DirectusNotificationSenderNavigations)
                .HasForeignKey(d => d.Sender)
                .HasConstraintName("directus_notifications_sender_foreign");
        });

        modelBuilder.Entity<DirectusOperation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directus_operations_pkey");

            entity.ToTable("directus_operations");

            entity.HasIndex(e => e.Reject, "directus_operations_reject_unique")
                .IsUnique()
                .HasFilter("([reject] IS NOT NULL)");

            entity.HasIndex(e => e.Resolve, "directus_operations_resolve_unique")
                .IsUnique()
                .HasFilter("([resolve] IS NOT NULL)");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("date_created");
            entity.Property(e => e.Flow).HasColumnName("flow");
            entity.Property(e => e.Key)
                .HasMaxLength(255)
                .HasColumnName("key");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Options).HasColumnName("options");
            entity.Property(e => e.PositionX).HasColumnName("position_x");
            entity.Property(e => e.PositionY).HasColumnName("position_y");
            entity.Property(e => e.Reject).HasColumnName("reject");
            entity.Property(e => e.Resolve).HasColumnName("resolve");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UserCreated).HasColumnName("user_created");

            entity.HasOne(d => d.FlowNavigation).WithMany(p => p.DirectusOperations)
                .HasForeignKey(d => d.Flow)
                .HasConstraintName("directus_operations_flow_foreign");

            entity.HasOne(d => d.RejectNavigation).WithOne(p => p.InverseRejectNavigation)
                .HasForeignKey<DirectusOperation>(d => d.Reject)
                .HasConstraintName("directus_operations_reject_foreign");

            entity.HasOne(d => d.ResolveNavigation).WithOne(p => p.InverseResolveNavigation)
                .HasForeignKey<DirectusOperation>(d => d.Resolve)
                .HasConstraintName("directus_operations_resolve_foreign");

            entity.HasOne(d => d.UserCreatedNavigation).WithMany(p => p.DirectusOperations)
                .HasForeignKey(d => d.UserCreated)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("directus_operations_user_created_foreign");
        });

        modelBuilder.Entity<DirectusPanel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directus_panels_pkey");

            entity.ToTable("directus_panels");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .HasColumnName("color");
            entity.Property(e => e.Dashboard).HasColumnName("dashboard");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("date_created");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Icon)
                .HasMaxLength(30)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Options).HasColumnName("options");
            entity.Property(e => e.PositionX).HasColumnName("position_x");
            entity.Property(e => e.PositionY).HasColumnName("position_y");
            entity.Property(e => e.ShowHeader)
                .IsRequired()
                .HasDefaultValueSql("('0')")
                .HasColumnName("show_header");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UserCreated).HasColumnName("user_created");
            entity.Property(e => e.Width).HasColumnName("width");

            entity.HasOne(d => d.DashboardNavigation).WithMany(p => p.DirectusPanels)
                .HasForeignKey(d => d.Dashboard)
                .HasConstraintName("directus_panels_dashboard_foreign");

            entity.HasOne(d => d.UserCreatedNavigation).WithMany(p => p.DirectusPanels)
                .HasForeignKey(d => d.UserCreated)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("directus_panels_user_created_foreign");
        });

        modelBuilder.Entity<DirectusPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__directus__3213E83F0EC42972");

            entity.ToTable("directus_permissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(10)
                .HasColumnName("action");
            entity.Property(e => e.Collection)
                .HasMaxLength(64)
                .HasColumnName("collection");
            entity.Property(e => e.Fields).HasColumnName("fields");
            entity.Property(e => e.Permissions).HasColumnName("permissions");
            entity.Property(e => e.Presets).HasColumnName("presets");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Validation).HasColumnName("validation");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.DirectusPermissions)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("directus_permissions_role_foreign");
        });

        modelBuilder.Entity<DirectusPreset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__directus__3213E83FFF2F6365");

            entity.ToTable("directus_presets");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bookmark)
                .HasMaxLength(255)
                .HasColumnName("bookmark");
            entity.Property(e => e.Collection)
                .HasMaxLength(64)
                .HasColumnName("collection");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasColumnName("color");
            entity.Property(e => e.Filter).HasColumnName("filter");
            entity.Property(e => e.Icon)
                .HasMaxLength(30)
                .HasDefaultValueSql("('bookmark')")
                .HasColumnName("icon");
            entity.Property(e => e.Layout)
                .HasMaxLength(100)
                .HasDefaultValueSql("('tabular')")
                .HasColumnName("layout");
            entity.Property(e => e.LayoutOptions).HasColumnName("layout_options");
            entity.Property(e => e.LayoutQuery).HasColumnName("layout_query");
            entity.Property(e => e.RefreshInterval).HasColumnName("refresh_interval");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Search)
                .HasMaxLength(100)
                .HasColumnName("search");
            entity.Property(e => e.User).HasColumnName("user");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.DirectusPresets)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("directus_presets_role_foreign");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.DirectusPresets)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("directus_presets_user_foreign");
        });

        modelBuilder.Entity<DirectusRelation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__directus__3213E83F63D30D55");

            entity.ToTable("directus_relations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JunctionField)
                .HasMaxLength(64)
                .HasColumnName("junction_field");
            entity.Property(e => e.ManyCollection)
                .HasMaxLength(64)
                .HasColumnName("many_collection");
            entity.Property(e => e.ManyField)
                .HasMaxLength(64)
                .HasColumnName("many_field");
            entity.Property(e => e.OneAllowedCollections).HasColumnName("one_allowed_collections");
            entity.Property(e => e.OneCollection)
                .HasMaxLength(64)
                .HasColumnName("one_collection");
            entity.Property(e => e.OneCollectionField)
                .HasMaxLength(64)
                .HasColumnName("one_collection_field");
            entity.Property(e => e.OneDeselectAction)
                .HasMaxLength(255)
                .HasDefaultValueSql("('nullify')")
                .HasColumnName("one_deselect_action");
            entity.Property(e => e.OneField)
                .HasMaxLength(64)
                .HasColumnName("one_field");
            entity.Property(e => e.SortField)
                .HasMaxLength(64)
                .HasColumnName("sort_field");
        });

        modelBuilder.Entity<DirectusRevision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__directus__3213E83FE00D95E2");

            entity.ToTable("directus_revisions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activity).HasColumnName("activity");
            entity.Property(e => e.Collection)
                .HasMaxLength(64)
                .HasColumnName("collection");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Delta).HasColumnName("delta");
            entity.Property(e => e.Item)
                .HasMaxLength(255)
                .HasColumnName("item");
            entity.Property(e => e.Parent).HasColumnName("parent");

            entity.HasOne(d => d.ActivityNavigation).WithMany(p => p.DirectusRevisions)
                .HasForeignKey(d => d.Activity)
                .HasConstraintName("directus_revisions_activity_foreign");

            entity.HasOne(d => d.ParentNavigation).WithMany(p => p.InverseParentNavigation)
                .HasForeignKey(d => d.Parent)
                .HasConstraintName("directus_revisions_parent_foreign");
        });

        modelBuilder.Entity<DirectusRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directus_roles_pkey");

            entity.ToTable("directus_roles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AdminAccess)
                .IsRequired()
                .HasDefaultValueSql("('0')")
                .HasColumnName("admin_access");
            entity.Property(e => e.AppAccess)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasColumnName("app_access");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EnforceTfa)
                .IsRequired()
                .HasDefaultValueSql("('0')")
                .HasColumnName("enforce_tfa");
            entity.Property(e => e.Icon)
                .HasMaxLength(30)
                .HasDefaultValueSql("('supervised_user_circle')")
                .HasColumnName("icon");
            entity.Property(e => e.IpAccess).HasColumnName("ip_access");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DirectusSession>(entity =>
        {
            entity.HasKey(e => e.Token).HasName("directus_sessions_pkey");

            entity.ToTable("directus_sessions");

            entity.Property(e => e.Token)
                .HasMaxLength(64)
                .HasColumnName("token");
            entity.Property(e => e.Expires).HasColumnName("expires");
            entity.Property(e => e.Ip)
                .HasMaxLength(255)
                .HasColumnName("ip");
            entity.Property(e => e.Origin)
                .HasMaxLength(255)
                .HasColumnName("origin");
            entity.Property(e => e.Share).HasColumnName("share");
            entity.Property(e => e.User).HasColumnName("user");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(255)
                .HasColumnName("user_agent");

            entity.HasOne(d => d.ShareNavigation).WithMany(p => p.DirectusSessions)
                .HasForeignKey(d => d.Share)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("directus_sessions_share_foreign");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.DirectusSessions)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("directus_sessions_user_foreign");
        });

        modelBuilder.Entity<DirectusSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__directus__3213E83F85AB3756");

            entity.ToTable("directus_settings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthLoginAttempts)
                .HasDefaultValueSql("('25')")
                .HasColumnName("auth_login_attempts");
            entity.Property(e => e.AuthPasswordPolicy)
                .HasMaxLength(100)
                .HasColumnName("auth_password_policy");
            entity.Property(e => e.Basemaps).HasColumnName("basemaps");
            entity.Property(e => e.CustomAspectRatios).HasColumnName("custom_aspect_ratios");
            entity.Property(e => e.CustomCss).HasColumnName("custom_css");
            entity.Property(e => e.DefaultLanguage)
                .HasMaxLength(255)
                .HasDefaultValueSql("('en-US')")
                .HasColumnName("default_language");
            entity.Property(e => e.MapboxKey)
                .HasMaxLength(255)
                .HasColumnName("mapbox_key");
            entity.Property(e => e.ModuleBar).HasColumnName("module_bar");
            entity.Property(e => e.ProjectColor)
                .HasMaxLength(50)
                .HasColumnName("project_color");
            entity.Property(e => e.ProjectDescriptor)
                .HasMaxLength(100)
                .HasColumnName("project_descriptor");
            entity.Property(e => e.ProjectLogo).HasColumnName("project_logo");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .HasDefaultValueSql("('Directus')")
                .HasColumnName("project_name");
            entity.Property(e => e.ProjectUrl)
                .HasMaxLength(255)
                .HasColumnName("project_url");
            entity.Property(e => e.PublicBackground).HasColumnName("public_background");
            entity.Property(e => e.PublicForeground).HasColumnName("public_foreground");
            entity.Property(e => e.PublicNote).HasColumnName("public_note");
            entity.Property(e => e.StorageAssetPresets).HasColumnName("storage_asset_presets");
            entity.Property(e => e.StorageAssetTransform)
                .HasMaxLength(7)
                .HasDefaultValueSql("('all')")
                .HasColumnName("storage_asset_transform");
            entity.Property(e => e.StorageDefaultFolder).HasColumnName("storage_default_folder");
            entity.Property(e => e.TranslationStrings).HasColumnName("translation_strings");

            entity.HasOne(d => d.ProjectLogoNavigation).WithMany(p => p.DirectusSettingProjectLogoNavigations)
                .HasForeignKey(d => d.ProjectLogo)
                .HasConstraintName("directus_settings_project_logo_foreign");

            entity.HasOne(d => d.PublicBackgroundNavigation).WithMany(p => p.DirectusSettingPublicBackgroundNavigations)
                .HasForeignKey(d => d.PublicBackground)
                .HasConstraintName("directus_settings_public_background_foreign");

            entity.HasOne(d => d.PublicForegroundNavigation).WithMany(p => p.DirectusSettingPublicForegroundNavigations)
                .HasForeignKey(d => d.PublicForeground)
                .HasConstraintName("directus_settings_public_foreground_foreign");

            entity.HasOne(d => d.StorageDefaultFolderNavigation).WithMany(p => p.DirectusSettings)
                .HasForeignKey(d => d.StorageDefaultFolder)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("directus_settings_storage_default_folder_foreign");
        });

        modelBuilder.Entity<DirectusShare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directus_shares_pkey");

            entity.ToTable("directus_shares");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Collection)
                .HasMaxLength(64)
                .HasColumnName("collection");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("date_created");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Item)
                .HasMaxLength(255)
                .HasColumnName("item");
            entity.Property(e => e.MaxUses).HasColumnName("max_uses");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.TimesUsed)
                .HasDefaultValueSql("('0')")
                .HasColumnName("times_used");
            entity.Property(e => e.UserCreated).HasColumnName("user_created");

            entity.HasOne(d => d.CollectionNavigation).WithMany(p => p.DirectusShares)
                .HasForeignKey(d => d.Collection)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("directus_shares_collection_foreign");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.DirectusShares)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("directus_shares_role_foreign");

            entity.HasOne(d => d.UserCreatedNavigation).WithMany(p => p.DirectusShares)
                .HasForeignKey(d => d.UserCreated)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("directus_shares_user_created_foreign");
        });

        modelBuilder.Entity<DirectusUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directus_users_pkey");

            entity.ToTable("directus_users");

            entity.HasIndex(e => e.Email, "directus_users_email_unique")
                .IsUnique()
                .HasFilter("([email] IS NOT NULL)");

            entity.HasIndex(e => e.ExternalIdentifier, "directus_users_external_identifier_unique")
                .IsUnique()
                .HasFilter("([external_identifier] IS NOT NULL)");

            entity.HasIndex(e => e.Token, "directus_users_token_unique")
                .IsUnique()
                .HasFilter("([token] IS NOT NULL)");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AuthData).HasColumnName("auth_data");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .HasColumnName("email");
            entity.Property(e => e.EmailNotifications)
                .HasDefaultValueSql("('1')")
                .HasColumnName("email_notifications");
            entity.Property(e => e.ExternalIdentifier)
                .HasMaxLength(255)
                .HasColumnName("external_identifier");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Language)
                .HasMaxLength(255)
                .HasColumnName("language");
            entity.Property(e => e.LastAccess).HasColumnName("last_access");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.LastPage)
                .HasMaxLength(255)
                .HasColumnName("last_page");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Provider)
                .HasMaxLength(128)
                .HasDefaultValueSql("('default')")
                .HasColumnName("provider");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Status)
                .HasMaxLength(16)
                .HasDefaultValueSql("('active')")
                .HasColumnName("status");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.TfaSecret)
                .HasMaxLength(255)
                .HasColumnName("tfa_secret");
            entity.Property(e => e.Theme)
                .HasMaxLength(20)
                .HasDefaultValueSql("('auto')")
                .HasColumnName("theme");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.DirectusUsers)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("directus_users_role_foreign");
        });

        modelBuilder.Entity<DirectusWebhook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__directus__3213E83FC6B4261F");

            entity.ToTable("directus_webhooks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Actions)
                .HasMaxLength(100)
                .HasColumnName("actions");
            entity.Property(e => e.Collections)
                .HasMaxLength(255)
                .HasColumnName("collections");
            entity.Property(e => e.Data)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasColumnName("data");
            entity.Property(e => e.Headers).HasColumnName("headers");
            entity.Property(e => e.Method)
                .HasMaxLength(10)
                .HasDefaultValueSql("('POST')")
                .HasColumnName("method");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValueSql("('active')")
                .HasColumnName("status");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        modelBuilder.Entity<PortalsCredential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__portals___3213E83FB563380B");

            entity.ToTable("portals_credentials");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BaseUrl)
                .HasMaxLength(255)
                .HasColumnName("base_url");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Uin)
                .HasMaxLength(255)
                .HasColumnName("uin");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
