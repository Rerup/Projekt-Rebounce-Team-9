using System;
using System.Collections.Generic;
using System.Text;

namespace GettingRealConsoleApp.Domain
{
    public enum LevelEnum {five, four, three, two, one};
    public class Level
    {
        
        public int Points;
        Dictionary<LevelEnum, int> DicPoints = new Dictionary<LevelEnum, int>();
        
        public Level(LevelEnum level)
        {
            DicPoints.Add(LevelEnum.five,4);
            DicPoints.Add(LevelEnum.four, 5);
            DicPoints.Add(LevelEnum.three, 6);
            DicPoints.Add(LevelEnum.two, 7);
            DicPoints.Add(LevelEnum.one, 8);

            Points = DicPoints[level];

        }
    }
}
