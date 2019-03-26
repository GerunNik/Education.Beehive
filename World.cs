using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Beehive
{
    [Serializable]
    public class World
    {
        private const double CollectedNectarPerNewFlower = 50.0;
        private const int FieldMinX = 15;
        private const int FieldMinY = 177;
        private const int FieldMaxX = 690;
        private const int FieldMaxY = 290;

        public Hive Hive;
        public List<Bee> Bees;
        public List<Flower> Flowers;

        public World(Bee.BeeAlert alerter)
        {
            Bees = new List<Bee>();
            Flowers = new List<Flower>();
            Hive = new Hive(this, alerter);

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                NewFlower(random);
            }
        }

        public void Progress(Random random)
        {
            Hive.Progress(random);

            for (int i = Bees.Count - 1; i >= 0; i--)
            {
                Bee bee = Bees[i];
                bee.Progress(random);

                if (bee.CurrentStatus == BeeStatus.InRetirement)
                {
                    Bees.Remove(bee);
                }
            }

            double totalCollectedNectar = 0;
            for (int i = Flowers.Count - 1; i >= 0; i--)
            {
                Flower flower = Flowers[i];
                flower.Progress();
                totalCollectedNectar += flower.CollectedNectar;

                if (!flower.Alive)
                {
                    Flowers.Remove(flower);
                }
            }

            if (totalCollectedNectar > CollectedNectarPerNewFlower)
            {
                foreach (Flower flower in Flowers)
                {
                    flower.CollectedNectar = 0;
                }

                NewFlower(random);
            }
        }
        
        private void NewFlower(Random random)
        {
            Point place = new Point(random.Next(FieldMinX, FieldMaxX), random.Next(FieldMinY, FieldMaxY));
            Flower newFlower = new Flower(place, random);
            Flowers.Add(newFlower);
        }
    }
}