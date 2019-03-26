using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Beehive
{
    [Serializable]
    public class Bee
    {
        private const double HoneyConsumption = 0.5;
        private const int Stepwidth = 3;
        private const double MinNectarInFlower = 1.5;
        private const int WorkingAge = 1000;

        public int Age { get; private set; }
        public bool InHive { get; private set; }
        public double CollectedNectar { get; private set; }

        public delegate void BeeAlert(int ID, string Message);
        public BeeAlert Alerter;

        private Point place;
        public Point Place { get { return place; } }

        private int ID;
        private Flower targetFlower;
        private World world;
        private Hive hive;

        public BeeStatus CurrentStatus { get; private set; }

        public Bee(int ID, Point startingPlace, World world, Hive hive)
        {
            this.ID = ID;
            Age = 0;
            place = startingPlace;
            InHive = true;
            CurrentStatus = BeeStatus.Useless;
            targetFlower = null;
            CollectedNectar = 0;
            this.world = world;
            this.hive = hive;
        }

        private bool MoveToLocation(Point target)
        {
            if (target != null)
            {
                if (Math.Abs(target.X - place.X) <= Stepwidth && Math.Abs(target.Y - place.Y) <= Stepwidth)
                {
                    return true;
                }

                if (target.X > place.X)
                {
                    place.X += Stepwidth;
                }
                else if (target.X < place.X)
                {
                    place.X -= Stepwidth;
                }

                if (target.Y > place.Y)
                {
                    place.Y += Stepwidth;
                }
                else if (target.Y < place.Y)
                {
                    place.Y -= Stepwidth;
                }
            }

            return false;
        }

        public void Progress(Random random)
        {
            Age++;
            BeeStatus ageStatus = CurrentStatus;
            switch (CurrentStatus)
            {
                case BeeStatus.Useless:
                    if (Age > WorkingAge)
                    {
                        CurrentStatus = BeeStatus.InRetirement;
                    }
                    else if (world.Flowers.Count > 0 && hive.ConsumeHoney(HoneyConsumption))
                    {
                        Flower flower = world.Flowers[random.Next(world.Flowers.Count)];

                        if (flower.Nectar >= MinNectarInFlower && flower.Alive)
                        {
                            targetFlower = flower;
                            CurrentStatus = BeeStatus.FlyingToFlower;
                        }
                    }
                    break;

                case BeeStatus.FlyingToFlower:
                    if (!world.Flowers.Contains(targetFlower))
                    {
                        CurrentStatus = BeeStatus.FlyingToHive;
                    }
                    else if (InHive)
                    {
                        if (MoveToLocation(hive.LookupPlace("Exit")))
                        {
                            InHive = false;
                            place = hive.LookupPlace("Entrance");
                        }
                    }
                    else
                    {
                        if (MoveToLocation(targetFlower.Place))
                        {
                            CurrentStatus = BeeStatus.CollectingNectar;
                        }
                    }
                    break;

                case BeeStatus.CollectingNectar:
                    double nectar = targetFlower.CollectNectar();
                    if (nectar > 0)
                    {
                        CollectedNectar += nectar;
                    }
                    else
                    {
                        CurrentStatus = BeeStatus.FlyingToHive;
                    }
                    break;

                case BeeStatus.FlyingToHive:
                    if (!InHive)
                    {
                        if (MoveToLocation(hive.LookupPlace("Entrance")))
                        {
                            InHive = true;
                            place = hive.LookupPlace("Exit");
                        }
                    }
                    else
                    {
                        if (MoveToLocation(hive.LookupPlace("HoneyFactory")))
                        {
                            CurrentStatus = BeeStatus.ProducingHoney;
                        }
                    }
                    break;

                case BeeStatus.ProducingHoney:
                    if (CollectedNectar < 0.5)
                    {
                        CollectedNectar = 0;
                        CurrentStatus = BeeStatus.Useless;
                    }
                    else
                    {
                        if (hive.AddHoney(0.5))
                        {
                            CollectedNectar -= 0.5;
                        }
                        else
                        {
                            CollectedNectar = 0;
                        }
                    }
                    break;

                case BeeStatus.InRetirement:
                    // Do nothing 
                    break;
            }

            if (ageStatus != CurrentStatus && Alerter != null)
            {
                Alerter(ID, CurrentStatus.ToString());
            }
        }
    }
}
