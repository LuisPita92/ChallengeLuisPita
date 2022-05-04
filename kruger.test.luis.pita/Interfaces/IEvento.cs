using kruger.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Interfaces
{
    public interface IEvento
    {
        IEnumerable<EventoModel> GetItems();
        EventoModel GetItem(int? id);
        EventoModel Create(EventoModel evento);
        EventoModel Edit(EventoModel evento);
        EventoModel Delete(EventoModel evento);
    }
}
