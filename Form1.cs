using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Beehive
{
    public partial class Form1 : Form
    {
        World world;

        private Random random = new Random();
        private DateTime start = DateTime.Now;
        private DateTime end;
        private int passedFrames = 0;

        HiveForm hiveForm = new HiveForm();
        FieldForm fieldForm = new FieldForm();
        Renderer renderer;

        public Form1()
        {
            InitializeComponent();
            MoveChildFormular();
            hiveForm.Show(this);
            fieldForm.Show(this);
            ResetSim();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(ExecuteFramce);
            timer1.Enabled = false;
            UpdateStatistics(new TimeSpan());
        }

        private void MoveChildFormular()
        {
            hiveForm.Location = new Point(Location.X + Width + 10, Location.Y);
            fieldForm.Location = new Point(Location.X, Location.Y + Math.Max(Height, hiveForm.Height) + 10);
        }

        private void UpdateStatistics(TimeSpan frameDuration)
        {
            Bees.Text = world.Bees.Count.ToString();
            Flowers.Text = world.Flowers.Count.ToString();
            HoneyInHive.Text = string.Format("{0:f3}", world.Hive.Honey);

            double nectar = 0;

            foreach (Flower flower in world.Flowers)
            {
                nectar += flower.Nectar;
            }

            NectarInFlowers.Text = string.Format("{0:f3}", nectar);
            PassedFrames.Text = passedFrames.ToString();
        }

        public void ExecuteFramce(object sender, EventArgs e)
        {
            passedFrames++;
            world.Progress(random);
            renderer.Render();
            end = DateTime.Now;
            TimeSpan frameDuration = end - start;
            start = end;
            UpdateStatistics(frameDuration);
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            MoveChildFormular();
        }

        private void simulationStarten_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) {
                toolStrip1.Items[0].Text = "Continue simulation";
                timer1.Stop();
            }
            else {
                toolStrip1.Items[0].Text = "Stop simulation";
                timer1.Start();
            }
        }

        private void ResetSim()
        {
            passedFrames = 0;
            world = new World(new Bee.BeeAlert(SendAlert));
            renderer = new Renderer(world, hiveForm, fieldForm);
        }

        private void reset_Click(object sender, EventArgs e)
        {
            renderer.Reset();
            ResetSim();
            if (!timer1.Enabled)
            {
                toolStrip1.Items[0].Text = "Start simulation";
            }
        }
        private void saveToolStripButton_Click(object sender, EventArgs e) {
            bool activated = timer1.Enabled;
            if (activated)
            {
                timer1.Stop();
            }

            world.Hive.Alerter = null;
            foreach (Bee bee in world.Bees)
            {
                bee.Alerter = null;
            }

            SaveFileDialog speichernDialog = new SaveFileDialog();
            speichernDialog.Filter = "Simulator-Files (*.bee)|*.bee";
            speichernDialog.CheckPathExists = true;

            if (speichernDialog.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream output = File.OpenWrite(speichernDialog.FileName))
                {
                    bf.Serialize(output, world);
                    bf.Serialize(output, passedFrames);
                }
            }

            world.Hive.Alerter = new Bee.BeeAlert(SendAlert);

            foreach (Bee biene in world.Bees)
            {
                biene.Alerter = new Bee.BeeAlert(SendAlert);
            }

            if (activated)
            {
                timer1.Start();
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            World currentWorld = world;
            int currentFrames = passedFrames;

            bool activated = timer1.Enabled;

            if (activated)
            {
                timer1.Stop();
            }

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Simulator-Files (*.bee)|*.bee";
            openDialog.CheckPathExists = true;
            openDialog.CheckFileExists = true;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (Stream output = File.OpenRead(openDialog.FileName))
                {
                    world = (World)formatter.Deserialize(output);
                    passedFrames = (int)formatter.Deserialize(output);
                }
            }

            world.Hive.Alerter = new Bee.BeeAlert(SendAlert);

            foreach (Bee bee in world.Bees)
            {
                bee.Alerter = new Bee.BeeAlert(SendAlert);
            }

            if (activated)
            {
                timer1.Start();
            }

            renderer.Reset();
            renderer = new Renderer(world, hiveForm, fieldForm);
        }

        private void SendAlert(int ID, string alert)
        {
            statusStrip1.Items[0].Text = "Bee " + ID + ": " + alert;
            var beeGroups = from bee in world.Bees group bee by bee.CurrentStatus into beeGroup orderby beeGroup.Key select beeGroup;
            listBox1.Items.Clear();

            foreach (var gruppe in beeGroups)
            {
                string s;
                if (gruppe.Count() == 1)
                {
                    s = "";
                }
                else
                {
                    s = "n";
                }

                listBox1.Items.Add(gruppe.Key.ToString() + ": " + gruppe.Count() + " Bee" + s);

                if (gruppe.Key == BeeStatus.Useless && gruppe.Count() == world.Bees.Count() && passedFrames > 0)
                {
                    listBox1.Items.Add("Simulation ended: Alle Bees are useless");
                    toolStrip1.Items[0].Text = "Simulation ended";
                    statusStrip1.Items[0].Text = "Simulation ended";

                    timer1.Enabled = false;
                }
            }
        }
    }
}
