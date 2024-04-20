using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ADSProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(idMateria))]
    public class Materia
    {
        public int idMateria { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "la longitud del campo no puede ser mayor  a 50 caracteres.")]
        public string NombreMateria { get; set; } 
    }
}
