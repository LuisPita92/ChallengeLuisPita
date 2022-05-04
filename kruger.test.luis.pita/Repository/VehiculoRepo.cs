using kruger.test.luis.pita.Data;
using kruger.test.luis.pita.Interfaces;
using kruger.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Repository
{
    public class VehiculoRepo : IVehiculo
    {
        private readonly ApplicationDbContext _context;

        public VehiculoRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public VehiculoModel Create(VehiculoModel vehiculo)
        {
            _context.tbVehiculo.Add(vehiculo);
            _context.SaveChanges();
            return vehiculo;
        }

        public VehiculoModel Delete(VehiculoModel vehiculo)
        {
            _context.tbVehiculo.Remove(vehiculo);
            _context.SaveChanges();
            return vehiculo;
        }

        public VehiculoModel Edit(VehiculoModel vehiculo)
        {
            _context.tbVehiculo.Update(vehiculo);
            _context.SaveChanges();
            return vehiculo;
        }

        public VehiculoModel GetItem(string? placa)
        {
            VehiculoModel returnVehiculo = _context.tbVehiculo.Where(u => u.Placa == placa).FirstOrDefault();
            return returnVehiculo;
        }

        public IEnumerable<VehiculoModel> GetItems()
        {
            IEnumerable<VehiculoModel> returnVehiculo = _context.tbVehiculo.ToList();
            return returnVehiculo;
        }
    }
}
