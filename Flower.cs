using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Beehive
{
    [Serializable]
    public class Flower
    {
        private const int MinAge = 15000;
        private const int MaxAge = 30000;
        private const double StartingNectar = 1.5;
        private const double MaxNectar = 5.0;
        private const double GrowthPerRound = 0.01;
        private const double CollectableNectarPerRound = 0.3;

        private readonly int lifespan;

        public Point Place { get; private set; }
        public int Age { get; private set; }
        public bool Alive { get; private set; }
        public double Nectar { get; private set; }
        public double CollectedNectar { get; set; }

        public Flower(Point ort, Random zufall)
        {
            Place = ort;
            Age = 0;
            Alive = true;
            Nectar = StartingNectar;
            CollectedNectar = 0;
            lifespan = zufall.Next(MinAge, MaxAge + 1);
        }

        public double CollectNectar()
        {
            if (CollectableNectarPerRound > Nectar)
            {
                return 0;
            }
            else
            {
                Nectar -= CollectableNectarPerRound;
                CollectedNectar += CollectableNectarPerRound;
                return CollectableNectarPerRound;
            }
        }

        public void Progress()
        {
            Age++;

            if (Age > lifespan)
            {
                Alive = false;
            }
            else
            {
                Nectar += GrowthPerRound;
                if (Nectar > MaxNectar)
                {
                    Nectar = MaxNectar;
                }
            }
        }
    }
}
