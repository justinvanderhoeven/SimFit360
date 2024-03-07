using Microsoft.EntityFrameworkCore;
using SimFit360_.Model;
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
        public DbSet<UserBadge> UserBadges { get; set; }

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

            modelBuilder.Entity<Session>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<SessionPart>()
                .HasOne(sp => sp.Session)
                .WithMany(s => s.SessionParts)
                .HasForeignKey(sp => sp.SessionId);

            modelBuilder.Entity<Badge>()
                .HasMany(b => b.Users)
                .WithMany(u => u.Badges)
                .UsingEntity<UserBadge>();
                

            modelBuilder.Entity<User>().HasData(

                // Users (Sporter)
                new User
                {
                    Id = 1,
                    Name = "Fred",
                    Password = "1111",
                },
                new User
                {
                    Id = 2,
                    Name = "Justin",
                    Password = "1112",
                },
                new User
                {
                    Id = 3,
                    Name = "Remon",
                    Password = "1113",
                },
                new User
                {
                    Id = 4,
                    Name = "Dani",
                    Password = "1114",
                },
                new User
                {
                    Id = 5,
                    Name = "Bob",
                    Password = "1115",
                });

            modelBuilder.Entity<Badge>().HasData(

                //Tier 1:
                new Badge
                {
                    Id = 1,
                    Name = "De Slak",
                    Description = "Ren 1km op de loopband",
                    Tier = 1,
                    MaxProgress = 1000,
                },
                new Badge
                {
                    Id = 2,
                    Name = "Baby Runner",
                    Description = "Ren voor 15 minuten op moeilijkheidsgraad 1 of 2",
                    Tier = 1,
                    MaxProgress = 15,
                },

                //Tier 2:
                new Badge
                {
                    Id = 3,
                    Name = "De Tijger",
                    Description = "Ren 5km op de loopband",
                    Tier = 2,
                    MaxProgress = 5000,
                },
                new Badge
                {
                    Id = 4,
                    Name = "Adult Runner",
                    Description = "Ren voor 20 minuten op moeilijkheidsgraad 3 of 4",
                    Tier = 2,
                    MaxProgress = 20,
                },

                //Tier 3:
                new Badge
                {
                    Id = 5,
                    Name = "Superman",
                    Description = "Ren 10km op de loopband",
                    Tier = 3,
                    MaxProgress = 10000,
                },
                new Badge
                {
                    Id = 6,
                    Name = "Good Runner",
                    Description = "Ren voor 20 minuten op moeilijkheidsgraad 5 of 6",
                    Tier = 3,
                    MaxProgress = 20,
                });

            modelBuilder.Entity<Session>().HasData(
                new Session
                {
                    Id = 1, 
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                },
                new Session
                {
                    Id = 2,
                    UserId = 2,
                    CreatedAt = DateTime.Now,
                },
                new Session
                {
                    Id = 3,
                    UserId = 3,
                    CreatedAt = DateTime.Now,
                },
                new Session
                {
                    Id = 4,
                    UserId = 4,
                    CreatedAt = DateTime.Now,
                },
                new Session
                {
                    Id = 5,
                    UserId = 5,
                    CreatedAt = DateTime.Now,
                });

            modelBuilder.Entity<SessionPart>().HasData(
                new SessionPart
                {
                    Id = 1,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12, 
                    SessionId = 1,
                },
                new SessionPart
                {
                    Id = 2,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12,
                    SessionId = 2,
                },
                new SessionPart
                {
                    Id = 3,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12,
                    SessionId = 3,
                },
                new SessionPart
                {
                    Id = 4,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12,
                    SessionId = 4,
                },
                new SessionPart
                {
                    Id = 5,
                    Time = 200,
                    DifficultyLevel = 1,
                    DistanceRan = 12,
                    SessionId = 5,
                });

            modelBuilder.Entity<UserBadge>().HasData(
                new UserBadge
                {
                    Id = 1,
                    AchievedAt = DateTime.Now,
                    BadgeId = 1,
                    UserId = 1,
                });
        }
    }
}
