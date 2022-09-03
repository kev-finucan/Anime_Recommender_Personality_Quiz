using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anime_Recommendation_Personality_Quiz.Models;
using System.Data.SqlClient;


namespace Anime_Recommendation_Personality_Quiz.DAO
{
    public class AnswerSqlDao : IAnswerDao
    {
        private readonly string dbConnectionString;

        public AnswerSqlDao(string dbConnString)
        {
            dbConnectionString = dbConnString;
        }

        public List<Answer> GetAnswers()
        {
            /// Gets all quiz questions' answers from the data source.
            /// </summary>
            /// <returns>All the quiz questions' answers as objects in a List.</returns>

            Answer answer = null;
            List<Answer> answers = new List<Answer>();
            using (SqlConnection conn = new SqlConnection(dbConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT answer_id, question_id, answer_text, sincerity_vs_satire_impact, 
                                                light_vs_heavy_impact, surface_vs_depth_impact, optimism_vs_pessimism_impact, 
                                                fantasy_vs_reality_impact, sentimentality_impact, humor_impact, romance_impact, 
                                                controversy_impact FROM answers;", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    answer = new Answer(Convert.ToInt32(reader["answer_id"]), Convert.ToInt32(reader["question_id"]), 
                                        Convert.ToString(reader["answer_text"]), Convert.ToInt32(reader["sincerity_vs_satire_impact"]), 
                                        Convert.ToInt32(reader["light_vs_heavy_impact"]), Convert.ToInt32(reader["surface_vs_depth_impact"]), 
                                        Convert.ToInt32(reader["optimism_vs_pessimism_impact"]), Convert.ToInt32(reader["fantasy_vs_reality_impact"]), 
                                        Convert.ToInt32(reader["sentimentality_impact"]), Convert.ToInt32(reader["humor_impact"]), 
                                        Convert.ToInt32(reader["romance_impact"]), Convert.ToInt32(reader["controversy_impact"]));

                    answers.Add(answer);
                }
            }
            return answers;
        }
    }
}
