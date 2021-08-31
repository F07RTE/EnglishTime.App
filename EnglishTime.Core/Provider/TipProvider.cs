using System.Collections.Generic;

using EnglishTime.Core.Provider.Interfaces;
using EnglishTime.Data.SqlServer.Interfaces;
using EnglishTime.Data.Model;

namespace EnglishTime.Core.Provider
{
    public class TipProvider : ITipProvider
    {

        private ITipRepository _tipRepository;

        public TipProvider(
            ITipRepository tipRepository
        )
        {
            _tipRepository = tipRepository;
        }

        public bool CreateTip(Tip tip)
        {
            _tipRepository.Create(tip);
            return _tipRepository.SaveChanges();
        }

        public bool DeleteTip(Tip tip)
        {
            _tipRepository.Delete(tip);
            return _tipRepository.SaveChanges();
        }

        public ICollection<Tip> GetAllTips()
        {
            return _tipRepository.GetAll();
        }

        public Tip GetTip(int id)
        {
            return _tipRepository.Get(id);
        }

        public bool UpdateTip(Tip tip)
        {
            _tipRepository.Update(tip);
            return _tipRepository.SaveChanges();
        }
    }
}