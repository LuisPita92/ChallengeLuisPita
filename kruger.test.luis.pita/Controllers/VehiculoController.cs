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
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculo _vehiculoRepo;

        public VehiculoController(IVehiculo vehiculoRepo)
        {
            _vehiculoRepo = vehiculoRepo;
        }

        [HttpGet("ReadAll")]
        public IActionResult ReadAll()
        {
            IEnumerable<VehiculoModel> lstVehiculo = _vehiculoRepo.GetItems();
            return Ok(lstVehiculo);
        }

        [HttpGet("ReadPlaca")]
        public IActionResult ReadPlaca(string placa)
        {
            VehiculoModel vehiculoReturn = _vehiculoRepo.GetItem(placa);
            return Ok(vehiculoReturn);
        }

        [HttpPost("Create")]
        public IActionResult Create(VehiculoModel vehiculo)
        {
            VehiculoModel vehiculoReturn = _vehiculoRepo.Create(vehiculo);
            return Ok(vehiculoReturn);
        }

    }
}
