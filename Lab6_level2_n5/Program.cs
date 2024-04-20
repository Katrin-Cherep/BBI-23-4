using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_level2_n5
{
    class Game
    {
        public struct Participant
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

        public List<Participant> Participants = new List<Participant>();
    }


    internal class Program
    {

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

        static void Main(string[] args)
        {
            Game game = new Game();
            game.Participants.Add(new Game.Participant("Cherep"));
            game.Participants.Add(new Game.Participant("Ivanov"));
            game.Participants.Add(new Game.Participant("Popova"));
            game.Participants.Add(new Game.Participant("Sidorov"));

            Random rnd = new Random();
            for (int i = 0; i < game.Participants.Count; i++)
            {
                Game.Participant participant = game.Participants[i];
                participant.Attempt = rnd.Next(40, 200);
                int[] scores = new int[5];
                for (int j = 0; j < scores.Length; j++)
                {
                    scores[j] = rnd.Next(0, 20);
                }
                Array.Copy(scores, participant.Scores, 5);
                game.Participants[i] = participant;
            }

            SortParticipantsBubble(game.Participants);

            Console.WriteLine("Place" + "\t\t| " + "Surname" + "\t\t| " + "Scores");
            Console.WriteLine("======================================================================================================");

            for (int i = 0; i < game.Participants.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + "\t\t| " + game.Participants[i].Surname + "\t\t| " + game.Participants[i].result_scores());
            }

            Console.Read();
        }
    }
}
