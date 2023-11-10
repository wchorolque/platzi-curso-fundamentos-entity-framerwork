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
            modelBuilder.Entity<Categoria>().Property(p => p.Descripcion).IsRequired(false).HasMaxLength(200);
            modelBuilder.Entity<Categoria>().Property(p => p.Peso);

            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() {
                CategoriaId = Guid.Parse("3ca96d4d-5b31-4637-a9e6-752395e97c01"), 
                Nombre = "Actividades Pendientes", 
                Peso = 20 });

            categoriasInit.Add(new Categoria() {
                CategoriaId = Guid.Parse("3ca96d4d-5b31-4637-a9e6-752395e97c02"), 
                Nombre = "Actividades Personales", 
                Peso = 40 });

            modelBuilder.Entity<Categoria>().HasData(categoriasInit);

            modelBuilder.Entity<Tarea>().ToTable("Tarea");
            modelBuilder.Entity<Tarea>().HasKey(p => p.TareaId);
            modelBuilder.Entity<Tarea>().HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            modelBuilder.Entity<Tarea>().Property(p => p.Titulo).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Tarea>().Property(p => p.Descripcion).IsRequired(false).HasMaxLength(300);
            modelBuilder.Entity<Tarea>().Property(p => p.Prioridad);
            modelBuilder.Entity<Tarea>().Property(p => p.FechaCreacion).IsRequired();
            modelBuilder.Entity<Tarea>().Ignore(p => p.Resumen);

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("3ca96d4d-5b31-4637-a9e6-752395e97f01"),
                CategoriaId = Guid.Parse("3ca96d4d-5b31-4637-a9e6-752395e97c01"),
                Prioridad = EnumPrioridad.Media,
                Titulo = "Pago de servicios públicos",
                FechaCreacion = DateTime.Now
            });
            tareasInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("3ca96d4d-5b31-4637-a9e6-752395e97f02"),
                CategoriaId = Guid.Parse("3ca96d4d-5b31-4637-a9e6-752395e97c01"),
                Prioridad = EnumPrioridad.Baja,
                Titulo = "Compra de productos",
                FechaCreacion = DateTime.Now
            });
            tareasInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("3ca96d4d-5b31-4637-a9e6-752395e97f03"),
                CategoriaId = Guid.Parse("3ca96d4d-5b31-4637-a9e6-752395e97c02"),
                Prioridad = EnumPrioridad.Media,
                Titulo = "Terminar de ver series",
                FechaCreacion = DateTime.Now
            });
            modelBuilder.Entity<Tarea>().HasData(tareasInit);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
    }
}
