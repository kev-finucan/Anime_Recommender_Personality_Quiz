using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;
using Anime_Recommendation_Personality_Quiz.DAO;
using System.IO;

namespace Anime_Recommendation_Personality_Quiz
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = "Data Source=DESKTOP-DFP2E16\\SERVER;Initial Catalog=Anime_Quiz;Integrated Security=True"; //configuration.GetConnectionString("Anime_Quiz");

            IAnimeShowDao animeShowDao = new AnimeShowSqlDao(connectionString);
            IQuizQuestionDao quizQuestionDao = new QuizQuestionSqlDao(connectionString);
            IAnswerDao answerDao = new AnswerSqlDao(connectionString);

            AnimeQuizCLI application = new AnimeQuizCLI(animeShowDao, quizQuestionDao, answerDao);
            application.Run();


        }
    }
}
