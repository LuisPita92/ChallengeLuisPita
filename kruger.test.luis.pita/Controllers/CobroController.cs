using kruger.test.luis.pita.Interfaces;
using kruger.test.luis.pita.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CobroController : ControllerBase
    {
        private readonly ICobro _cobroRepo;
        private readonly IEvento _eventoRepo;
        private readonly IParametro _parametroRepo;

        public CobroController(ICobro cobroRepo, IEvento eventoRepo, IParametro parametroRepo)
        {
            _cobroRepo = cobroRepo;
            _eventoRepo = eventoRepo;
            _parametroRepo = parametroRepo;
        }

        [HttpPost("RegistrarSalida")]
        public IActionResult RegistrarSalida(CobroModel cobro)
        {
            if (cobro.Identificacion == null)
            {
                cobro.Identificacion = _parametroRepo.GetValue("IDENTIFICACION_FINAL");
                cobro.Nombre = _parametroRepo.GetValue("NOMBRE_FINAL");
                cobro.Email = _parametroRepo.GetValue("EMAIL_FINAL");
            }
            double.TryParse(_parametroRepo.GetValue("TARIFA"), out double tarifa);

            EventoModel _evento = _eventoRepo.GetItem(cobro.EventoId);
            _evento.Fecha_salida = DateTime.Now;

            double difHora = Math.Ceiling(_evento.Fecha_salida.Subtract(_evento.Fecha_ingreso).TotalHours);

            cobro.Valor = decimal.Parse((tarifa * difHora).ToString());
            cobro.Pagado = true;

            CobroModel cobroReturn = _cobroRepo.Create(cobro);

            _eventoRepo.Edit(_evento);

            return Ok(cobroReturn);

        }

    }
}
