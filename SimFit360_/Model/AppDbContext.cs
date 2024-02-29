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
                    Password = SecureHasher.Hash("1234"),
                },
                new User
                {
                    Id = 2,
                    Name = "Justin",
                    Password = SecureHasher.Hash("1234"),
                },
                new User
                {
                    Id = 3,
                    Name = "Remon",
                    Password = SecureHasher.Hash("1234"),
                },
                new User
                {
                    Id = 4,
                    Name = "Dani",
                    Password = SecureHasher.Hash("1234"),
                },
                new User
                {
                    Id = 5,
                    Name = "Bob",
                    Password = SecureHasher.Hash("1234"),
                });

            modelBuilder.Entity<Badge>().HasData(

                //Tier 1:
                new Badge
                {
                    Id = 1,
                    Name = "De Slak",
                    Description = "Ren 1km op de loopband",
                    AchievedAt = null,
                    Tier = 1,
                    MaxProgress = 1000,
                    Progress = null,
                },
                new Badge
                {
                    Id = 2,
                    Name = "Baby Runner",
                    Description = "Ren voor 15 minuten op moeilijkheidsgraad 1 of 2",
                    AchievedAt = null,
                    Tier = 1,
                    MaxProgress = 15,
                    Progress = null,
                },

                //Tier 2:
                new Badge
                {
                    Id = 3,
                    Name = "De Tijger",
                    Description = "Ren 5km op de loopband",
                    AchievedAt = null,
                    Tier = 2,
                    MaxProgress = 5000,
                    Progress = null,
                },
                new Badge
                {
                    Id = 4,
                    Name = "Adult Runner",
                    Description = "Ren voor 20 minuten op moeilijkheidsgraad 3 of 4",
                    AchievedAt = null,
                    Tier = 2,
                    MaxProgress = 20,
                    Progress = null,
                },

                //Tier 3:
                new Badge
                {
                    Id = 5,
                    Name = "Superman",
                    Description = "Ren 10km op de loopband",
                    AchievedAt = null,
                    Tier = 3,
                    MaxProgress = 10000,
                    Progress = null,
                },
                new Badge
                {
                    Id = 6,
                    Name = "Good Runner",
                    Description = "Ren voor 20 minuten op moeilijkheidsgraad 5 of 6",
                    AchievedAt = null,
                    Tier = 3,
                    MaxProgress = 20,
                    Progress = null,
                });

            modelBuilder.Entity<Session>().HasData(
                new Session
                {
                    Id = 1, 
                    UserId = 1, 
                    SessionPartId = 1,
                },
                new Session
                {
                    Id = 2,
                    UserId = 2,
                    SessionPartId = 2,
                },
                new Session
                {
                    Id = 3,
                    UserId = 3,
                    SessionPartId = 3,
                },
                new Session
                {
                    Id = 4,
                    UserId = 4,
                    SessionPartId = 4,
                },
                new Session
                {
                    Id = 5,
                    UserId = 5,
                    SessionPartId = 5,
                });

            modelBuilder.Entity<SessionPart>().HasData(
                new SessionPart
                {
                    Id = 1,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12, 
                    CreatedAt = DateTime.Now,
                    SessionId = 1,
                },
                new SessionPart
                {
                    Id = 2,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12,
                    CreatedAt = DateTime.Now,
                    SessionId = 2,
                },
                new SessionPart
                {
                    Id = 3,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12,
                    CreatedAt = DateTime.Now,
                    SessionId = 3,
                },
                new SessionPart
                {
                    Id = 4,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12,
                    CreatedAt = DateTime.Now,
                    SessionId = 4,
                },
                new SessionPart
                {
                    Id = 5,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12,
                    CreatedAt = DateTime.Now,
                    SessionId = 5,
                });
        }
    }
}
