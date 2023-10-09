using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskApp.Models;

public partial class TaskAppContext : DbContext
{
    public TaskAppContext()
    {
    }

    public TaskAppContext(DbContextOptions<TaskAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tasks> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SOEL-PC\\SQLEXPRESS; DataBase=TaskApp;Integrated Security=true; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PK__Tasks__9FCAD1C57FADB25A");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
