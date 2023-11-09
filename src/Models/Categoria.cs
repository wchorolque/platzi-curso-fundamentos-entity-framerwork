namespace src.Models;

public class Categoria {

    public Guid CategoriaId { get; private set; }
    public String Nombre { get; private set; }
    public String Descripcion { get; private set; }
    public int Peso { get; set; }
    public virtual ICollection<Tarea> Tareas { get; set; }
}