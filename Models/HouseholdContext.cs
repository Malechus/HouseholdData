using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HouseholdData.Models;

public partial class HouseholdContext : DbContext
{
	private string ConnectionString;
	
	public HouseholdContext(string connectionString)
	{
		ConnectionString = connectionString;
	}

	public virtual DbSet<DailyChore> DailyChores { get; set; }

	public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

	public virtual DbSet<Point> Points { get; set; }

	public virtual DbSet<TransactionalChore> TransactionalChores { get; set; }

	public virtual DbSet<WeeklyChore> WeeklyChores { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseMySql(ConnectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.UseCollation("utf8mb4_0900_ai_ci")
			.HasCharSet("utf8mb4");

		modelBuilder.Entity<DailyChore>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("daily_chore");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Active)
				.HasColumnType("bit(1)")
				.HasColumnName("active");
			entity.Property(e => e.ChoreName)
				.HasMaxLength(50)
				.HasColumnName("chore_name");
			entity.Property(e => e.Friday)
				.HasMaxLength(25)
				.HasColumnName("friday");
			entity.Property(e => e.Monday)
				.HasMaxLength(25)
				.HasColumnName("monday");
			entity.Property(e => e.Notes)
				.HasMaxLength(255)
				.HasColumnName("notes");
			entity.Property(e => e.Saturday)
				.HasMaxLength(25)
				.HasColumnName("saturday");
			entity.Property(e => e.Sunday)
				.HasMaxLength(25)
				.HasColumnName("sunday");
			entity.Property(e => e.Thursday)
				.HasMaxLength(25)
				.HasColumnName("thursday");
			entity.Property(e => e.Tuesday)
				.HasMaxLength(25)
				.HasColumnName("tuesday");
			entity.Property(e => e.Wednesday)
				.HasMaxLength(25)
				.HasColumnName("wednesday");
		});

		modelBuilder.Entity<Efmigrationshistory>(entity =>
		{
			entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

			entity.ToTable("__efmigrationshistory");

			entity.Property(e => e.MigrationId).HasMaxLength(150);
			entity.Property(e => e.ProductVersion).HasMaxLength(32);
		});

		modelBuilder.Entity<Point>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("points");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.ChorePoints).HasColumnName("chore_points");
			entity.Property(e => e.GreenGem).HasColumnName("green_gem");
			entity.Property(e => e.Name)
				.HasMaxLength(20)
				.HasColumnName("name");
			entity.Property(e => e.ProteinPoints).HasColumnName("protein_points");
			entity.Property(e => e.VegetablePoints).HasColumnName("vegetable_points");
		});

		modelBuilder.Entity<TransactionalChore>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("transactional_chore");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.ChoreId).HasColumnName("chore_id");
			entity.Property(e => e.Completed)
				.HasColumnType("bit(1)")
				.HasColumnName("completed");
			entity.Property(e => e.CompletedDatetime)
				.HasColumnType("datetime")
				.HasColumnName("completed_datetime");
			entity.Property(e => e.WeekOf).HasColumnName("week_of");
		});

		modelBuilder.Entity<WeeklyChore>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("weekly_chore");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Active)
				.HasColumnType("bit(1)")
				.HasColumnName("active");
			entity.Property(e => e.ChoreName)
				.HasMaxLength(50)
				.HasColumnName("chore_name");
			entity.Property(e => e.Notes)
				.HasMaxLength(255)
				.HasColumnName("notes");
			entity.Property(e => e.WeekFour)
				.HasMaxLength(25)
				.HasColumnName("week_four");
			entity.Property(e => e.WeekOne)
				.HasMaxLength(25)
				.HasColumnName("week_one");
			entity.Property(e => e.WeekThree)
				.HasMaxLength(25)
				.HasColumnName("week_three");
			entity.Property(e => e.WeekTwo)
				.HasMaxLength(25)
				.HasColumnName("week_two");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
