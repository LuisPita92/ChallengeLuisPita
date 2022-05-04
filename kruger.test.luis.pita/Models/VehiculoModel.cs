using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Models
{
    public class VehiculoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La placa es requerida.")]
        public string Placa { get; set; }

        [Display(Name = "Fecha de creación")]
        [Required(ErrorMessage = "La fecha de creación es requerida.")]
        public DateTime Fecha_creacion { get; set; }
    }
}
