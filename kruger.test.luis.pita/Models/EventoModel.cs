using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Models
{
    public class EventoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El vehículo es requerido.")]
        [Display(Name = "Vehículo")]
        public int VehiculoId { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual VehiculoModel Vehiculo { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es requerida.")]
        public DateTime Fecha_ingreso { get; set; }

        public DateTime Fecha_salida { get; set; }

    }
}
