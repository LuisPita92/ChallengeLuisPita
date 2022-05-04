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
    public class EventoController : ControllerBase
    {
        private readonly IEvento _eventoRepo;
        private readonly IVehiculo _vehiculoRepo;

        public EventoController(IEvento eventoRepo, IVehiculo vehiculoRepo)
        {
            _eventoRepo = eventoRepo;
            _vehiculoRepo = vehiculoRepo;
        }

        [HttpPost("RegistrarIngreso")]
        public IActionResult RegistrarIngreso(string placa)
        {
            EventoModel evento = new EventoModel();
            evento.Fecha_ingreso = DateTime.Now;

            VehiculoModel vehiculo = _vehiculoRepo.GetItem(placa);

            if (vehiculo == null)
            {
                vehiculo = _vehiculoRepo.Create(new VehiculoModel() { Placa = placa, Fecha_creacion = DateTime.Now });
            }
            evento.VehiculoId = vehiculo.Id;

            EventoModel eventoReturn = _eventoRepo.Create(evento);

            return Ok(eventoReturn);
        }


    }
}
