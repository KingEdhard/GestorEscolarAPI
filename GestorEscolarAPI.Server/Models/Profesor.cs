namespace GestorEscolarAPI.Server.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Departamento { get; set; } = null!;
        public ICollection<Materia>? Materias { get; set; }
    }

}
