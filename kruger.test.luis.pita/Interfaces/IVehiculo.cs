using kruger.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Interfaces
{
    public interface IVehiculo
    {
        IEnumerable<VehiculoModel> GetItems();
        VehiculoModel GetItem(string? placa);
        VehiculoModel Create(VehiculoModel vehiculo);
        VehiculoModel Edit(VehiculoModel vehiculo);
        VehiculoModel Delete(VehiculoModel vehiculo);
    }
}
