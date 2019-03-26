using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Beehive {
    public partial class BeeControl : UserControl
    {
        private int cell;
        private Bitmap[] cells = new Bitmap[4];

        public BeeControl()
        {
            InitializeComponent();
            BackColor = System.Drawing.Color.Transparent;
            BackgroundImageLayout = ImageLayout.None;
            ScaleCells();
        }

        private void ScaleCells()
        {
            cells[0] = Renderer.ScalePicture(Properties.Resources.Bee_animation_1, Width, Height);
            cells[1] = Renderer.ScalePicture(Properties.Resources.Bee_animation_2, Width, Height);
            cells[2] = Renderer.ScalePicture(Properties.Resources.Bee_animation_3, Width, Height);
            cells[3] = Renderer.ScalePicture(Properties.Resources.Bee_animation_4, Width, Height);
        }

        void animationTimer_Tick(object sender, EventArgs e)
        {
            cell++;

            switch (cell)
            {
                case 1: 
                    BackgroundImage = cells[0]; 
                    break;

                case 2:                                                                                           
                    BackgroundImage = cells[1]; 
                    break;

                case 3:                                                                                      
                    BackgroundImage = cells[2]; 
                    break;

                case 4:                                                                                       
                    BackgroundImage = cells[3]; 
                    break;

                case 5:                                                                                     
                    BackgroundImage = cells[2];
                    break;

                default:
                    BackgroundImage = cells[1];
                    cell = 0;
                    break;
            }
        }

        private void BeeControl_Resize(object sender, EventArgs e) {
            ScaleCells();
        }
    }
}
