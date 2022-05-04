using kruger.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Interfaces
{
    public interface ICobro
    {
        IEnumerable<CobroModel> GetItems();
        CobroModel GetItem(int? eventoId);
        CobroModel Create(CobroModel cobro);
        CobroModel Edit(CobroModel cobro);
        CobroModel Delete(CobroModel cobro);
    }
}
