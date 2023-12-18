using CHESS_GAME__GALLARDO_.Properties;
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

namespace CHESS_GAME__GALLARDO_.Panels
{
    public partial class WelcomeArea : UserControl
    {
        public WelcomeArea()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            NamingArea Play = new NamingArea();
            this.Controls.Add(Play);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            AboutArea About = new AboutArea();
            this.Controls.Add(About);
        }
    }
}
