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

    protected override void OnModelCreating(ModelBuilder builder)
    {
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
