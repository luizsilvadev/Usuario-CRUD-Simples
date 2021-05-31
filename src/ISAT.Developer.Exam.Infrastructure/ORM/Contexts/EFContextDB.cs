using ISAT.Developer.Exam.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using ISAT.Developer.Exam.Core.Models;

namespace ISAT.Developer.Exam.Infrastructure.ORM.Contexts
{
    public class EFContextDB : DbContext
    {
        #region properties

        #endregion

        #region ctor

        public EFContextDB(DbContextOptions<EFContextDB> options) : base(options)
        {
        }

        public EFContextDB() { }

        #endregion

        #region dbsets

        public virtual DbSet<Usuario> Usuario { get; set; }

        #endregion

        #region methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.CreatedDate);
                entity.Property(e => e.LastUpdatedDate);
                entity.Property(e => e.LastAction);
                entity.Property(e => e.LastLoginAction);
                entity.Property(e => e.Nome).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Sobrenome).HasMaxLength(255).IsRequired();
                entity.HasIndex(e => new {e.Nome, e.Sobrenome}).IsUnique();
                entity.Property(e => e.Email).HasMaxLength(255).IsRequired();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Idade);
                entity.Ignore(e => e.ValidationResult);
                entity.Ignore(e => e.CascadeMode);
            });

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionStringUtility.GetConnectionString("SQLConnection"));
        }

        #endregion

    }
}