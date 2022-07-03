using System.Linq;
using System.Threading.Tasks;
using EtdCrm.Domain.Etd;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace EtdCrm.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class EtdCrmDbContext :
    AbpDbContext<EtdCrmDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    #region Etd Entities

    public DbSet<Domain.Etd.RequestForm> RequestForms { get; set; }
    public DbSet<Domain.Etd.RequestFormTreatment> RequestFormTreatments { get; set; }
    public DbSet<Domain.Etd.Document> Documents { get; set; }
    public DbSet<Domain.Etd.DocumentFile> DocumentFiles { get; set; }
    public DbSet<Domain.Etd.Treatment> Treatments { get; set; }
    public DbSet<Domain.Etd.Doctor> Doctors { get; set; }
    public DbSet<Domain.Etd.Note> Notes { get; set; }
    public DbSet<Domain.Etd.NoteSub> NoteSubs { get; set; }

    #endregion Etd Entities


    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }


    #endregion

    public EtdCrmDbContext(DbContextOptions<EtdCrmDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();


        #region Etd Entities Configration

        builder.Entity<RequestForm>(b =>
        {
            b.ToTable("EtdRequestForm");
            b.Property(a => a.Status).IsRequired();
            b.Property(a => a.Type).IsRequired();

            b.Ignore(c => c.ExtraProperties);
            b.ConfigureByConvention();
        });


        builder.Entity<RequestFormTreatment>(b =>
        {
            b.ToTable("EtdRequestFormTreatment");
            b.HasMany(a => a.Documents).WithOne(b => b.RequestFormTreatment).HasForeignKey(c => c.RequestFormTreatmentId);
            b.HasMany(a => a.Notes).WithOne(b => b.RequestFormTreatment).HasForeignKey(c => c.RequestFormTreatmentId);

            b.Ignore(c => c.ExtraProperties);
            b.ConfigureByConvention();
        });





        builder.Entity<Domain.Etd.Treatment>(b =>
        {
            b.ToTable("EtdTreatment");
            b.Property(a => a.Name).HasMaxLength(100).IsRequired();
            b.Property(a => a.OrderId).IsRequired();
            b.HasMany(a => a.TreatmentSub).WithOne(b => b.Treatment).HasForeignKey(c => c.TreatmentId).IsRequired();

            b.Ignore(c => c.ExtraProperties);
            b.ConfigureByConvention();
        });

        builder.Entity<Domain.Etd.TreatmentSub>(b =>
        {
            b.ToTable("EtdTreatmentSub");
            b.Property(a => a.Name).HasMaxLength(100).IsRequired();
            b.Property(a => a.OrderId).IsRequired();

            b.Ignore(c => c.ExtraProperties);
            b.ConfigureByConvention();
        });


        builder.Entity<Domain.Etd.Document>(b =>
        {
            b.ToTable("EtdDocument");
            b.Property(x => x.Name).HasMaxLength(250).IsRequired();
            b.HasMany(b => b.DocumentFiles).WithOne(c => c.Document).HasForeignKey(n => n.DocumentId);
            b.Ignore(c => c.ExtraProperties);
            b.ConfigureByConvention();
        });

        builder.Entity<Domain.Etd.DocumentFile>(b =>
        {
            b.ToTable("EtdDocumentFile");
            b.Property(a => a.UrlPath).IsRequired();
            b.Property(a => a.OrderId).IsRequired();
            b.Ignore(c => c.ExtraProperties);
            b.ConfigureByConvention();
        });


        builder.Entity<Domain.Etd.Doctor>(b =>
        {
            b.ToTable("EtdDoctor");
            b.Property(a => a.BirthDay).IsRequired();
            b.Property(a => a.Gender).IsRequired();
            b.Property(a => a.Name).IsRequired();
            b.Property(a => a.Surname).IsRequired();
            b.HasMany(a => a.Documents).WithOne(b => b.Doctor).HasForeignKey(c => c.DoctorId);

            b.Ignore(c => c.ExtraProperties);
            b.ConfigureByConvention();
        });


        builder.Entity<Domain.Etd.Note>(b =>
        {
            b.ToTable("EtdNote");
            b.Property(x => x.Name).HasMaxLength(250).IsRequired();
            b.HasMany(b => b.NoteSubs).WithOne(c => c.Note).HasForeignKey(n => n.NoteId);
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.AbpUserId);
            b.Ignore(t => t.AbpUser);
            b.Ignore(c => c.ExtraProperties);
            b.ConfigureByConvention();
        });


        builder.Entity<Domain.Etd.NoteSub>(b =>
        {
            b.ToTable("EtdNoteSub");
            b.Property(a => a.Description).IsRequired();
            b.Ignore(c => c.ExtraProperties);
            b.ConfigureByConvention();
        });


        #endregion Etd Entities Configration

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(EtdCrmConsts.DbTablePrefix + "YourEntities", EtdCrmConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
