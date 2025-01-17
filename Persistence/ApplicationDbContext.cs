﻿using BisleriumBloggers.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BisleriumBloggers.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<BlogImage> BlogImages { get; set; }

    public DbSet<BlogLog> BlogLogs { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<CommentLog> CommentLogs { get; set; }

    public DbSet<Notification> Notifications { get; set; }

    public DbSet<Reaction> Reactions { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);

        builder.Entity<Blog>(entity =>
        {
            entity.HasOne<User>(b => b.CreatedUser)
                .WithMany()
                .HasForeignKey(b => b.CreatedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.UpdatedUser)
                .WithMany()
                .HasForeignKey(b => b.LastModifiedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.DeletedUser)
                .WithMany()
                .HasForeignKey(b => b.DeletedBy)
                .IsRequired(false);
        });

        builder.Entity<BlogImage>(entity =>
        {
            entity.HasOne<User>(b => b.CreatedUser)
                .WithMany()
                .HasForeignKey(b => b.CreatedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.UpdatedUser)
                .WithMany()
                .HasForeignKey(b => b.LastModifiedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.DeletedUser)
                .WithMany()
                .HasForeignKey(b => b.DeletedBy)
                .IsRequired(false);
        });

        builder.Entity<BlogLog>(entity =>
        {
            entity.HasOne<User>(b => b.CreatedUser)
                .WithMany()
                .HasForeignKey(b => b.CreatedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.UpdatedUser)
                .WithMany()
                .HasForeignKey(b => b.LastModifiedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.DeletedUser)
                .WithMany()
                .HasForeignKey(b => b.DeletedBy)
                .IsRequired(false);
        });

        builder.Entity<Comment>(entity =>
        {
            entity.HasOne<User>(b => b.CreatedUser)
                .WithMany()
                .HasForeignKey(b => b.CreatedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.UpdatedUser)
                .WithMany()
                .HasForeignKey(b => b.LastModifiedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.DeletedUser)
                .WithMany()
                .HasForeignKey(b => b.DeletedBy)
                .IsRequired(false);
        });

        builder.Entity<CommentLog>(entity =>
        {
            entity.HasOne<User>(b => b.CreatedUser)
                .WithMany()
                .HasForeignKey(b => b.CreatedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.UpdatedUser)
                .WithMany()
                .HasForeignKey(b => b.LastModifiedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.DeletedUser)
                .WithMany()
                .HasForeignKey(b => b.DeletedBy)
                .IsRequired(false);
        });

        builder.Entity<Notification>(entity =>
        {
            entity.HasOne<User>(b => b.CreatedUser)
                .WithMany()
                .HasForeignKey(b => b.CreatedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.UpdatedUser)
                .WithMany()
                .HasForeignKey(b => b.LastModifiedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.DeletedUser)
                .WithMany()
                .HasForeignKey(b => b.DeletedBy)
                .IsRequired(false);

            entity.HasOne<User>(n => n.Receiver)
                .WithMany()
                .HasForeignKey(n => n.ReceiverId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<User>(n => n.Sender)
                .WithMany()
                .HasForeignKey(n => n.SenderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Reaction>(entity =>
        {
            entity.HasOne<User>(b => b.CreatedUser)
                .WithMany()
                .HasForeignKey(b => b.CreatedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.UpdatedUser)
                .WithMany()
                .HasForeignKey(b => b.LastModifiedBy)
                .IsRequired(false);

            entity.HasOne<User>(b => b.DeletedUser)
                .WithMany()
                .HasForeignKey(b => b.DeletedBy)
                .IsRequired(false);
        });
    }
}