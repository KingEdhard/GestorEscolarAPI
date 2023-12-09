namespace GestorEscolarAPI.Server.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Grado { get; set; } = null!;
        public ICollection<Calificacion>? Calificaciones { get; set; }
    }

}
