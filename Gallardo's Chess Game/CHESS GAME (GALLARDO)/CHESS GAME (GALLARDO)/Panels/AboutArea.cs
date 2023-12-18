using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHESS_GAME__GALLARDO_.Panels
{
    public partial class AboutArea : UserControl
    {
        public AboutArea()
        {
            InitializeComponent();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            WelcomeArea Welcomee = new WelcomeArea();
            this.Controls.Add(Welcomee);
        }
    }
}
