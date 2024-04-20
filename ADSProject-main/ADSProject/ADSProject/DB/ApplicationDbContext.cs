using ADSProject.Models;
using Microsoft.EntityFrameworkCore;


namespace ADSProject.DB
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        /*Con un DBSet se indica a EntifyFrameworkCore cuales van a ser las tablas que yo quiero tener en la base 
         de datos, y también le diremos en base a que modelos o entidades vamos a basar dchas tablas, por ejemplo*/

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesors { get; set; }
    }
}
