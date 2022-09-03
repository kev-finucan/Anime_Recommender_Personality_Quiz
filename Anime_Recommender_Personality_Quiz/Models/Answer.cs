using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anime_Recommendation_Personality_Quiz
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public int SincerityVsSatireImpact { get; set; }
        public int LightVsHeavyImpact { get; set; }
        public int SurfaceVsDepthImpact { get; set; }
        public int OptimismVsPessimismImpact { get; set; }
        public int FantasyVsRealityImpact { get; set; }
        public int SentimentalityImpact { get; set; }
        public int HumorImpact { get; set; }
        public int RomanceImpact { get; set; }
        public int ControversyImpact { get; set; }

        public Answer() { }

        public Answer(int answerId, int questionId, string answerText, int sincerityVsSatireImpact, int lightVsHeavyImpact,
            int surfaceVsDepthImpact, int optimismVsPessimismImpact, int fantasyVsRealityImpact, int sentimentalityImpact,
            int humorImpact, int romanceImpact, int controversyImpact) 
        {
            this.AnswerId = answerId;
            this.QuestionId = questionId;
            this.AnswerText = answerText;
            this.SincerityVsSatireImpact = sincerityVsSatireImpact;
            this.LightVsHeavyImpact = lightVsHeavyImpact;
            this.SurfaceVsDepthImpact = surfaceVsDepthImpact;
            this.OptimismVsPessimismImpact = optimismVsPessimismImpact;
            this.FantasyVsRealityImpact = fantasyVsRealityImpact;
            this.SentimentalityImpact = sentimentalityImpact;
            this.HumorImpact = humorImpact;
            this.RomanceImpact = romanceImpact;
            this.ControversyImpact = controversyImpact;
           }
    }
}
