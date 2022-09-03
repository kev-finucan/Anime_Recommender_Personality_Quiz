using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anime_Recommendation_Personality_Quiz.DAO;
using Anime_Recommendation_Personality_Quiz.Models;
using System.IO;

namespace Anime_Recommendation_Personality_Quiz
{
    public class AnimeQuizCLI
    {
        private readonly IAnimeShowDao animeShowDao;
        private readonly IQuizQuestionDao quizQuestionDao;
        private readonly IAnswerDao answerDao;

        // Declare lists for all anime shows, quiz questions, and answers from the d/b
        List<AnimeShow> animeShows;
        List<QuizQuestion> quizQuestions;
        List<Answer> answers;

        // Declare an instance of userPersonality representing the user
        UserPersonality userPersonality = new UserPersonality();

        // Declare an int for userSelection
        int userSelection = 0;

        // Declare a lowest incompatibility variable at max value
        int lowestIncompatibility = int.MaxValue;

        // Declare a list of show matches for the user
        List<AnimeShow> showMatches = new List<AnimeShow>();

        public AnimeQuizCLI(IAnimeShowDao animeShowDao, IQuizQuestionDao quizQuestionDao, IAnswerDao answerDao)
        {
            this.animeShowDao = animeShowDao;
            this.quizQuestionDao = quizQuestionDao;
            this.answerDao = answerDao;
        }

        public void Run()
        {

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear(); //required to make entire background the color
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Welcome to the world's greatest anime recommender quiz (if we do say so ourselves)...");
            Thread.Sleep(2000); //delays the script for 2 seconds in btwn so all text doesn't appear at once
            Console.WriteLine("And we do! (On a scale of 1-10, it's over 9,000!)");
            Thread.Sleep(2000);
            Console.WriteLine("Simply answer these 15 questions, and our system will learn the deepest secrets of your heart!");
            Thread.Sleep(2000);
            Console.WriteLine("But don't worry. We won't tell anybody. ;p ");
            Thread.Sleep(2000);
            Console.WriteLine("We'll just let you know your next anime obsession - believe it!");
            Thread.Sleep(2000);
            Console.WriteLine("So get ready, because here comes your first question...");

            instantiateData();

            Thread.Sleep(3000); 

            /*
             * The quiz runs within a foreach loop which prints the questions and answers, takes user input, 
             * and adjusts their personality class based on their answers.
            */
            foreach (QuizQuestion question in quizQuestions)
            {
                Console.WriteLine("\n************************");
                Console.WriteLine($"Question #{question.QuestionId}: "); 
                Console.WriteLine(GetWordWrappedTextBlock(question.QuestionText) + "\n");

                Thread.Sleep(3000);

                // Inner loop will access the list of answers associated with that question and print them
                for (int i = 0; i < question.Answers.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": ");
                    Console.WriteLine(GetWordWrappedTextBlock(question.Answers[i].AnswerText) + "\n");
                    Thread.Sleep(2000);

                }
                userSelection = promptForSelection(question.Answers.Count);

                // The answer the user selected will be at index userSelecion -1
                adjustUserPersonalityFromAnswer(question.Answers[userSelection - 1], userPersonality);
                userSelection = 0; // Redefined so promptForSelection will run 
            }

            userPersonality.adjustScoreOutliers();

            /*
             * After each question has been answered, the user's personality is fully completed on the same scales
             * as each anime show. Another loop compares the user's scales to the anime shows' scales and sets
             * an incompatibility score for each anime show based on aggregate disparity. It will also track the
             * lowest amount of incompatibility to determine the best show match(es) for the user.
            */
            foreach(AnimeShow show in animeShows)
            {
                int showIncompatibility = show.setAnimeShowIncompatibility(userPersonality);
                if(showIncompatibility < lowestIncompatibility)
                {
                    lowestIncompatibility = showIncompatibility;
                }
            }

            /*
             * Now that we have an incompatbility score for each show, and know the value of the lowest incompatibility, 
             * we can find all of the matches with that incompatability scoore to return to the user
            */
            foreach(AnimeShow show in animeShows)
            {
                if(show.IncompatibilityScore == lowestIncompatibility)
                {
                    showMatches.Add(show);
                }
            }

            Thread.Sleep(1000);
            Console.WriteLine("\n************************");
            Console.WriteLine("That's all of the questions we have for you!\nWhile the system calculates the results " 
                + "and finds your perfect anime match...\n"
                + "Here are some things we have learned about your personality:\n");
            Thread.Sleep(1500);

            List<string> personalityFeedback = userPersonality.generatePersonalityFeedback();

            foreach(string feedback in personalityFeedback)
            {
                Console.WriteLine(feedback);
                Thread.Sleep(2000);
            }

            Thread.Sleep(1000);
            Console.WriteLine("\n************************");
            Console.WriteLine("Get ready, because here comes your new favorite anime!");
            Thread.Sleep(2000);
            // Print only the first 3 matches if there are more than 3, both matches if 2, or the 1 and only
            if (showMatches.Count > 2)
            {
                Console.WriteLine("\nBased on your personality, we think these three anime shows will be perfect for you!\n");
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[0].ShowTitle));
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[0].ShowDescription) + "\n");
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[1].ShowTitle));
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[1].ShowDescription) + "\n");
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[2].ShowTitle));
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[2].ShowDescription) + "\n");
            }
            else if (showMatches.Count == 2) 
            {
                Console.WriteLine("\nWe found two great anime matches for your personality!\n");
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[0].ShowTitle));
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[0].ShowDescription) + "\n");
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[1].ShowTitle));
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[1].ShowDescription) + "\n");
            }
            else
            {
                Console.WriteLine("\nYou're a particular sort, but we found your one and only ideal anime match!\n");
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[0].ShowTitle));
                Console.WriteLine(GetWordWrappedTextBlock(showMatches[0].ShowDescription) + "\n");
            }
            Console.WriteLine("\n************************");
            Console.WriteLine("*Thanks for taking our quiz! We hope you enjoy your anime binging!* :D ");

        }

        public void instantiateData()
        {
            // Instantiate lists for all anime shows, quiz questions, and answers from the d/b
            animeShows = animeShowDao.GetAnimeShows();
            quizQuestions = quizQuestionDao.GetQuizQuestions();
            answers = answerDao.GetAnswers();

            /* 
             * This loop will populate a list of answers associated with each question and set them to that question's
             * Answers list property.
            */
            for (int i = 1; i <= quizQuestions.Count; i++)
            {
                List<Answer> questionAnswers = new List<Answer>();
                foreach (Answer answer in answers)
                {
                    if (answer.QuestionId == i)
                    {
                        questionAnswers.Add(answer);
                    }
                }
                quizQuestions[i - 1].Answers = questionAnswers;
            }
        }
        public int promptForSelection(int amountOfAnswers)
        {
            while (userSelection < 1 || userSelection > amountOfAnswers)
            {
                Console.WriteLine("**Please enter the number for your selection**: ");
                while (!int.TryParse(Console.ReadLine(), out userSelection))
                {
                    Console.WriteLine("Oops, we didn't catch that. Please enter the number for your selection: ");
                }
                if (userSelection < 1 || userSelection > amountOfAnswers)
                {
                    Console.WriteLine("Oops, that number doesn't match an answer.");
                }
            }
            return userSelection;
        }
        public void adjustUserPersonalityFromAnswer(Answer selectedAnswer, UserPersonality userPersonality)
        {
            userPersonality.SincerityVsSatireScore += selectedAnswer.SincerityVsSatireImpact;
            userPersonality.LightVsHeavyScore += selectedAnswer.LightVsHeavyImpact;
            userPersonality.SurfaceVsDepthScore += selectedAnswer.SurfaceVsDepthImpact;
            userPersonality.OptimismVsPessimismScore += selectedAnswer.OptimismVsPessimismImpact;
            userPersonality.FantasyVsRealityScore += selectedAnswer.FantasyVsRealityImpact;
            userPersonality.SentimentalityScore += selectedAnswer.SentimentalityImpact;
            userPersonality.HumorScore += selectedAnswer.HumorImpact;
            userPersonality.RomanceScore += selectedAnswer.RomanceImpact;
            userPersonality.ControversyScore += selectedAnswer.ControversyImpact;
        }

        /// <summary>
        /// This method will wrap text, responsive to console window size. This method was found at: 
        /// https://rianjs.net/2016/03/line-wrapping-at-word-boundaries-for-console-applications-in-csharp
        /// </summary>
        /// <param name="textBlock"></param>
        /// <returns></returns>
        public static string GetWordWrappedTextBlock(string textBlock)
        {
            if (string.IsNullOrWhiteSpace(textBlock))
            {
                return string.Empty;
            }

            var approxLineCount = textBlock.Length / Console.WindowWidth;
            var lines = new StringBuilder(textBlock.Length + (approxLineCount * 4));

            for (var i = 0; i < textBlock.Length;)
            {
                var grabLimit = Math.Min(Console.WindowWidth, textBlock.Length - i);
                var line = textBlock.Substring(i, grabLimit);

                var isLastChunk = grabLimit + i == textBlock.Length;

                if (isLastChunk)
                {
                    i = i + grabLimit;
                    lines.Append(line);
                }
                else
                {
                    var lastSpace = line.LastIndexOf(" ", StringComparison.Ordinal);
                    lines.AppendLine(line.Substring(0, lastSpace));

                    //Trailing spaces needn't be displayed as the first character on the new line
                    i = i + lastSpace + 1;
                }
            }
            return lines.ToString();
        }

    }
}
