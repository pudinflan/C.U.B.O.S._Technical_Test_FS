using System;

namespace Architecture.Persistence
{
    [Serializable]
    public class TimeTrialData
    {
        public int BestTime = 0;
        public int TimesPlayed = 0;
        public int PowerUpsCollected = 0;
        public MedalType BestMedalReached = MedalType.None;
    }
}