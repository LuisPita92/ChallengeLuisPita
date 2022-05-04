using kruger.test.luis.pita.Data;
using kruger.test.luis.pita.Interfaces;
using kruger.test.luis.pita.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Repository
{
    public class CobroRepo : ICobro
    {
        private readonly ApplicationDbContext _context;

        public CobroRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public CobroModel Create(CobroModel cobro)
        {
            _context.tbCobro.Add(cobro);
            _context.SaveChanges();
            return cobro;
        }

        public CobroModel Delete(CobroModel cobro)
        {
            _context.tbCobro.Remove(cobro);
            _context.SaveChanges();
            return cobro;
        }

        public CobroModel Edit(CobroModel cobro)
        {
            _context.tbCobro.Update(cobro);
            _context.SaveChanges();
            return cobro;
        }

        public CobroModel GetItem(int? eventoId)
        {
            CobroModel returnCobro = _context.tbCobro.Include(p => p.Evento).Include(p => p.Evento.Vehiculo).Where(u => u.EventoId == eventoId).FirstOrDefault();
            return returnCobro;
        }

        public IEnumerable<CobroModel> GetItems()
        {
            IEnumerable<CobroModel> returnCobro = _context.tbCobro.Include(p => p.Evento).Include(p => p.Evento.Vehiculo).ToList();
            return returnCobro;
        }
    }
}
