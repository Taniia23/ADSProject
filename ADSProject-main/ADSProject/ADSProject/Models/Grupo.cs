using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ADSProject.Models

{
    [PrimaryKey(nameof(IdGrupo))]
    public class Grupo
    {
        public int IdGrupo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")] public int IdMateria { get; set; }
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int Ciclo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int Anio { get; set; }
    }
}
