using kruger.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Interfaces
{
    public interface IParametro
    {
        IEnumerable<ParametroModel> GetItems();
        string GetValue(string? nombre);
        ParametroModel Create(ParametroModel vehiculo);
        ParametroModel Edit(ParametroModel vehiculo);
        ParametroModel Delete(ParametroModel vehiculo);
    }
}
