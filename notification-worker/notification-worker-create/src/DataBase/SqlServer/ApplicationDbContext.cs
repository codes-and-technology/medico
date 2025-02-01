﻿using CreateEntitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataBase.SqlServer;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;


    public ApplicationDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ConnectionString");
    }

    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<NotificationEntity> Notifications { get; set; }

    public DbSet<PendingNotificationEntity> PendingNotifications { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }


}
