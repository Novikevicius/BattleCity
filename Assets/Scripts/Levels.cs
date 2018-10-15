using System;
using System.Collections.Generic;

namespace BattleCity.Miscellaneous
{
    public static class Levels
    {
        public   const  float          tileSize = 0.32f;
        public   static readonly Level defaultLevel;
        private  static List<Level>    levels =  new List<Level>();
        private  static int            columns  = 15;
        private  static int            rows     = 15;
        public static int Columns
        {
            get { return columns * 2; }
        }
        public static int Rows
        {
            get { return rows * 2; }
        }
        public static float Width
        {
            get { return (2 * columns - 3) * tileSize; }
        }
        public static float Hight
        {
            get { return (2 * rows - 3) * tileSize; }
        }
        public static Level GetLevel(int index)
        {
            if (index > 0 && index < levels.Count)
                return levels[index];
            throw new ArgumentOutOfRangeException("index", "Index must be between 0 and + " + levels.Count);
        }
        public static int   GetLevelsCount()
        {
            return levels.Count;
        }
        
        static Levels()
        {
            // L - level number, B - basic tank, F - fast tank
            // P - power tank, A - armor tank
            //                           L  B   F   P   A 
            defaultLevel = new Level(Level1, 1, 18, 02, 00, 00);
            levels.Add(new Level(Level1, 1, 18, 02, 00, 00));
            levels.Add(new Level(Level2, 2, 14, 04, 00, 02));
            levels.Add(new Level(Level3, 3, 14, 04, 00, 02));
            levels.Add(new Level(Level4, 4, 02, 05, 03, 10));
            levels.Add(new Level(Level5, 5, 08, 05, 05, 02));
            levels.Add(new Level(Level6, 6, 09, 02, 07, 02));
            levels.Add(new Level(Level7, 7, 10, 04, 06, 00));
            levels.Add(new Level(Level8, 8, 07, 04, 07, 02));
        }
        
        #region Level1
        private static readonly string Level1 = "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "|| S           S           S||" +
                                                "||                          ||" +
                                                "||  BB  BB  BB  BB  BB  BB  ||" +
                                                "||  BB  BB  BB  BB  BB  BB  ||" +
                                                "||  BB  BB  BB  BB  BB  BB  ||" +
                                                "||  BB  BB  BB  BB  BB  BB  ||" +
                                                "||  BB  BB  BBIIBB  BB  BB  ||" +
                                                "||  BB  BB  BBIIBB  BB  BB  ||" +
                                                "||  BB  BB  BB  BB  BB  BB  ||" +
                                                "||  BB  BB          BB  BB  ||" +
                                                "||  BB  BB          BB  BB  ||" +
                                                "||          BB  BB          ||" +
                                                "||          BB  BB          ||" +
                                                "||BB  BB              BB  BB||" +
                                                "||II  BB              BB  II||" +
                                                "||          BB  BB          ||" +
                                                "||          BBBBBB          ||" +
                                                "||  BB  BB  BBBBBB  BB  BB  ||" +
                                                "||  BB  BB  BB  BB  BB  BB  ||" +
                                                "||  BB  BB  BB  BB  BB  BB  ||" +
                                                "||  BB  BB  BB  BB  BB  BB  ||" +
                                                "||  BB  BB          BB  BB  ||" +
                                                "||  BB  BB          BB  BB  ||" +
                                                "||  BB  BB   BBBB   BB  BB  ||" +
                                                "||           B  B           ||" +
                                                "||         1 BE B           ||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||";
        #endregion
        #region Level2
        private static readonly string Level2 = "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "|| S    II     SII         S||" +
                                                "||      II      II          ||" +
                                                "||  BB  II      BB  BB  BB  ||" +
                                                "||  BB  II      BB  BB  BB  ||" +
                                                "||  BB        BBBB  BBIIBB  ||" +
                                                "||  BB        BBBB  BBIIBB  ||" +
                                                "||      BB          II      ||" +
                                                "||      BB          II      ||" +
                                                "||GG    BB    II    BBGGBBII||" +
                                                "||GG    BB    II    BBGGBBII||" +
                                                "||GGGG  BB  BB    II  GG    ||" +
                                                "||GGGG      BB    II  GG    ||" +
                                                "||  BBBBBBGGGGGGII    GGBB  ||" +
                                                "||  BBBBBBGGGGGGII    GGBB  ||" +
                                                "||      IIGGBB  BB  BB  BB  ||" +
                                                "||      IIGGBB  BB  BB  BB  ||" +
                                                "||IIBB  II  BB  BB      BB  ||" +
                                                "||IIBB  II  BB  BB      BB  ||" +
                                                "||  BB  BB  BBBBBB  BBIIBB  ||" +
                                                "||  BB  BB  BBBBBB  BBIIBB  ||" +
                                                "||  BB  BB  BBBBBB          ||" +
                                                "||  BB  BB  BBBBBB          ||" +
                                                "||  BB              BB  BB  ||" +
                                                "||  BB       BBBB   BB  BB  ||" +
                                                "||  BB  BB   B  B   BBBBBB  ||" +
                                                "||  BB  BB 1 BE B   BBBBBB  ||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||";
        #endregion
        #region Level3
        private static readonly string Level3 = "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "|| S      BB   S  BB       S||" +
                                                "||        BB      BB        ||" +
                                                "||  GGGGGGBB                ||" +
                                                "||  GGGGGGBB          IIIIII||" +
                                                "||BBGGGGGG                  ||" +
                                                "||BBGGGGGG                  ||" +
                                                "||GGGGGGGG      BB  BBBBBBB ||" +
                                                "||GGGGGGGG      BB  BBBBBBB ||" +
                                                "||GGGGGGGGBBBBBBBB  BB   B  ||" +
                                                "||GGGGGGGGBBBBBB    BB   B  ||" +
                                                "||GGGGGGGG    BB         B  ||" +
                                                "||GGGGGGGG    BB         B  ||" +
                                                "||  GG        IIIIII    GG  ||" +
                                                "||  GG        IIIIII    GG  ||" +
                                                "||                  GGGGGGGG||" +
                                                "||  BB  BB          GGGGGGGG||" +
                                                "||BBB  BBBB  BBBBBBBGGGGGGGG||" +
                                                "||BBB  BBBB  B      GGGGGGGG||" +
                                                "||          BB  BBBBGGGGGGGG||" +
                                                "||          BB  BBBBGGGGGGGG||" +
                                                "||BB    I           GGGGGG  ||" +
                                                "||BB    I           GGGGGG  ||" +
                                                "||BBBB  I           GGGGGG  ||" +
                                                "||BBBB  I    BBBB   GGGGGG  ||" +
                                                "||IIBBBB     B  B   BB      ||" +
                                                "||IIBBBB   1 BE B   BB      ||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||";
        #endregion
        #region Level4
        private static readonly string Level4 = "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "|| SGGGG       S        GG S||" +
                                                "||  GGGG                GG  ||" +
                                                "||GGGG      BBBB          GG||" +
                                                "||GGGG    BBBBBBBBBB      GG||" +
                                                "||GG     BBBBBBBBBBBBB    II||" +
                                                "||GG     BBBBBBBBBBBBBBB    ||" +
                                                "||II    BBBBBBBBBBBBBBBBB   ||" +
                                                "||      BBBBBBBBBBBBBBBBB   ||" +
                                                "||     BBB      BBBBBB  B   ||" +
                                                "||     B          BBBB  B   ||" +
                                                "||WW   B  I   I   BBB       ||" +
                                                "||WW   B  I   I   BBB       ||" +
                                                "||    B           BBB   WWWW||" +
                                                "||    B   BBBB    BBB   WWWW||" +
                                                "||    BBBBBBBBBBBBBBBB      ||" +
                                                "||    BBBBBBBBBBBBBBBB      ||" +
                                                "||   BBBBBBBBBBBBBBBBBB     ||" +
                                                "||   BBBBBBBBBBBBBBBBBB     ||" +
                                                "||  BBBBBBBBBBBBBBBBBBBB    ||" +
                                                "||      BBBBBBBBBBBB        ||" +
                                                "||  BBBB  BBBBBBBB  BBBB  GG||" +
                                                "||  BBBBBB  BBBB  BB  BB  GG||" +
                                                "||BB  BBBB        BB    GGGG||" +
                                                "||BB         BBBB       GGGG||" +
                                                "||IIBB       B  B     GGGGII||" +
                                                "||IIBB     1 BE B     GGGGII||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||";
        #endregion
        #region Level5
        private static readonly string Level5 = "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "|| S      BBBB S           S||" +
                                                "||        BBBB              ||" +
                                                "||        BB      IIIIII    ||" +
                                                "||II  BB  BB          II    ||" +
                                                "||II  BB      BB            ||" +
                                                "||II  BB      BB            ||" +
                                                "||BB  BBBBBB  BBBB  WWWW  WW||" +
                                                "||BB  BBBBBB  BBBB  WWWW  WW||" +
                                                "||BB      BB        WW      ||" +
                                                "||                  WW      ||" +
                                                "||        WWWW  WWWWWW  BBBB||" +
                                                "||    BB  WWWW  WWWWWW  BBBB||" +
                                                "||BBBB    WWBB              ||" +
                                                "||BBBB    WWBB              ||" +
                                                "||        WW           II   ||" +
                                                "||        WW           II   ||" +
                                                "||WWWWWW  WW  II  BB   I    ||" +
                                                "||WWWWWW  WW  II  BB   I    ||" +
                                                "||                     IBBBB||" +
                                                "||      BBBB           IBBBB||" +
                                                "||        BBBBBBBBBB        ||" +
                                                "||        BB      BBBB      ||" +
                                                "||                  BBBB    ||" +
                                                "||BBBBBB     BBBB     BB    ||" +
                                                "||BBBB       B  B           ||" +
                                                "||BB       1 BE B           ||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||";
        #endregion        
        #region Level6
        private static readonly string Level6 = "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "|| S         B SB GGGG     S||" +
                                                "||           B  B GGGG      ||" +
                                                "||  B  I  B        BGGB  BGG||" +
                                                "||  B  I  B        BGGB  BGG||" +
                                                "||  B  I  B   BB   BGGB  BGG||" +
                                                "||  B  I  B   BB   BGGB  BGG||" +
                                                "||  BB    BB  II  BBGG  BBGG||" +
                                                "||  BB    BB  II  BBGG  BBGG||" +
                                                "||       BII  BB  BBI   GGGG||" +
                                                "||       B    BB    I   GGGG||" +
                                                "||BBBBB     GGBBGG     BBBBB||" +
                                                "||BBBBB     GGBBGG     BBBBB||" +
                                                "||         BGGGGGGB         ||" +
                                                "||         BGGGGGGB         ||" +
                                                "||IIBBBB  BBGGGGGGBB BBBBBII||" +
                                                "||IIBBBB    GGGGGG   BBBBBII||" +
                                                "||IIIIII      GG      IIIIII||" +
                                                "||        BB  GG  BB        ||" +
                                                "||  BB    BB      BB        ||" +
                                                "||  BB    BB      BB        ||" +
                                                "||  BBB     BB  BB     BBBGG||" +
                                                "||  BBB                BBBGG||" +
                                                "||    BB              GGGGGG||" +
                                                "||           BBBB     GGGGGG||" +
                                                "||           B  B       GGGG||" +
                                                "||    BB   1 BE B     BBGGGG||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||";
        #endregion
        #region Level7
        private static readonly string Level7 = "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "|| S           SIIII       S||" +
                                                "||                          ||" +
                                                "||    IIIIIIII        II    ||" +
                                                "||    II              II    ||" +
                                                "||    II      GG  IIIIII    ||" +
                                                "||    II      GG    IIII    ||" +
                                                "||  II      GGII      II    ||" +
                                                "||  II      GGII      II    ||" +
                                                "||        GGIIII      IIII  ||" +
                                                "||        GGIIII        II  ||" +
                                                "||  II  GGIIIIII  II        ||" +
                                                "||  II  GGIIIIII  II        ||" +
                                                "||   I  IIII      IIII      ||" +
                                                "||   I  IIII      IIII      ||" +
                                                "||I       II  IIIIII     I  ||" +
                                                "||I       II  IIIIII     I  ||" +
                                                "||   III      IIIIGG    II  ||" +
                                                "||   III      IIIIGG    II  ||" +
                                                "||  II        IIGG    IIII  ||" +
                                                "||  II        IIGG    IIII  ||" +
                                                "||  IIIIII    GG    II      ||" +
                                                "||      II    GG    II      ||" +
                                                "||                  II    II||" +
                                                "||           BBBB       IIII||" +
                                                "||           B  B           ||" +
                                                "||IIII     1 BE B           ||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||";
        #endregion
        #region Level8
        private static readonly string Level8 = "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "|| S  BB    BB S    BB     S||" +
                                                "||    BB    BB  BB  BB      ||" +
                                                "||GGBBBBBB  BB      BBB     ||" +
                                                "||GGBBBBBB  BB  II  BBB     ||" +
                                                "||GGGGGG    BB  BB  BB   BB ||" +
                                                "||GGGGGG        BB       BB ||" +
                                                "||GGWWWWWWWWWWWWWWWWWWW   WW||" +
                                                "||GGWWWWWWWWWWWWWWWWWWW   WW||" +
                                                "||  BB   BII      BBI       ||" +
                                                "||  BB   B    BBBB  I       ||" +
                                                "||    BB     BBBBBBBBBBBIIII||" +
                                                "||    BB     BBBBB  BB      ||" +
                                                "||BBBB  BB   BBBBBGGBB    BB||" +
                                                "||BBBB  BB   BBBBBGGBBIIIIBB||" +
                                                "||      II      GGGGGGGG    ||" +
                                                "||      II  II  GGGGGGGG    ||" +
                                                "||WWWW  WWWWWWWWWW  WWWWWWWW||" +
                                                "||WWWW  WWWWWWWWWW  WWWWWWWW||" +
                                                "||GGGG   B                  ||" +
                                                "||GGGG   B    BBBB          ||" +
                                                "||GGGGBB  B      B      BB  ||" +
                                                "||GGGGBB  B      B  IIBBBB  ||" +
                                                "||GG  BB  B         BB  BB  ||" +
                                                "||GGIIBB  B  BBBB       BB  ||" +
                                                "||           B  B       BB  ||" +
                                                "||         1 BE B   BB      ||" +
                                                "||||||||||||||||||||||||||||||" +
                                                "||||||||||||||||||||||||||||||";
        #endregion
    }

    public struct Level
    {
        public readonly string level;
        public int Lv         { get; private set; }
        public int Tank1Count { get; private set; }
        public int Tank2Count { get; private set; }
        public int Tank3Count { get; private set; }
        public int Tank4Count { get; private set; }


        public Level(string level, int number, int tank1, int tank2, int tank3, int tank4)
        {
            if (tank1 + tank2 + tank3 + tank4 > 20)
                throw new ArgumentOutOfRangeException("tanks", "Tanks count cannot be more than 20");

            this.level = level;
            Lv         = number;
            Tank1Count = tank1;
            Tank2Count = tank2;
            Tank3Count = tank3;
            Tank4Count = tank4;
        }
        public Level(Level lvl)
        {
            level      = lvl.level;
            Lv         = lvl.Lv;
            Tank1Count = lvl.Tank1Count;
            Tank2Count = lvl.Tank2Count;
            Tank3Count = lvl.Tank3Count;
            Tank4Count = lvl.Tank4Count;
        }
    }
}
