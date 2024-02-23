using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimFit360.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionPart> SessionParts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Go to the App.config.example file and then follow Instructions

            optionsBuilder.UseMySql(
                ConfigurationManager.ConnectionStrings["SimFit360"].ConnectionString,
                ServerVersion.Parse("5.7.33-winx64"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SessionParts)
                .WithMany(s => s.Users)
                .UsingEntity<Session>();

            modelBuilder.Entity<User>().HasData(

                // Users (Sporter)
                new User
                {
                    Id = 6,
                    Name = "Fred",
                    Password = SecureHasher.Hash("Fred"),
                });

            modelBuilder.Entity<Badge>().HasData(
                   new Badge
                   {
                       Id = 1,
                       Name = "De kikker",
                       Description = "Ren 1000m op de loopband",
                       AchievedAt = null,
                       Tier = 1,
                       MaxProgress = 1000,
                       Progress = null,
                   });

            modelBuilder.Entity<Session>().HasData(
                new Session
                {
                    Id = 1, 
                    UserId = 1, 
                    SessionPartId = 1,
                }
                );

            modelBuilder.Entity<SessionPart>().HasData(
                new SessionPart
                {
                    Id = 1,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12, 
                    CreatedAt = DateTime.Now,
                    SessionId = 1,
                }
                );
        }
    }
}
