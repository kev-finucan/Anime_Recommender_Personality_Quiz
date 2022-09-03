using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anime_Recommendation_Personality_Quiz.Models
{
    public class AnimeShow
    {
        public int ShowId { get; set; }
        public string ShowTitle { get; set; }
        public string ShowDescription { get; set; }
        public int SincerityVsSatireScore { get; set; }
        public int LightVsHeavyScore { get; set; }
        public int SurfaceVsDepthScore { get; set; }
        public int OptimismVsPessimismScore { get; set; }
        public int FantasyVsRealityScore { get; set; }
        public int SentimentalityScore { get; set; }
        public int HumorScore { get; set; }
        public int RomanceScore { get; set; }
        public int ControversyScore { get; set; }

        /// <summary>
        /// Incompatability score is an aggregate total of the UserPersonality scales' disparity with the fixed scores on the
        /// same scales for each instance of anime show.This score will be determined after comparing the user's personality 
        /// class to each show after the quiz is completed.All of an anime show's scale scores are passed into the constructor; 
        /// Incompatability score is instatiated at 0.
        /// </summary>
        public int IncompatibilityScore { get; set; } = 0;

        public AnimeShow(int showId, string showTitle, int sincerityVsSatireScore, int lightVsHeavyScore, int surfaceVsDepthScore,
            int optimismVsPessimismScore, int fantasyVsRealityScore, int sentimentalityScore, int humorScore, int romanceScore,
            int controversyScore, string showDescription)
        {
            this.ShowId = showId;
            this.ShowTitle = showTitle;
            this.SincerityVsSatireScore = sincerityVsSatireScore;
            this.LightVsHeavyScore = lightVsHeavyScore;
            this.SurfaceVsDepthScore = surfaceVsDepthScore;
            this.OptimismVsPessimismScore = optimismVsPessimismScore;
            this.FantasyVsRealityScore = fantasyVsRealityScore;
            this.SentimentalityScore = sentimentalityScore;
            this.HumorScore = humorScore;
            this.RomanceScore = romanceScore;
            this.ControversyScore = controversyScore;
            this.ShowDescription = showDescription;
        }

        public int setAnimeShowIncompatibility(UserPersonality userPersonality)
        {
            int disparity = Math.Abs(SincerityVsSatireScore - userPersonality.SincerityVsSatireScore);
            disparity += Math.Abs(LightVsHeavyScore - userPersonality.LightVsHeavyScore);
            disparity += Math.Abs(SurfaceVsDepthScore - userPersonality.SurfaceVsDepthScore);
            disparity += Math.Abs(OptimismVsPessimismScore - userPersonality.OptimismVsPessimismScore);
            disparity += Math.Abs(FantasyVsRealityScore - userPersonality.FantasyVsRealityScore);
            disparity += Math.Abs(SentimentalityScore - userPersonality.SentimentalityScore);
            disparity += Math.Abs(HumorScore - userPersonality.HumorScore);
            disparity += Math.Abs(RomanceScore - userPersonality.RomanceScore);
            disparity += Math.Abs(ControversyScore - userPersonality.ControversyScore);
            this.IncompatibilityScore = disparity;
            return disparity;
        }
    }
}
