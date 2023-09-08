using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WeOwnAPI.Database;

public partial class WeOwnContext : DbContext
{
    public WeOwnContext()
    {
    }

    public WeOwnContext(DbContextOptions<WeOwnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MovieAndTvShow> MovieAndTvShows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=WeOwn;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieAndTvShow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MovieAnd__3214EC27FBA7CCFD");

            entity.ToTable("MovieAndTvShow");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cast)
                .IsUnicode(false)
                .HasColumnName("cast");
            entity.Property(e => e.Country)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("date_added");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Director)
                .IsUnicode(false)
                .HasColumnName("director");
            entity.Property(e => e.Duration)
                .IsUnicode(false)
                .HasColumnName("duration");
            entity.Property(e => e.ListedIn)
                .IsUnicode(false)
                .HasColumnName("listed_in");
            entity.Property(e => e.Rating)
                .IsUnicode(false)
                .HasColumnName("rating");
            entity.Property(e => e.ReleaseYear).HasColumnName("release_year");
            entity.Property(e => e.ShowId)
                .IsUnicode(false)
                .HasColumnName("show_id");
            entity.Property(e => e.Title)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
