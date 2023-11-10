using System.Text.Json.Serialization;

namespace src.Models;

public class Categoria {

    public Guid CategoriaId { get; set; }
    public String Nombre { get; set; }
    public String Descripcion { get; set; }
    public int Peso { get; set; }
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas { get; set; }
}