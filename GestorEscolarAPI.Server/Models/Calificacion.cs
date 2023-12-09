namespace GestorEscolarAPI.Server.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public int AlumnoId { get; set; }
        public Alumno? Alumno { get; set; }
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }
    }

}
