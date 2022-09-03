# Kacque's Anime Recommender Personality Quiz

"""
Welcome to the world's greatest anime recommender quiz (if we do say so ourselves)...  
And we do! (On a scale of 1-10, it's over 9,000!)  
Simply answer these 15 questions, and our system will learn the deepest secrets of your heart!  
But don't worry. We won't tell anybody.   
We'll just let you know your next anime obsession - believe it!  
So get ready, because here comes your first question...  
"""

This quiz infers characteristics of the user and builds a personality class with 9 different trait scales as the user answers situation-based, anime-trope questions. Each anime show is graded on the same scales, and each quiz question answer has impact scores that move the user's personality along the scales. Once the user completes the quiz, the application will compare their scores on each scale to the fixed scores of each anime show, and will generate an aggregate disparity score, which will be set as an "incompatibility score" property for the anime show. The application will then give the user some feedback about their personality and return the anime show(s) with the lowest incompatibility.


### Sample quiz question and answers showing how each answer would impact the user's personality scales

Question #2:
You’ve been isekai’d! The beast king’s sorcerer has summoned you to another world. He tells you that you are the chosen hero who must defeat a demon lord threatening to destroy the kingdom. You can choose one ally from the adventurer’s guild to join your party for the quest. Who do you choose?

1: You pick the king’s purrfect princess! Sure, she’s a little spoiled and cold, but you’re a sucker for a tsundere – especially one with a cute tail and fuzzy ears, meow!  
---(If selected: LightVsHeavy +1 Light, Sentimentality + 1, Humor +1, Romance +1)

2: You choose the sorcerer – duh! The king’s personal sorcerer, who was powerful enough to summon you here from another world…Who better to teach you this world’s magic? You’ll be a supreme spellcaster in no time!   
---(If selected: SincerityVsSatire +1 Satire, FantasyVsReality +1 Fantasy)

3: It’s gotta be the creepy loner in the shadowy corner of the guild house. You don’t care what they say he’s done, or why everyone seems to be afraid of him. He’s obviously a misunderstood badass with a secretly soft heart, and once you’re done kicking some demon tail, you can be part of his redemption arc!  
---(If selected: SurfaceVsDepth +1 Depth, OptimismVsPessimism +1 Pessimism, Sentimentality +1, Romance +1)

4: You pick the pint-sized pig-person everybody’s laughing at. Comic relief mascot? Heck yes! Plus, you’re pretty sure he packs a secret punch. You just need some sufficient danger to unlock his hidden power. You begin plotting all the ways you’re going to torture, ahem, train him to unleash it – KuKuKu!   
---(If selected: SincerityVsSatire +1 Satire, SurfaceVsDepth +1 Depth, Sentimentality -1, Romance -1, Controversy +2)

5: No one! You didn’t ask to come here, and you have zero interest in fighting a demon lord. After all, what’s he done to you? ‘Good luck with that!’ You tell the king, as you head out in search of a tavern to party in.   
---(If selected: OptimismVsPessimism +1 Pessimism, FantasyVsReality +2 Reality, Sentimentality -1, Controversy -1)
