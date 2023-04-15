using System;

namespace AntonBot.PlatformAPI.ListenTypen
{
    internal class SkillAusgabe
    {
        public decimal AltEXP;
        public decimal AltMaxEXP;
        public int AltLevel;
        public decimal AltProzent;
        public decimal AddedEXP;
        public decimal NeuEXP;
        public int NeuLevel;
        public decimal NeuMaxEXP;
        public decimal NeuProzent;
        public String CurrentMainQuest = "";
        public int read;

        public void SetAltWerte(decimal EXP, decimal MAXEXP, int Level, decimal lastLevelEXP)
        {
            AltEXP = EXP;
            AltMaxEXP = MAXEXP;
            AltLevel = Level;
            AltProzent = ((EXP - lastLevelEXP) / (MAXEXP - lastLevelEXP)) * 100;
        }
        public void SetNeuWerte(decimal EXP, decimal MAXEXP, int Level, decimal lastLevelEXP, String Quest, decimal addedEXP)
        {
            NeuEXP = EXP;
            NeuMaxEXP = MAXEXP;
            NeuLevel = Level;
            NeuProzent = ((EXP - lastLevelEXP) / (MAXEXP - lastLevelEXP)) * 100;
            read = 0;
            CurrentMainQuest = Quest;
            AddedEXP = addedEXP;
        }

        public void SetNullWerte()
        {
            AltEXP = 0;
            AltMaxEXP = 0;
            AltLevel = 0;
            AltProzent = 0;
            AddedEXP = 0;
            NeuEXP = 0;
            NeuLevel = 0;
            NeuMaxEXP = 0;
            NeuProzent = 0;
            CurrentMainQuest = "No Quest Loaded";
            read = 0;
        }

    }
}
