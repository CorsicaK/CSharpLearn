using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap11.DataLib
{
    public static  class Formulal
    {
        private static List<Racer> racers;
        private static List<Team> teams;

        private static List<ChampionShip> championships;
        public static IList<Racer > GetChampions()
        {
            if(racers == null)
            {
                racers = new List<Racer>(40);
                racers.Add(new DataLib.Racer("Nino", "FDia", "Italy",54, 5, new int[] { 1950 }, new string[] { "Alfa Remeo" }));
                racers.Add(new DataLib.Racer("Vino", "SFa", "USA", 42, 5, new int[] { 1946,1962 }, new string[] { "Alfa","Remeo" }));
                racers.Add(new DataLib.Racer("ADAno", "GRa", "CN", 43, 4, new int[] { 1988,1963,1965 }, new string[] { "ARemeo" }));
                racers.Add(new DataLib.Racer("SCno", "FaGN", "CN", 34, 4, new int[] { 1999,2000,2001,2002 }, new string[] { "USA","Atlanta" }));
                racers.Add(new DataLib.Racer("NSDino", "VGE", "USA", 32, 0, new int[] { 1950 }, new string[] { "Emeo" }));
                racers.Add(new DataLib.Racer("WDno", "FG", "JP", 55,2, new int[] { 1955,1962,1955}, new string[] { "Kemeo" }));
                racers.Add(new DataLib.Racer("UiF", "GGHG", "Italy", 32, 2, new int[] { 1950 }, new string[] { "Alfa Remeo" }));
                racers.Add(new DataLib.Racer("GGDno", "JYT", "Italy", 15, 1, new int[] { 1986,1952,1997 }, new string[] { "Alfa Remeo" }));
                racers.Add(new DataLib.Racer("YHYo", "DGR", "Italy", 28, 5, new int[] { 1950 }, new string[] { "Alfa Remeo" }));
                racers.Add(new DataLib.Racer("FFF", "Baria", "Italy", 33, 5, new int[] { 1971,1960,1954 }, new string[] { "UK","USA" }));
               
            }
            return racers;
        }


        public static IList <Team> GetContructorChampions()
        {
            if (teams == null)
            {
                teams = new List<DataLib.Team>()
                {
                    new DataLib.Team ("Vanvwall",1958),
                    new DataLib.Team ("GTT",1959,1960),
                    new DataLib.Team ("SDFSF",1961,1962,1965,1982,1968,1987),
                    new DataLib.Team ("SFS",1985,1967,1988,1990,1999),
                    new DataLib.Team ("FFF",1999,1998,2000,2001),
                    new DataLib.Team ("XZSA",1964,1962,1980,1987),
                    new DataLib.Team ("GXB",1958,1986),
                    new DataLib.Team ("FS",1968,1974),
                    new DataLib.Team ("DFGGD",1985,1986,1987),
                    new DataLib.Team ("VXGWE",1989,1992,1995),
                    new DataLib.Team ("GSG",1990,1991),
                    new DataLib.Team ("HYTJ",1990,1968),
                    new DataLib.Team ("GFD",1978),
                    new DataLib.Team ("REN",1998,1999),
                    new DataLib.Team ("TE",1996,1999),
                    new DataLib.Team ("JYT",1995,2001,2003,2004),
                    new DataLib.Team ("RS",1959)
                };
            }
            return teams;
        }


        public static IEnumerable<ChampionShip> GetChampionships()
        {
            if (championships == null)
            {
                championships = new List<ChampionShip>();
                championships.Add(new ChampionShip
                {
                    Year = 1950,
                    First = "Nino Fra",
                    Second = "Juan Manule",
                    Third = "Luiqh"
                });
                championships.Add(new ChampionShip
                {
                    Year = 1951,
                    First = "HJKK",
                    Second = "jKSi",
                    Third = "Juj"
                });
            }
            return championships;
        }
    }
}
