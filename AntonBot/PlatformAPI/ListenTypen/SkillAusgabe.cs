using System;

namespace AntonBot.PlatformAPI.ListenTypen
{
    class SkillAusgabe
    {
        public decimal AltEXP;
        public decimal AltMaxEXP;
        public int AltLevel;
        public decimal AltProzent;
        public decimal NeuEXP;
        public int NeuLevel;
        public decimal NeuMaxEXP;
        public decimal NeuProzent;
        public String CurrentMainQuest;

        public void SetAltWerte(decimal EXP, decimal MAXEXP, int Level,decimal lastLevelEXP) {
            AltEXP = EXP;
            AltMaxEXP = MAXEXP;
            AltLevel = Level;
            AltProzent = ((EXP - lastLevelEXP) / (MAXEXP - lastLevelEXP)) * 100;
        }
        public void SetNeuWerte(decimal EXP, decimal MAXEXP, int Level, decimal lastLevelEXP) {
            NeuEXP = EXP;
            NeuMaxEXP = MAXEXP;
            NeuLevel = Level;
            NeuProzent = ((EXP - lastLevelEXP) / (MAXEXP - lastLevelEXP)) * 100;
        }
    }
}
