using Microsoft.EntityFrameworkCore;


namespace src.Models
{
    public class TareasContext : DbContext
    {
        public TareasContext(DbContextOptions<TareasContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Categoria>().HasKey(p => p.CategoriaId);
            modelBuilder.Entity<Categoria>().Property(p => p.Nombre).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Categoria>().Property(p => p.Descripcion).HasMaxLength(200);
            modelBuilder.Entity<Categoria>().Property(p => p.Peso);

            modelBuilder.Entity<Tarea>().ToTable("Tarea");
            modelBuilder.Entity<Tarea>().HasKey(p => p.TareaId);
            modelBuilder.Entity<Tarea>().HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            modelBuilder.Entity<Tarea>().Property(p => p.Titulo).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Tarea>().Property(p => p.Descripcion).HasMaxLength(300);
            modelBuilder.Entity<Tarea>().Property(p => p.Prioridad);
            modelBuilder.Entity<Tarea>().Property(p => p.FechaCreacion).IsRequired();
            modelBuilder.Entity<Tarea>().Ignore(p => p.Resumen);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
    }
}
