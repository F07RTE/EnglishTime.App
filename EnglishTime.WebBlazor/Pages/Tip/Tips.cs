using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

using EnglishTime.WebBlazor.Pages.Tip.Shared;

namespace EnglishTime.WebBlazor.Pages.Tip
{
    public partial class Tips
    {
        [Inject]
        ITipService TipService { get; set; }
        
        public TipDto[] tips { get; set; }

        protected override async Task OnInitializedAsync()
        {
            tips = await TipService.GetAllTips();
        }
    }
}