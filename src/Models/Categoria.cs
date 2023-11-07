using System.ComponentModel.DataAnnotations;

namespace src.Models;

public class Categoria {

    [Key]
    public Guid CategoriaId { get; private set; }

    [Required]
    [MaxLength(150)]
    public String Nombre { get; private set; }

    public String Descripcion { get; private set; }

    public virtual ICollection<Tarea> Tareas { get; set; }
}