using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BruggeKiest0_1.ViewModels;
using Refit;
namespace BruggeKiest0_1
{
    public interface API
    {
        [Get("/Voorstellen.json")]
        Task<List<dbVoorstel>> GetVoorstellen();

        [Get("/Voorstellen/{num}/Voor.json")]
        Task<int> GetLikes(int num);

        [Get("/Voorstellen/{num}/Tegen.json")]
        Task<int> GetDislikes(int num);

        [Get("/Voorstellen/{num}/Inhoud.json")]
        Task<string> GetInhoud(int num);

        [Put("/Voorstellen/{num}.json")]
        Task<dbVoorstel> LikeVoorstel(int num, [Body] dbVoorstel like);

        [Put("/Voorstellen/{num}.json")]
        Task<dbVoorstel> DislikeVoorstel(int num, [Body] dbVoorstel dislike);
    }
}