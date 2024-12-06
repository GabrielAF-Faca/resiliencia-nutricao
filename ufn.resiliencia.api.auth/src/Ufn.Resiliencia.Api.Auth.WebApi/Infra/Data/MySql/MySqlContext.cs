using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Ufn.Resiliencia.Api.Auth.WebApi.Domain.Entities.User;
using Ufn.Resiliencia.Api.Auth.WebApi.Infra.Extensions;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Infra.Data.MySql;

public class MySqlContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>
{
    public MySqlContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable("users");
            entity.HasIndex(x => x.UserName).HasDatabaseName("UsernameIndex");
        });

        builder.Entity<IdentityRole<string>>(entity =>
        {
            entity.ToTable("roles");
        });

        builder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable("user_claims");
        });

        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable("user_login");
        });

        builder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.ToTable("role_claims");
        });

        builder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable("user_roles");
        });

        builder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable("user_token");
        });

        foreach (var entity in builder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnBaseName().ToSnakeCase());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToSnakeCase());
            }

            foreach (var key in entity.GetForeignKeys())
            {
                key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.Name.ToSnakeCase());
            }
        }

        PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

        ApplicationUser admin = new ApplicationUser
        {
            UserName = "teste@teste.com",
            NormalizedUserName = "TESTE@TESTE.COM",
            Email = "teste@teste.com",
            NormalizedEmail = "TESTE@TESTE.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            Id = Guid.NewGuid().ToString(),
            FirstName = "Cássio",
            LastName = "Gamarra",
            IsBlocked = false,
        };
        admin.PasswordHash = hasher.HashPassword(admin, "Nutri@123");
        builder.Entity<ApplicationUser>().HasData(admin);

        var adminRoleId = Guid.NewGuid().ToString();

        builder.Entity<IdentityRole<string>>().HasData(
                new IdentityRole<string>
                {
                    Id = adminRoleId,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
            );

        builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = admin.Id }
            );
    }
}