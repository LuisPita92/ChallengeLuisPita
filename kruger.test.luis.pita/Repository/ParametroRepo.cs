using kruger.test.luis.pita.Data;
using kruger.test.luis.pita.Interfaces;
using kruger.test.luis.pita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Repository
{
    public class ParametroRepo : IParametro
    {
        private readonly ApplicationDbContext _context;

        public ParametroRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ParametroModel Create(ParametroModel parametro)
        {
            _context.tbParametro.Add(parametro);
            _context.SaveChanges();
            return parametro;
        }

        public ParametroModel Delete(ParametroModel parametro)
        {
            _context.tbParametro.Remove(parametro);
            _context.SaveChanges();
            return parametro;
        }

        public ParametroModel Edit(ParametroModel parametro)
        {
            _context.tbParametro.Update(parametro);
            _context.SaveChanges();
            return parametro;
        }

        public string GetValue(string? nombre)
        {
            string returnParametro = _context.tbParametro.Where(u => u.Nombre == nombre).FirstOrDefault().Valor;
            return returnParametro;
        }

        public IEnumerable<ParametroModel> GetItems()
        {
            IEnumerable<ParametroModel> returnParametro = _context.tbParametro.ToList();
            return returnParametro;
        }
    }
}
