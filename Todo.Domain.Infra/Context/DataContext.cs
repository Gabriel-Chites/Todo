using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {

    }

    public DbSet<TodoItem> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
             .Entity<TodoItem>()
             .ToTable("Todo");

        modelBuilder
            .Entity<TodoItem>()
            .Property(e => e.Id)
            .IsUnicode(false)
            .IsRequired();

        modelBuilder
            .Entity<TodoItem>()
            .Property(e => e.Title)
            .HasMaxLength(120)
            .IsUnicode(false)
            .HasColumnType("varchar(120)")
            .IsRequired();

        modelBuilder
            .Entity<TodoItem>()
            .Property(e => e.Date)
            .IsUnicode(false);

        modelBuilder
            .Entity<TodoItem>()
            .Property(e => e.Done)
            .HasColumnType("bit")
            .IsUnicode(false);

        modelBuilder
            .Entity<TodoItem>()
            .Property(e => e.Title)
            .HasMaxLength(120)
            .IsUnicode(false)
            .HasColumnType("varchar(120)")
            .IsRequired();
    }
}

