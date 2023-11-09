namespace  src.Models;

public class Tarea
{
    public Guid TareaId { get; set; }
    public Guid CategoriaId { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public EnumPrioridad Prioridad { get; set; }
    public DateTime FechaCreacion { get; set; }
    public virtual Categoria Categoria { get; set; }
    public string Resumen { get; set; }
}

public enum EnumPrioridad {
    Baja,
    Media,
    Alta
}