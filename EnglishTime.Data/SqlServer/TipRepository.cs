using System;
using System.Collections.Generic;
using System.Linq;

using EnglishTime.Data.Model;
using EnglishTime.Data.SqlServer.Interfaces;

namespace EnglishTime.Data.SqlServer
{
    public class TipRepository : ITipRepository
    {
        private DatabaseContext _context;
        public TipRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(Tip tip)
        {
            if (tip == null)
                throw new ArgumentNullException(nameof(tip));

            _context.Tip.Add(tip);
        }

        public void Delete(Tip tip)
        {
            if (tip == null)
                throw new ArgumentNullException(nameof(tip));

            _context.Tip.Remove(tip);
        }

        public Tip Get(int id)
        {
            return _context.Tip.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<Tip> GetAll()
        {
            return _context.Tip.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void Update(Tip tip)
        {
            if (tip == null)
                throw new ArgumentNullException(nameof(tip));

            _context.Tip.Update(tip);
        }
    }
}