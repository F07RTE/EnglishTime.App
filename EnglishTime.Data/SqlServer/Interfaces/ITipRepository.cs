using System.Collections.Generic;

using EnglishTime.Data.Model;

namespace EnglishTime.Data.SqlServer.Interfaces
{
    public interface ITipRepository
    {
        ICollection<Tip> GetAll();
        Tip Get(int id);
        void Create(Tip tip);
        void Update(Tip tip);
        void Delete(Tip tip);
        bool SaveChanges();
    }
}