using System.Threading.Tasks;

namespace EnglishTime.WebBlazor.Pages.Tip.Shared
{
    public interface ITipService
    {
        Task<TipDto[]> GetAllTips();
    }
}