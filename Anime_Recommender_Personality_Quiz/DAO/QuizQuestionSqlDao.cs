using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anime_Recommendation_Personality_Quiz.Models;
using System.Data.SqlClient;


namespace Anime_Recommendation_Personality_Quiz.DAO
{
    public class QuizQuestionSqlDao : IQuizQuestionDao
    {
        private readonly string dbConnectionString;

        public QuizQuestionSqlDao(string dbConnString)
        {
            dbConnectionString = dbConnString;
        }

        public List<QuizQuestion> GetQuizQuestions()
        {
            /// Gets all quiz questions from the data source.
            /// </summary>
            /// <returns>All the quiz questions as objects in a List.</returns>

            QuizQuestion quizQuestion = null;
            List<QuizQuestion> questions = new List<QuizQuestion>();
            using (SqlConnection conn = new SqlConnection(dbConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT question_id, question_text FROM questions;", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    quizQuestion = new QuizQuestion(Convert.ToInt32(reader["question_id"]),Convert.ToString(reader["question_text"]));

                    questions.Add(quizQuestion);
                }
            }
            return questions;
        }
    }
}

