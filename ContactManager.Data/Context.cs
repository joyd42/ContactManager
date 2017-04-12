using ContactManager.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            
            DoeContactMappings(modelBuilder);           
            DoeOrganisatieMappings(modelBuilder);
            DoePersoonMappings(modelBuilder);
            DoeTelefoonMappings(modelBuilder);
            DoeAdresMappings(modelBuilder);

        }

        private static void DoeOrganisatieMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisatie>();
            modelBuilder.Entity<Organisatie>()
                .HasOne(o => o.ContactPersoon);
            modelBuilder.Entity<Organisatie>()
                .HasDiscriminator<string>("Discriminator");
        }

        private static void DoePersoonMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persoon>();
            modelBuilder.Entity<Persoon>()
                .Property(p => p.GeboorteDatum);
            modelBuilder.Entity<Persoon>()
                .Property(p => p.Mugshot);
            modelBuilder.Entity<Persoon>()
                .HasDiscriminator<string>("Discriminator");
        }

        private static void DoeTelefoonMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefoon>();
            modelBuilder.Entity<Telefoon>()
                .ToTable("Telefoon");
            modelBuilder.Entity<Telefoon>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Telefoon>()
                .Property(t => t.Naam);
            modelBuilder.Entity<Telefoon>()
                .Property(t => t.Nummer);
        }

        private static void DoeContactMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>();
            modelBuilder.Entity<Contact>()
                .ToTable("Contact");
            modelBuilder.Entity<Contact>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Contact>()
                .Property(c => c.Naam);
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Adres)
                .WithOne()
                .HasForeignKey<Adres>(a => a.Id);
            modelBuilder.Entity<Contact>()
                .HasMany(c => c.Telefoons);
        }

        private static void DoeAdresMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adres>();
            modelBuilder.Entity<Adres>()
                .ToTable("Adres");
            modelBuilder.Entity<Adres>()
                .HasKey(a => a.Id);
            
            modelBuilder.Entity<Adres>()
                .Property(a => a.Straat);
            modelBuilder.Entity<Adres>()
                .Property(a => a.Locatie);
            modelBuilder.Entity<Adres>()
                .Property(a => a.Land);


        }

        public DbSet<Contact> Contacten { get; set; }
    }
}
