using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Beehive
{
    public partial class HiveForm : Form
    {
        public HiveForm()
        {
            InitializeComponent();
            BackgroundImage = Renderer.ScalePicture(Properties.Resources.Hive__inside_, ClientRectangle.Width, ClientRectangle.Height);
        }
    }
}
