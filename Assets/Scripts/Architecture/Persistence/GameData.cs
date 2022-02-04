using System;

namespace Architecture.Persistence
{
    [Serializable]
    public class GameData
    {
        public TimeTrialData TimeTrialData;
        public GameData()
        {
            TimeTrialData = new TimeTrialData();
        }
    }
}