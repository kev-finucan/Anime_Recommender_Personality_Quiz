using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anime_Recommendation_Personality_Quiz.Models;
using System.Data.SqlClient;


namespace Anime_Recommendation_Personality_Quiz.DAO
{
    public class AnimeShowSqlDao : IAnimeShowDao
    {
        private readonly string dbConnectionString;

        public AnimeShowSqlDao(string dbConnString)
        {
            dbConnectionString = dbConnString;
        }

        public List<AnimeShow> GetAnimeShows()
        {
            /// Gets all anime shows from the data source.
            /// </summary>
            /// <returns>All the anime shows as objects in a List.</returns>

            AnimeShow animeShow = null;
            List<AnimeShow> animeShows = new List<AnimeShow>();
            using (SqlConnection conn = new SqlConnection(dbConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT show_id, show_title, sincerity_vs_satire_score, 
                                                light_vs_heavy_score, surface_vs_depth_score, optimism_vs_pessimism_score, 
                                                fantasy_vs_reality_score, sentimentality_score, humor_score, romance_score, 
                                                controversy_score, description FROM shows;", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    animeShow = new AnimeShow(Convert.ToInt32(reader["show_id"]), Convert.ToString(reader["show_title"]), 
                                        Convert.ToInt32(reader["sincerity_vs_satire_score"]), Convert.ToInt32(reader["light_vs_heavy_score"]), 
                                        Convert.ToInt32(reader["surface_vs_depth_score"]), Convert.ToInt32(reader["optimism_vs_pessimism_score"]), 
                                        Convert.ToInt32(reader["fantasy_vs_reality_score"]), Convert.ToInt32(reader["sentimentality_score"]), 
                                        Convert.ToInt32(reader["humor_score"]), Convert.ToInt32(reader["romance_score"]), 
                                        Convert.ToInt32(reader["controversy_score"]), Convert.ToString(reader["description"]));

                    animeShows.Add(animeShow);
                }
            }
            return animeShows;
        }
    }
}
