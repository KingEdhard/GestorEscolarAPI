namespace GestorEscolarAPI.Server.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Semestre { get; set; } = null!;
        public int ProfesorId { get; set; }
        public Profesor? Profesor { get; set; }
        public ICollection<Calificacion>? Calificaciones { get; set; }
    }





}
