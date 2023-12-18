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

namespace CHESS_GAME__GALLARDO_
{
    public partial class ChessMain : Form
    {
        private SoundPlayer BackgroundMusic = new SoundPlayer(Resources.ChessGameBackgroundMusic);
        public ChessMain()
        {
            InitializeComponent();
            RunFirstPage();
            BackgroundMusic.PlayLooping();
        }

        public void RunFirstPage()
        {
            Panels.WelcomeArea welcome = new Panels.WelcomeArea();
            MainPanel.Controls.Add(welcome);
        }
    }
}
