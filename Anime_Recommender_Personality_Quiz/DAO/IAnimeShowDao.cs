using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anime_Recommendation_Personality_Quiz.Models;

namespace Anime_Recommendation_Personality_Quiz.DAO
{
    public interface IAnimeShowDao
    {
        /// <summary>
        /// Retreieves all anime shows, maps them into c# objects and returns them in a list.
        /// </summary>
        /// <returns></returns>
        List<AnimeShow> GetAnimeShows();
    }
}
