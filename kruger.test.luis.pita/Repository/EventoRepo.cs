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
    public class EventoRepo : IEvento
    {
        private readonly ApplicationDbContext _context;

        public EventoRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public EventoModel Create(EventoModel evento)
        {
            _context.tbEvento.Add(evento);
            _context.SaveChanges();
            return evento;
        }

        public EventoModel Delete(EventoModel evento)
        {
            _context.tbEvento.Remove(evento);
            _context.SaveChanges();
            return evento;
        }

        public EventoModel Edit(EventoModel evento)
        {
            _context.tbEvento.Update(evento);
            _context.SaveChanges();
            return evento;
        }

        public EventoModel GetItem(int? id)
        {
            EventoModel returnEvento = _context.tbEvento.Include(p => p.Vehiculo).Where(u => u.Id == id).FirstOrDefault();
            return returnEvento;
        }

        public IEnumerable<EventoModel> GetItems()
        {
            IEnumerable<EventoModel> returnEvento = _context.tbEvento.Include(p => p.Vehiculo).ToList();
            return returnEvento;
        }
    }
}
