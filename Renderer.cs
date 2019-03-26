using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Beehive {
    public class Renderer {
        private World world;
        private HiveForm hiveForm;
        private FieldForm fieldForm;

        private Dictionary<Flower, PictureBox> flowerDictionary = new Dictionary<Flower, PictureBox>();
        private List<Flower> deadFlowers = new List<Flower>();

        private Dictionary<Bee, BeeControl> beeDictionary = new Dictionary<Bee, BeeControl>();
        private List<Bee> beesInRetirement = new List<Bee>();

        public Renderer(World world, HiveForm hiveForm, FieldForm fieldForm)
        {
            this.world = world;
            this.hiveForm = hiveForm;
            this.fieldForm = fieldForm;
        }

        public static Bitmap ScalePicture(Bitmap graphic, int width, int height)
        {
            Bitmap scaledGraphic = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(scaledGraphic))
            {
                graphics.DrawImage(graphic, 0, 0, width, height);
            }

            return scaledGraphic;
        }

        public void Render()
        {
            DrawBees();
            DrawFlowers();
            RemoveDeadFlowersAndBees();
        }

        public void Reset()
        {
            foreach (PictureBox flower in flowerDictionary.Values)
            {
                fieldForm.Controls.Remove(flower);
                flower.Dispose();
            }

            foreach (BeeControl bee in beeDictionary.Values)
            {
                hiveForm.Controls.Remove(bee);
                fieldForm.Controls.Remove(bee);
                bee.Dispose();
            }

            flowerDictionary.Clear();
            beeDictionary.Clear();
        }

        private void DrawFlowers()
        {
            foreach (Flower flower in world.Flowers)
            {
                if (!flowerDictionary.ContainsKey(flower))
                {
                    PictureBox flowerControl = new PictureBox()
                    {
                        Width = 45,
                        Height = 55,
                        Image = Properties.Resources.Flower,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Location = flower.Place
                    };

                    flowerDictionary.Add(flower, flowerControl);
                    fieldForm.Controls.Add(flowerControl);
                }
            }

            foreach (Flower flower in flowerDictionary.Keys)
            {
                if (!world.Flowers.Contains(flower))
                {
                    PictureBox flowerToRemove = flowerDictionary[flower];
                    fieldForm.Controls.Remove(flowerToRemove);

                    flowerToRemove.Dispose();
                    deadFlowers.Add(flower);
                }
            }
        }

        private void DrawBees()
        {
            BeeControl beeControl;
            foreach (Bee bee in world.Bees)
            {
                beeControl = SearchBeeControl(bee);
                if (bee.InHive)
                {
                    if (fieldForm.Controls.Contains(beeControl))
                    {
                        BeeFromFieldToHive(beeControl);
                    }
                }
                else if (hiveForm.Controls.Contains(beeControl))
                {
                    BeeFromHiveToField(beeControl, bee);
                }

                beeControl.Location = bee.Place;
            }

            foreach (Bee bee in beeDictionary.Keys)
            {
                if (!world.Bees.Contains(bee))
                {
                    beeControl = beeDictionary[bee];
                    if (fieldForm.Controls.Contains(beeControl))
                    {
                        fieldForm.Controls.Remove(beeControl);
                    }

                    if (hiveForm.Controls.Contains(beeControl))
                    {
                        hiveForm.Controls.Remove(beeControl);
                    }

                    beeControl.Dispose();
                    beesInRetirement.Add(bee);
                }
            }
        }

        private BeeControl SearchBeeControl(Bee bee)
        {
            BeeControl beeControl;
            if (!beeDictionary.ContainsKey(bee))
            {
                beeControl = new BeeControl() { Width = 40, Height = 40 };
                beeDictionary.Add(bee, beeControl);
                hiveForm.Controls.Add(beeControl);
                beeControl.BringToFront();
            }
            else
            {
                beeControl = beeDictionary[bee];
            }

            return beeControl;
        }

        private void RemoveDeadFlowersAndBees()
        {
            foreach (Bee biene in beesInRetirement)
            {
                beeDictionary.Remove(biene);
            }

            beesInRetirement.Clear();
            foreach (Flower blume in deadFlowers)
            {
                flowerDictionary.Remove(blume);
            }

            deadFlowers.Clear();
        }

        private void BeeFromHiveToField(BeeControl beeControl, Bee bee)
        {
            hiveForm.Controls.Remove(beeControl);
            beeControl.Size = new Size(20, 20);
            fieldForm.Controls.Add(beeControl);
            beeControl.BringToFront();
        }


        private void BeeFromFieldToHive(BeeControl beeControl)
        {
            fieldForm.Controls.Remove(beeControl);
            beeControl.Size = new Size(40, 40);
            hiveForm.Controls.Add(beeControl);
            beeControl.BringToFront();
        }
    }
}
