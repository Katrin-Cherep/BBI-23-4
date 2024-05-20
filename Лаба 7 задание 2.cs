using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab2_task2.Game;

namespace Lab2_task2
{
    class Game
    {
        public abstract class SkiJumping
        {
            public abstract string GameName { get; }

            public List<Participant> Participants = new List<Participant>();
        }


        public class SkiJumping120 : SkiJumping
        {
            public override string GameName => "Ski jumping 120m";
        }

        public class SkiJumping180 : SkiJumping
        {
            public override string GameName => "Ski jumping 180m";
        }

        public class Participant
        {
            private string _surname;
            public string Surname
            {
                get { return _surname; }
                set { _surname = value; }
            }


            private int _attempt;
            public int Attempt
            {
                get { return _attempt; }
                set { _attempt = value; }
            }

            private int[] _scores;
            public int[] Scores { get { return _scores; } set { _scores = value; } }

            public Participant(string surname = "Unknown", int attempt = 0)
            {
                _surname = surname;
                _attempt = attempt;
                _scores = new int[5];
            }

            public int result_scores()
            {
                int res = 60;
                Array.Sort(Scores);
                for (int i = 1; i < 4; i++)
                {
                    res += Scores[i];
                }
                if (_attempt > 120)
                {
                    res += (_attempt - 120) * 2;
                }
                else if (_attempt < 120)
                {
                    res -= (120 - _attempt) * 2;
                }
                if (res < 0)
                    res = 0;
                return res;
            }

        }

        //public List<Participant> Participants = new List<Participant>();
        public SkiJumping120 game_120 = new SkiJumping120();
        public SkiJumping180 game_180 = new SkiJumping180();
    }


    internal class Program
    {

        static Random rnd = new Random();


        static void SortParticipantsBubble(List<Game.Participant> participants)
        {
            Game.Participant temp;

            for (int write = 0; write < participants.Count; write++)
            {
                for (int sort = 0; sort < participants.Count - 1; sort++)
                {
                    if (participants[sort].result_scores() < participants[sort + 1].result_scores())
                    {
                        temp = participants[sort + 1];
                        participants[sort + 1] = participants[sort];
                        participants[sort] = temp;
                    }
                }
            }
        }

        static void generateRandomValues(List<Participant> p)
        {
            p.Add(new Game.Participant("Cherep"));
            p.Add(new Game.Participant("Ivanov"));
            p.Add(new Game.Participant("Popova"));
            p.Add(new Game.Participant("Sidorov"));

            for (int i = 0; i < p.Count; i++)
            {
                p[i].Attempt = rnd.Next(40, 200);
                int[] scores = new int[5];
                for (int j = 0; j < scores.Length; j++)
                {
                    scores[j] = rnd.Next(0, 20);
                }
                Array.Copy(scores, p[i].Scores, 5);
            }
        }

        static void pringTable(SkiJumping j)
        {
            Console.WriteLine(j.GameName);
            Console.WriteLine("Place" + "\t\t| " + "Surname" + "\t\t| " + "Scores");
            Console.WriteLine("======================================================================================================");

            for (int i = 0; i < j.Participants.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + "\t\t| " + j.Participants[i].Surname + "\t\t| " + j.Participants[i].result_scores());
            }
        }

        static void Main(string[] args)
        {
            Game game = new Game();

            generateRandomValues(game.game_120.Participants);
            SortParticipantsBubble(game.game_120.Participants);
            pringTable(game.game_120);

            generateRandomValues(game.game_180.Participants);
            SortParticipantsBubble(game.game_180.Participants);
            pringTable(game.game_180);

            Console.Read();
        }
    }
}
