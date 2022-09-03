using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anime_Recommendation_Personality_Quiz.Models
{
    public class UserPersonality
    {
        /*
         * All user personality score defaults (on a scale of 0-20) are assumed to be the the most neutral position for the given scale,
         * and are moved in either direction based on how the user answers the questions of the personality quiz.
         * Some default values are marginally biased towards one extreme or the other on a given scale. This is to account for 
         * the varying amount of opportunities to move the scale in either direction when answering the quiz questions.
         */
        public int SincerityVsSatireScore { get; set; } = 10;
        public int LightVsHeavyScore { get; set; } = 8;
        public int SurfaceVsDepthScore { get; set; } = 8;
        public int OptimismVsPessimismScore { get; set; } = 10;
        public int FantasyVsRealityScore { get; set; } = 10;
        public int SentimentalityScore { get; set; } = 10;
        public int HumorScore { get; set; } = 0;
        public int RomanceScore { get; set; } = 0;
        public int ControversyScore { get; set; } = 5;

        public UserPersonality() { }

        /// <summary>
        /// This method enforces bounds 0-20 for all UserPersonality scales to align with the anime show ratings' max and min.
        /// </summary>
        public void adjustScoreOutliers()
        {
            // Scale 1
            if (SincerityVsSatireScore < 0)
            {
                SincerityVsSatireScore = 0;
            }
            else if (SincerityVsSatireScore > 20)
            {
                SincerityVsSatireScore = 20;
            }
            // Scale 2
            if (LightVsHeavyScore < 0)
            {
                LightVsHeavyScore = 0;
            }
            else if (LightVsHeavyScore > 20)
            {
                LightVsHeavyScore = 20;
            }
            // Scale 3
            if (SurfaceVsDepthScore < 0)
            {
                SurfaceVsDepthScore = 0;
            }
            else if (SurfaceVsDepthScore > 20)
            {
                SurfaceVsDepthScore = 20;
            }
            // Scale 4
            if (OptimismVsPessimismScore < 0)
            {
                OptimismVsPessimismScore = 0;
            }
            else if (OptimismVsPessimismScore > 20)
            {
                OptimismVsPessimismScore = 20;
            }
            // Scale 5
            if (FantasyVsRealityScore < 0)
            {
                FantasyVsRealityScore = 0;
            }
            else if (FantasyVsRealityScore > 20)
            {
                FantasyVsRealityScore = 20;
            }
            // Scale 6
            if (SentimentalityScore < 0)
            {
                SentimentalityScore = 0;
            }
            else if (SentimentalityScore > 20)
            {
                SentimentalityScore = 20;
            }
            // Scale 7
            if (HumorScore < 0)
            {
                HumorScore = 0;
            }
            else if (HumorScore > 20)
            {
                HumorScore = 20;
            }
            // Scale 8
            if (RomanceScore < 0)
            {
                RomanceScore = 0;
            }
            else if (RomanceScore > 20)
            {
                RomanceScore = 20;
            }
            // Scale 9
            if (ControversyScore < 0)
            {
                ControversyScore = 0;
            }
            else if (ControversyScore > 20)
            {
                ControversyScore = 20;
            }
        }

        /// <summary>
        /// This method will print feedback based on the user's personality class
        /// </summary>
        public List<string> generatePersonalityFeedback()
        {
            List<string> personalityFeedback = new List<string>();
            // SCALE 1
            if (SincerityVsSatireScore < 5)
            {
                personalityFeedback.Add("You are an earnest person who appreciates sincerity.");
            }
            else if (SincerityVsSatireScore > 15)
            {
                personalityFeedback.Add("You appreciate a tongue-in-cheek approach.");
            }
            else
            {
                personalityFeedback.Add("You like a balance between wit and sincerity.");
            }
            // SCALE 2
            if (LightVsHeavyScore < 5)
            {
                personalityFeedback.Add("You watch shows for a pleasant escape.");
            }
            else if (LightVsHeavyScore > 15)
            {
                personalityFeedback.Add("You don't shy away from the gritty or macabre.");
            }
            // SCALE 3
            if (SurfaceVsDepthScore < 5)
            {
                personalityFeedback.Add("You like to take it easy.");
            }
            else if (SurfaceVsDepthScore > 15)
            {
                personalityFeedback.Add("You like to be challenged.");
            }
            // SCALE 4
            if (OptimismVsPessimismScore < 5)
            {
                personalityFeedback.Add("Generally speaking, you are a glass-half-full sort.");
            }
            else if (OptimismVsPessimismScore > 15)
            {
                personalityFeedback.Add("You might be a bit of a cynic.");
            }
            else
            {
                personalityFeedback.Add("You are a realist who appreciates a balanced view of life's ups and downs.");
            }
            // SCALE 5
            if (FantasyVsRealityScore < 5)
            {
                personalityFeedback.Add("You're a head-in-the-clouds type who doesn't mind getting carried away.");
            }
            else if (FantasyVsRealityScore > 15)
            {
                personalityFeedback.Add("You don't spend too much time dadreaming.");
            }
            // SCALE 6
            if (SentimentalityScore < 5)
            {
                personalityFeedback.Add("You cringe a little when folks get overly-sentimental.");
            }
            else if (SentimentalityScore > 15)
            {
                personalityFeedback.Add("You might be a bit of a sap.");
            }
            else
            {
                personalityFeedback.Add("You don't mind a little sentimentality, but you draw the line at sappy.");
            }
            // SCALE 7
            if (HumorScore < 5)
            {
                personalityFeedback.Add("People might say you're a bit on the serious side.");
            }
            else if (HumorScore > 15)
            {
                personalityFeedback.Add("Your friends consider you the jester of the group.");
            }
            else
            {
                personalityFeedback.Add("You like to laugh, but know when it's time to get serious.");
            }
            // SCALE 8
            if (RomanceScore < 5)
            {
                personalityFeedback.Add("No one has ever accused you of being a romantic.");
            }
            else if (RomanceScore > 15)
            {
                personalityFeedback.Add("You LOOOVE love! <3");
            }
            else
            {
                personalityFeedback.Add("Romance is fine, but it's not your top priority.");
            }
            // SCALE 9
            if (ControversyScore < 5)
            {
                personalityFeedback.Add("You tend to be a rule-follower.");
            }
            else if (ControversyScore > 15)
            {
                personalityFeedback.Add("You have a mischevious side, and don't always follow the rules.");
            }
            return personalityFeedback;
        }

    }

   
}
