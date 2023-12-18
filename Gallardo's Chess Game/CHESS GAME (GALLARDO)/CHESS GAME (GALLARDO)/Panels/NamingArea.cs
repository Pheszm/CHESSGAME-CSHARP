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
    public partial class NamingArea : UserControl
    {
        public NamingArea()
        {
            InitializeComponent();
        }

        private void PLAYBUTTON_Click(object sender, EventArgs e)
        {
            if (BlackTextBox.Text != "" && WhiteTextBox.Text != "")
            {
                this.Controls.Clear();
                ChessPlaying Play = new ChessPlaying();
                Play.BlackUserName = BlackTextBox.Text;
                Play.WhiteUserName = WhiteTextBox.Text;
                this.Controls.Add(Play);
            }
        }
    }
}
