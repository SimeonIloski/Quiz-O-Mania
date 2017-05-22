using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Image myimage = new Bitmap(Image.FromFile("Pictures\\BG.png"));
            this.BackgroundImage = myimage;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            SingleFormOptions sfo = new SingleFormOptions();
            sfo.Show();
                     

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
