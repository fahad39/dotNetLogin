using AspLoginApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspLoginApp.Areas.Identity.Data;

public class AspLoginAppContext : IdentityDbContext<AspLoginAppUser>
{
    public AspLoginAppContext(DbContextOptions<AspLoginAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserIdentityClass());
    }
}

public class ApplicationUserIdentityClass : IEntityTypeConfiguration<AspLoginAppUser>
{
    public void Configure(EntityTypeBuilder<AspLoginAppUser> builder)
    {
        builder.Property(x=>x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
    }
}