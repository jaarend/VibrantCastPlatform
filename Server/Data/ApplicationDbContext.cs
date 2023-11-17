using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using VibrantCastPlatform.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Server.Models;

namespace VibrantCastPlatform.Server.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) { }

    new public DbSet<ApplicationUser> Users {get; set;}

    public DbSet<Artwork> Artworks {get; set;}

    public DbSet<Inquiry> Inquiries {get; set;}
    public DbSet<Collection> Collections {get; set;}
    public DbSet<Experience> Experiences {get; set;}
    public DbSet<ExperienceType> ExperienceTypes {get; set;}

    //leaving out interactions right now

    public DbSet<MediumTag> MediumTags {get; set;}

    public DbSet<MembershipType> MembershipTypes { get; set; }

    public DbSet<OrgAccountInfo> OrgAccountInfo {get; set;}

    public DbSet<Organization> Organizations {get; set;}

    public DbSet<OrganizationUserMapping> OrganizationUserMapping {get; set;}

    public DbSet<UserAccountInfo> UserAccountInfo {get; set;}


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>().ToTable("Users");

        base.OnModelCreating(builder);
        builder.Entity<Artwork>() //creates mapping table between artwork and collection
            .HasMany(a => a.Collections)
            .WithMany(c => c.Artworks)
            .UsingEntity(j => j.ToTable("ArtworkCollectionMapping"));

        base.OnModelCreating(builder);
        builder.Entity<Artwork>() 
            .HasMany(a => a.Experiences)
            .WithMany(c => c.Artworks)
            .UsingEntity(j => j.ToTable("ArtworkExperienceMapping"));

        base.OnModelCreating(builder);
        builder.Entity<Artwork>() 
            .HasMany(a => a.MediumTags)
            .WithMany(c => c.Artworks)
            .UsingEntity(j => j.ToTable("ArtworkMediumTagMapping"));

    }
}
