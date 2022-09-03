using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anime_Recommendation_Personality_Quiz
{
    public class QuizQuestion
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }

        public QuizQuestion() { }

        public QuizQuestion(int questionId, string questionText)
        {
            this.QuestionId = questionId;
            this.QuestionText = questionText;
        }
    }
}
