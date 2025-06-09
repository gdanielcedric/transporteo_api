using Microsoft.EntityFrameworkCore;
using Transporteo.Models.Entities;

namespace Transporteo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Chauffeur> Chauffeurs { get; set; }
        public DbSet<Ligne> Lignes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Paiement> Paiements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unicité de l'email utilisateur
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // ========================
            // Relations pour Ticket.cs
            // ========================
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany() // à définir si tu veux une ICollection<Ticket> dans User
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Voyage)
                .WithMany() // ou .WithMany(v => v.Tickets) si défini dans Voyage
                .HasForeignKey(t => t.VoyageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Transaction)
                .WithMany() // à définir si inverse
                .HasForeignKey(t => t.TransactionId)
                .OnDelete(DeleteBehavior.SetNull);

            // =============================
            // Relations pour Reservation.cs
            // =============================
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Voyage)
                .WithMany() // ou .WithMany(v => v.Reservations)
                .HasForeignKey(r => r.VoyageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .Property(r => r.DateReservation);

            // ===========================
            // Relations pour Voyage.cs
            // ===========================

            modelBuilder.Entity<Voyage>()
                .HasOne(v => v.Ligne)
                .WithMany() // ou .WithMany(l => l.Voyages)
                .HasForeignKey(v => v.LigneId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Voyage>()
                .HasOne(v => v.Bus)
                .WithMany() // ou .WithMany(b => b.Voyages)
                .HasForeignKey(v => v.BusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Voyage>()
                .HasOne(v => v.Chauffeur)
                .WithMany() // ou .WithMany(c => c.Voyages)
                .HasForeignKey(v => v.ChauffeurId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
