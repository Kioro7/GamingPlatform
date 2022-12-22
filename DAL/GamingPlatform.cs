using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class GamingPlatform : DbContext
    {
        public GamingPlatform()
            : base("name=GamingPlatform")
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GamePurchase> GamePurchase { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Mode> Mode { get; set; }
        public virtual DbSet<StatusGamePurchase> StatusGamePurchase { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Game>()
                .Property(e => e.Developer)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.ImageLink)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.GamePurchase)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.Statistics)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GamePurchase>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Genre>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Game)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .HasMany(e => e.User2)
                .WithOptional(e => e.Message2)
                .HasForeignKey(e => e.MessageId);

            modelBuilder.Entity<Mode>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Mode>()
                .HasMany(e => e.Game)
                .WithRequired(e => e.Mode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusGamePurchase>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<StatusGamePurchase>()
                .HasMany(e => e.GamePurchase)
                .WithRequired(e => e.StatusGamePurchase)
                .HasForeignKey(e => e.StatusBuyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Nickname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<User>()
                .HasMany(e => e.GamePurchase)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Message1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.ReceiveId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Statistics)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .HasMany(e => e.User)
                .WithRequired(e => e.UserType)
                .WillCascadeOnDelete(false);
        }
    }
}
