using System;

namespace Architecture.Persistence
{
    [Serializable]
    public class GameData
    {
        public float BestTime = float.MaxValue;
        public int TimesPlayed ;
        public int PowerUpsCollected ;
        public MedalType BestMedalReached ;

        public GameData(float bestTime, int timesPlayed, int powerUpsCollected, MedalType bestMedalReached)
        {
            BestTime = bestTime;
            TimesPlayed = timesPlayed;
            PowerUpsCollected = powerUpsCollected;
            BestMedalReached = bestMedalReached;
        }
    }
}