using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Beehive
{
    [Serializable]
    public class Hive
    {
        private const int BeesToStart = 6;
        private const double StartingHoney = 3.2;
        private const double MaxHoney = 15.0;
        private const double NectarHoneyConversion = .25;
        private const double HoneyForBeeCreation = 4.0;
        private const int MaxBees = 100;

        private Dictionary<string, Point> places;
        private int beeAmount = 0;
        public double Honey { get; private set; }
        private World world;
        public Bee.BeeAlert Alerter;


        private void InitializePlaces()
        {
            places = new Dictionary<string, Point>
            {
                { "Entrance", new Point(600, 100) },
                { "ChildrensPlayground", new Point(95, 174) },
                { "HoneyFactory", new Point(157, 98) },
                { "Exit", new Point(194, 213) }
            };
        }

        public Point LookupPlace(string place)
        {
            if (places.Keys.Contains(place))
            {
                return places[place];
            }
            else
            {
                throw new ArgumentException("Unknown place: " + place);
            }
        }

        public Hive(World world, Bee.BeeAlert Alerter)
        {
            this.Alerter = Alerter;
            this.world = world;

            Honey = StartingHoney;
            InitializePlaces();

            Random random = new Random();
            for (int i = 0; i < BeesToStart; i++)
            {
                NewBee(random);
            }
        }

        public bool AddHoney(double nectar)
        {
            double newHoney = nectar * NectarHoneyConversion;
            if (newHoney + Honey > MaxHoney)
            {
                return false;
            }

            Honey += newHoney;
            return true;
        }
        public bool ConsumeHoney(double amount)
        {
            if (amount > Honey)
            {
                return false;
            }
            else
            {
                Honey -= amount;
                return true;
            }
        }

        private void NewBee(Random random)
        {
            beeAmount++;
            int r1 = random.Next(100) - 50;
            int r2 = random.Next(100) - 50;

            Point startingPlace = new Point(places["ChildrensPlayground"].X + r1, places["ChildrensPlayground"].Y + r2);
            Bee newBee = new Bee(beeAmount, startingPlace, world, this);

            newBee.Alerter += this.Alerter;
            world.Bees.Add(newBee);
        }

        public void Progress(Random random)
        {
            if (world.Bees.Count < MaxBees && Honey > HoneyForBeeCreation && random.Next(10) == 1)
            {
                NewBee(random);
            }
        }
    }
}
