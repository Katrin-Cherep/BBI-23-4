using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_task3
{

    public enum TeamGender
    {
        TG_WOMEN,
        TG_MEN,
    }

    public abstract class Team
    {
        public abstract TeamGender gender { get; }
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private int _score;
        public int Score { get { return _score; } set { _score = value; } }

        public Team(string name, int score = 0)
        {
            _name = name;
            _score = score;
        }
    }

    public class MenTeam : Team
    {
        public override TeamGender gender => TeamGender.TG_MEN;

        public MenTeam(string name, int score = 0) : base(name, score)
        {
        }
    }

    public class WomenTeam : Team
    {
        public override TeamGender gender => TeamGender.TG_WOMEN;

        public WomenTeam(string name, int score = 0) : base(name, score)
        {
        }
    }

    internal class Program
    {
        static void Swap(Team[] array, int i, int j)
        {
            (array[j], array[i]) = (array[i], array[j]);
        }

        static void GnomeSort(Team[] inArray)
        {
            int i = 1;
            int j = 2;
            while (i < inArray.Length)
            {
                if (inArray[i - 1].Score > inArray[i].Score)
                {
                    i = j;
                    j += 1;
                }
                else
                {
                    Swap(inArray, i - 1, i);
                    i -= 1;
                    if (i == 0)
                    {
                        i = j;
                        j += 1;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Team[] team1 = new Team[12];
            Team[] team2 = new Team[12];

            Random rnd = new Random();
            for (int i = 0; i < 12; i++)
            {
                if (i < 6)
                {
                    team1[i] = new MenTeam("Team N" + (i + 1).ToString());
                    team2[i] = new MenTeam("Team N" + (i + 13).ToString());
                }
                else
                {
                    team1[i] = new WomenTeam("Team N" + (i + 1).ToString());
                    team2[i] = new WomenTeam("Team N" + (i + 13).ToString());
                }

                team1[i].Score = rnd.Next(0, 15);
                team2[i].Score = rnd.Next(0, 15);
            }

            GnomeSort(team1);
            GnomeSort(team2);

            Console.WriteLine("From first group:");
            Console.WriteLine("Place" + "\t|" + "Name" + "\t\t|" + "Gender" + "\t\t|" + "Score");
            Console.WriteLine("==========================================");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine((i + 1).ToString() + "\t|" + team1[i].Name + "\t|" + (team1[i].gender == TeamGender.TG_MEN ? "Men" : "Women") + "\t|" + team1[i].Score.ToString());
            }

            Console.WriteLine("\nFrom second group:");
            Console.WriteLine("Place" + "\t|" + "Name" + "\t\t|" + "Gender" + "\t\t|" + "Score");
            Console.WriteLine("==========================================");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine((i + 1).ToString() + "\t|" + team2[i].Name + "\t|" + (team2[i].gender == TeamGender.TG_MEN ? "Men" : "Women" ) + "\t|" + team2[i].Score.ToString());
            }
            Console.Read();
        }
    }
}
