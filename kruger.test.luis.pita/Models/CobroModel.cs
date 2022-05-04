using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Models
{
    public class CobroModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El evento es requerido.")]
        [Display(Name = "Evento")]
        public int EventoId { get; set; }

        [ForeignKey("EventoId")]
        public virtual EventoModel Evento { get; set; }

        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "El valor es requerido.")]
        [Range(0.00, 9999999.99)]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "El estado es requerido.")]
        public bool Pagado { get; set; } = false;
    }
}
