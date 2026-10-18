using Microsoft.EntityFrameworkCore;
using SpanishWebApi.Models;

namespace SpanishWebApi.Data
{
    public class SpanishDbContext(DbContextOptions<SpanishDbContext> options) : DbContext(options)
    {
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Tense> Tenses => Set<Tense>();
        public DbSet<Verb> Verbs => Set<Verb>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Conjugation> Conjugations => Set<Conjugation>();
        public DbSet<ConjugationsWide> ConjugationsWide => Set<ConjugationsWide>();
        public DbSet<Dictionary> Dictionary => Set<Dictionary>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Verb>(e =>
            {
                e.ToTable("Verb");
                e.HasKey(v => v.VerbId);
                e.Property(v => v.VerbId).HasColumnName("id");
                e.Property(v => v.Infinitive).HasColumnName("infinitive");
                e.Property(v => v.Translation).HasColumnName("translation");
                e.Property(v => v.Pronunciation).HasColumnName("pronunciation");
            });

            modelBuilder.Entity<Tense>(e =>
            {
                e.ToTable("Tense");
                e.HasKey(t => t.TenseId);
                e.Property(t => t.TenseId).HasColumnName("id");
                e.Property(t => t.TenseText).HasColumnName("tense");
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(c => c.CategoryId);
                e.Property(c => c.CategoryId).HasColumnName("id");
                e.Property(c => c.CategoryText).HasColumnName("category");
            });

            modelBuilder.Entity<Subject>().ToTable("Subject");

            modelBuilder.Entity<Conjugation>(e =>
            {
                e.ToTable("Conjugation");
                e.HasIndex(c => new { c.SubjectId, c.TenseId, c.VerbId }).IsUnique();
                e.HasOne(c => c.Subject).WithMany().HasForeignKey(c => c.SubjectId);
                e.HasOne(c => c.Tense).WithMany().HasForeignKey(c => c.TenseId);
                e.HasOne(c => c.Verb).WithMany().HasForeignKey(c => c.VerbId);
            });

            modelBuilder.Entity<ConjugationsWide>(e =>
            {
                e.ToTable("ConjugationsWide");
                e.HasKey(c => c.ConjugationId);
                e.Property(c => c.ConjugationId).HasColumnName("id");
                e.Property(c => c.VerbId).HasColumnName("verb");
                e.Property(c => c.TenseId).HasColumnName("tense");
                e.Property(c => c.Yo).HasColumnName("yo");
                e.Property(c => c.Tu).HasColumnName("tu");
                e.Property(c => c.El).HasColumnName("el");
                e.Property(c => c.Nosotros).HasColumnName("nosotros");
                e.Property(c => c.Vosotros).HasColumnName("vosotros");
                e.Property(c => c.Ellos).HasColumnName("ellos");
                e.HasOne(c => c.Verb).WithMany().HasForeignKey(c => c.VerbId);
                e.HasOne(c => c.Tense).WithMany().HasForeignKey(c => c.TenseId);
            });

            modelBuilder.Entity<Dictionary>(e =>
            {
                e.ToTable("Dictionary");
                e.HasKey(d => d.WordId);
                e.Property(d => d.WordId).HasColumnName("id");
                e.Property(d => d.WordText).HasColumnName("word");
                e.Property(d => d.Translation).HasColumnName("translation");
                e.Property(d => d.Pronunciation).HasColumnName("pronunciation");
                e.Property(d => d.CategoryId).HasColumnName("category");
                e.Property(d => d.Gender).HasColumnName("gender");
                e.Property(d => d.ImageUrl).HasColumnName("image");
                e.HasOne(d => d.Category).WithMany().HasForeignKey(d => d.CategoryId);
            });
        }
    }
}