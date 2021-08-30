using System.Collections.Generic;

using EnglishTime.Data.Model;

namespace EnglishTime.Core.Provider.Interfaces
{
    public interface ITipProvider
    {
        ICollection<Tip> GetAllTips();
        Tip GetTip(int id);
        bool CreateTip(Tip tip);
        bool UpdateTip(Tip tip);
        bool DeleteTip(Tip tip);
    }
}