using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_level1_n1
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

            private string _society;
            public string Society
            {
                get { return _society; }
                set { _society = value; }
            }

            private uint _first_att;
            public uint First_attempt
            {
                get { return _first_att; }
                set { _first_att = value; }
            }

            private uint _last_att;
            public uint Last_attempt
            {
                get { return _last_att; }
                set { _last_att = value; }
            }


            public Participant(string surname = "Unknown", string society = "Unknown", uint firts_attempt = 0, uint last_attempt = 0)
            {
                _surname = surname;
                _society = society;
                _first_att = firts_attempt;
                _last_att = last_attempt;
            }

            public override string ToString()
            {

                return Surname + "\t" + Society + "\t" + First_attempt.ToString() + "\t" + Last_attempt.ToString();
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
                    if ((participants[sort].First_attempt + participants[sort].Last_attempt) > (participants[sort + 1].First_attempt + participants[sort + 1].Last_attempt))
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
            game.Participants.Add(new Game.Participant("Cherep", "MISIS "));
            game.Participants.Add(new Game.Participant("Ivanov", "MSU   "));
            game.Participants.Add(new Game.Participant("Popova", "MFTI  "));
            game.Participants.Add(new Game.Participant("Sidorov", "STANKIN"));

            Random rnd = new Random();
            for (int i = 0; i < game.Participants.Count; i++)
            {
                Game.Participant participant = game.Participants[i];
                participant.First_attempt = (uint)rnd.Next(1, 150);
                participant.Last_attempt = (uint)rnd.Next(1, 150);
                game.Participants[i] = participant;
            }

            SortParticipantsBubble(game.Participants);

            Console.WriteLine("Place" + "\t\t| " + "Surname" + "\t\t| " + "Society" + "\t\t| " + "1 attempt" + "\t\t| " + "2 attempt");
            Console.WriteLine("======================================================================================================");

            for (int i = 0; i < game.Participants.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + "\t\t| " + game.Participants[i].Surname + "\t\t| " + game.Participants[i].Society + "\t\t| " + game.Participants[i].First_attempt.ToString() + "\t\t\t| " + game.Participants[i].Last_attempt.ToString());
            }

            Console.Read();
        }
    }
}
