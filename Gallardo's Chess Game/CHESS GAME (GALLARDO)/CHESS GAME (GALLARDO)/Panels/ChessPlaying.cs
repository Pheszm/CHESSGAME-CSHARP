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
    public partial class ChessPlaying : UserControl
    {
        private SoundPlayer MoveSound = new SoundPlayer(Resources.MovedSound);

        public string BlackUserName = "";
        public string WhiteUserName = "";
        string LocationOfPawn = "";
        string BlockToClear = "";
        bool TforBlackAndFforWhite = true;
        string PieceToMove = "";
        bool moveover = false;

        string BlockA1 = "BROOK";
        string BlockA2 = "BHORSE";
        string BlockA3 = "BBISHOP";
        string BlockA4 = "BQUEEN";
        string BlockA5 = "BKING";
        string BlockA6 = "BBISHOP";
        string BlockA7 = "BHORSE";
        string BlockA8 = "BROOK";

        string BlockB1 = "BPAWN";
        string BlockB2 = "BPAWN";
        string BlockB3 = "BPAWN";
        string BlockB4 = "BPAWN";
        string BlockB5 = "BPAWN";
        string BlockB6 = "BPAWN";
        string BlockB7 = "BPAWN";
        string BlockB8 = "BPAWN";

        string BlockC1 = "";
        string BlockC2 = "";
        string BlockC3 = "";
        string BlockC4 = "";
        string BlockC5 = "";
        string BlockC6 = "";
        string BlockC7 = "";
        string BlockC8 = "";

        string BlockD1 = "";
        string BlockD2 = "";
        string BlockD3 = "";
        string BlockD4 = "";
        string BlockD5 = "";
        string BlockD6 = "";
        string BlockD7 = "";
        string BlockD8 = "";

        string BlockE1 = "";
        string BlockE2 = "";
        string BlockE3 = "";
        string BlockE4 = "";
        string BlockE5 = "";
        string BlockE6 = "";
        string BlockE7 = "";
        string BlockE8 = "";

        string BlockF1 = "";
        string BlockF2 = "";
        string BlockF3 = "";
        string BlockF4 = "";
        string BlockF5 = "";
        string BlockF6 = "";
        string BlockF7 = "";
        string BlockF8 = "";

        string BlockG1 = "WPAWN";
        string BlockG2 = "WPAWN";
        string BlockG3 = "WPAWN";
        string BlockG4 = "WPAWN";
        string BlockG5 = "WPAWN";
        string BlockG6 = "WPAWN";
        string BlockG7 = "WPAWN";
        string BlockG8 = "WPAWN";

        string BlockH1 = "WROOK";
        string BlockH2 = "WHORSE";
        string BlockH3 = "WBISHOP";
        string BlockH4 = "WQUEEN";
        string BlockH5 = "WKING";
        string BlockH6 = "WBISHOP";
        string BlockH7 = "WHORSE";
        string BlockH8 = "WROOK";



        public ChessPlaying()
        {
            InitializeComponent();
            ResetBoard();
            WhosMove.Text = "BLACK First Turn";
            MoveSound.Play();
        }

        void ResetBoard()
        {
            Unselect.Visible = false;

            PictureBox[,] buttonsArray = new PictureBox[8, 8]
            {
            { A1, A2, A3, A4, A5, A6, A7, A8 },
            { B1, B2, B3, B4, B5, B6, B7, B8 },
            { C1, C2, C3, C4, C5, C6, C7, C8 },
            { D1, D2, D3, D4, D5, D6, D7, D8 },
            { E1, E2, E3, E4, E5, E6, E7, E8 },
            { F1, F2, F3, F4, F5, F6, F7, F8 },
            { G1, G2, G3, G4, G5, G6, G7, G8 },
            { H1, H2, H3, H4, H5, H6, H7, H8 }
            };

            for (int i = 0; i < buttonsArray.GetLength(0); i++)
            {
                for (int j = 0; j < buttonsArray.GetLength(1); j++)
                {
                    buttonsArray[i, j].BackColor = Color.Transparent;
                }
            }

            for (int i = 0; i < buttonsArray.GetLength(0); i++)
            {
                for (int j = 0; j < buttonsArray.GetLength(1); j++)
                {
                    buttonsArray[i, j].Enabled = false;
                }
            }


            for (int i = 0; i < buttonsArray.GetLength(0); i++)
            {
                for (int j = 0; j < buttonsArray.GetLength(1); j++)
                {
                    buttonsArray[i, j].BackgroundImage = null;
                }
            }



            string[] blockTypes = { "BPAWN", "BKING", "BQUEEN", "BBISHOP", "BHORSE", "BROOK", "WPAWN", "WKING", "WQUEEN", "WBISHOP", "WHORSE", "WROOK" };
            string[] resourceNames = { "BPawn", "BKing", "BQueen", "BBishop", "BHorse", "BRook", "WPawn", "WKing", "WQueen", "WBishop", "WHorse", "WRook" };

            string[] blockPositions = { BlockA1, BlockA2, BlockA3, BlockA4, BlockA5, BlockA6, BlockA7, BlockA8,
                            BlockB1, BlockB2, BlockB3, BlockB4, BlockB5, BlockB6, BlockB7, BlockB8,
                            BlockC1, BlockC2, BlockC3, BlockC4, BlockC5, BlockC6, BlockC7, BlockC8,
                            BlockD1, BlockD2, BlockD3, BlockD4, BlockD5, BlockD6, BlockD7, BlockD8,
                            BlockE1, BlockE2, BlockE3, BlockE4, BlockE5, BlockE6, BlockE7, BlockE8,
                            BlockF1, BlockF2, BlockF3, BlockF4, BlockF5, BlockF6, BlockF7, BlockF8,
                            BlockG1, BlockG2, BlockG3, BlockG4, BlockG5, BlockG6, BlockG7, BlockG8,
                            BlockH1, BlockH2, BlockH3, BlockH4, BlockH5, BlockH6, BlockH7, BlockH8 };

            PictureBox[] blockImages = { A1, A2, A3, A4, A5, A6, A7, A8,
                            B1, B2, B3, B4, B5, B6, B7, B8,
                            C1, C2, C3, C4, C5, C6, C7, C8,
                            D1, D2, D3, D4, D5, D6, D7, D8,
                            E1, E2, E3, E4, E5, E6, E7, E8,
                            F1, F2, F3, F4, F5, F6, F7, F8,
                            G1, G2, G3, G4, G5, G6, G7, G8,
                            H1, H2, H3, H4, H5, H6, H7, H8 };

            for (int j = 0; j < blockPositions.Length; j++)
            {
                for (int i = 0; i < blockTypes.Length; i++)
                {
                    if (blockPositions[j] == blockTypes[i])
                    {
                        string resourceName = resourceNames[i];
                        blockImages[j].BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourceName);
                        break;
                    }
                }
            }
            WhosTurn();
            PawnEveloving();
            CheckIfKingDead();
        }


        void CheckIfKingDead()
        {
            bool BlackKing = false;
            if (BlockA1 == "BKING") BlackKing = true;
            if (BlockA2 == "BKING") BlackKing = true;
            if (BlockA3 == "BKING") BlackKing = true;
            if (BlockA4 == "BKING") BlackKing = true;
            if (BlockA5 == "BKING") BlackKing = true;
            if (BlockA6 == "BKING") BlackKing = true;
            if (BlockA7 == "BKING") BlackKing = true;
            if (BlockA8 == "BKING") BlackKing = true;

            if (BlockB1 == "BKING") BlackKing = true;
            if (BlockB2 == "BKING") BlackKing = true;
            if (BlockB3 == "BKING") BlackKing = true;
            if (BlockB4 == "BKING") BlackKing = true;
            if (BlockB5 == "BKING") BlackKing = true;
            if (BlockB6 == "BKING") BlackKing = true;
            if (BlockB7 == "BKING") BlackKing = true;
            if (BlockB8 == "BKING") BlackKing = true;

            if (BlockC1 == "BKING") BlackKing = true;
            if (BlockC2 == "BKING") BlackKing = true;
            if (BlockC3 == "BKING") BlackKing = true;
            if (BlockC4 == "BKING") BlackKing = true;
            if (BlockC5 == "BKING") BlackKing = true;
            if (BlockC6 == "BKING") BlackKing = true;
            if (BlockC7 == "BKING") BlackKing = true;
            if (BlockC8 == "BKING") BlackKing = true;

            if (BlockD1 == "BKING") BlackKing = true;
            if (BlockD2 == "BKING") BlackKing = true;
            if (BlockD3 == "BKING") BlackKing = true;
            if (BlockD4 == "BKING") BlackKing = true;
            if (BlockD5 == "BKING") BlackKing = true;
            if (BlockD6 == "BKING") BlackKing = true;
            if (BlockD7 == "BKING") BlackKing = true;
            if (BlockD8 == "BKING") BlackKing = true;

            if (BlockE1 == "BKING") BlackKing = true;
            if (BlockE2 == "BKING") BlackKing = true;
            if (BlockE3 == "BKING") BlackKing = true;
            if (BlockE4 == "BKING") BlackKing = true;
            if (BlockE5 == "BKING") BlackKing = true;
            if (BlockE6 == "BKING") BlackKing = true;
            if (BlockE7 == "BKING") BlackKing = true;
            if (BlockE8 == "BKING") BlackKing = true;

            if (BlockF1 == "BKING") BlackKing = true;
            if (BlockF2 == "BKING") BlackKing = true;
            if (BlockF3 == "BKING") BlackKing = true;
            if (BlockF4 == "BKING") BlackKing = true;
            if (BlockF5 == "BKING") BlackKing = true;
            if (BlockF6 == "BKING") BlackKing = true;
            if (BlockF7 == "BKING") BlackKing = true;
            if (BlockF8 == "BKING") BlackKing = true;

            if (BlockG1 == "BKING") BlackKing = true;
            if (BlockG2 == "BKING") BlackKing = true;
            if (BlockG3 == "BKING") BlackKing = true;
            if (BlockG4 == "BKING") BlackKing = true;
            if (BlockG5 == "BKING") BlackKing = true;
            if (BlockG6 == "BKING") BlackKing = true;
            if (BlockG7 == "BKING") BlackKing = true;
            if (BlockG8 == "BKING") BlackKing = true;

            if (BlockH1 == "BKING") BlackKing = true;
            if (BlockH2 == "BKING") BlackKing = true;
            if (BlockH3 == "BKING") BlackKing = true;
            if (BlockH4 == "BKING") BlackKing = true;
            if (BlockH5 == "BKING") BlackKing = true;
            if (BlockH6 == "BKING") BlackKing = true;
            if (BlockH7 == "BKING") BlackKing = true;
            if (BlockH8 == "BKING") BlackKing = true;

            if (BlackKing == false) {
                SoundPlayer Congrats = new SoundPlayer(Resources.Congratulations_Sound_Effect);
                Congrats.Play();
                ButtonsDisable();
                WhosWinner.Text = WhiteUserName + " WINS!";
                WhosWinner.Visible = true;
                GotoMenu.Visible = true;
                }


            bool WhiteKing = false;
            if (BlockA1 == "WKING") WhiteKing = true;
            if (BlockA2 == "WKING") WhiteKing = true;
            if (BlockA3 == "WKING") WhiteKing = true;
            if (BlockA4 == "WKING") WhiteKing = true;
            if (BlockA5 == "WKING") WhiteKing = true;
            if (BlockA6 == "WKING") WhiteKing = true;
            if (BlockA7 == "WKING") WhiteKing = true;
            if (BlockA8 == "WKING") WhiteKing = true;

            if (BlockB1 == "WKING") WhiteKing = true;
            if (BlockB2 == "WKING") WhiteKing = true;
            if (BlockB3 == "WKING") WhiteKing = true;
            if (BlockB4 == "WKING") WhiteKing = true;
            if (BlockB5 == "WKING") WhiteKing = true;
            if (BlockB6 == "WKING") WhiteKing = true;
            if (BlockB7 == "WKING") WhiteKing = true;
            if (BlockB8 == "WKING") WhiteKing = true;

            if (BlockC1 == "WKING") WhiteKing = true;
            if (BlockC2 == "WKING") WhiteKing = true;
            if (BlockC3 == "WKING") WhiteKing = true;
            if (BlockC4 == "WKING") WhiteKing = true;
            if (BlockC5 == "WKING") WhiteKing = true;
            if (BlockC6 == "WKING") WhiteKing = true;
            if (BlockC7 == "WKING") WhiteKing = true;
            if (BlockC8 == "WKING") WhiteKing = true;

            if (BlockD1 == "WKING") WhiteKing = true;
            if (BlockD2 == "WKING") WhiteKing = true;
            if (BlockD3 == "WKING") WhiteKing = true;
            if (BlockD4 == "WKING") WhiteKing = true;
            if (BlockD5 == "WKING") WhiteKing = true;
            if (BlockD6 == "WKING") WhiteKing = true;
            if (BlockD7 == "WKING") WhiteKing = true;
            if (BlockD8 == "WKING") WhiteKing = true;

            if (BlockE1 == "WKING") WhiteKing = true;
            if (BlockE2 == "WKING") WhiteKing = true;
            if (BlockE3 == "WKING") WhiteKing = true;
            if (BlockE4 == "WKING") WhiteKing = true;
            if (BlockE5 == "WKING") WhiteKing = true;
            if (BlockE6 == "WKING") WhiteKing = true;
            if (BlockE7 == "WKING") WhiteKing = true;
            if (BlockE8 == "WKING") WhiteKing = true;

            if (BlockF1 == "WKING") WhiteKing = true;
            if (BlockF2 == "WKING") WhiteKing = true;
            if (BlockF3 == "WKING") WhiteKing = true;
            if (BlockF4 == "WKING") WhiteKing = true;
            if (BlockF5 == "WKING") WhiteKing = true;
            if (BlockF6 == "WKING") WhiteKing = true;
            if (BlockF7 == "WKING") WhiteKing = true;
            if (BlockF8 == "WKING") WhiteKing = true;

            if (BlockG1 == "WKING") WhiteKing = true;
            if (BlockG2 == "WKING") WhiteKing = true;
            if (BlockG3 == "WKING") WhiteKing = true;
            if (BlockG4 == "WKING") WhiteKing = true;
            if (BlockG5 == "WKING") WhiteKing = true;
            if (BlockG6 == "WKING") WhiteKing = true;
            if (BlockG7 == "WKING") WhiteKing = true;
            if (BlockG8 == "WKING") WhiteKing = true;

            if (BlockH1 == "WKING") WhiteKing = true;
            if (BlockH2 == "WKING") WhiteKing = true;
            if (BlockH3 == "WKING") WhiteKing = true;
            if (BlockH4 == "WKING") WhiteKing = true;
            if (BlockH5 == "WKING") WhiteKing = true;
            if (BlockH6 == "WKING") WhiteKing = true;
            if (BlockH7 == "WKING") WhiteKing = true;
            if (BlockH8 == "WKING") WhiteKing = true;

            if (WhiteKing == false)
            {
                SoundPlayer Congrats = new SoundPlayer(Resources.Congratulations_Sound_Effect);
                Congrats.Play();
                ButtonsDisable();
                WhosWinner.Text = BlackUserName + " WINS!";
                WhosWinner.Visible = true;
                GotoMenu.Visible = true;
            }
        }

        void WhosTurn()
        {

            if (TforBlackAndFforWhite == true)
            {
                WhosMove.ForeColor = Color.Black;
                WhosMove.Text = BlackUserName + "s Turn";
                string[] blockTypes = { "BPAWN", "BKING", "BQUEEN", "BBISHOP", "BHORSE", "BROOK", "WPAWN", "WKING", "WQUEEN", "WBISHOP", "WHORSE", "WROOK" };

                string[] blockPositions = { BlockA1, BlockA2, BlockA3, BlockA4, BlockA5, BlockA6, BlockA7, BlockA8,
                            BlockB1, BlockB2, BlockB3, BlockB4, BlockB5, BlockB6, BlockB7, BlockB8,
                            BlockC1, BlockC2, BlockC3, BlockC4, BlockC5, BlockC6, BlockC7, BlockC8,
                            BlockD1, BlockD2, BlockD3, BlockD4, BlockD5, BlockD6, BlockD7, BlockD8,
                            BlockE1, BlockE2, BlockE3, BlockE4, BlockE5, BlockE6, BlockE7, BlockE8,
                            BlockF1, BlockF2, BlockF3, BlockF4, BlockF5, BlockF6, BlockF7, BlockF8,
                            BlockG1, BlockG2, BlockG3, BlockG4, BlockG5, BlockG6, BlockG7, BlockG8,
                            BlockH1, BlockH2, BlockH3, BlockH4, BlockH5, BlockH6, BlockH7, BlockH8 };

                PictureBox[] buttons = { A1, A2, A3, A4, A5, A6, A7, A8,
                     B1, B2, B3, B4, B5, B6, B7, B8,
                     C1, C2, C3, C4, C5, C6, C7, C8,
                     D1, D2, D3, D4, D5, D6, D7, D8,
                     E1, E2, E3, E4, E5, E6, E7, E8,
                     F1, F2, F3, F4, F5, F6, F7, F8,
                     G1, G2, G3, G4, G5, G6, G7, G8,
                     H1, H2, H3, H4, H5, H6, H7, H8 };


                for (int i = 0; i < blockPositions.Length; i++)
                {
                    for (int j = 0; j < blockTypes.Length; j++)
                    {
                        if (blockPositions[i] == blockTypes[j])
                        {
                            buttons[i].Enabled = false; 

                            if (!blockTypes[j].StartsWith("W"))
                            {
                                buttons[i].Enabled = true;
                            }
                            break;
                        }
                    }
                }
            }

            if (TforBlackAndFforWhite == false)
            {
                WhosMove.ForeColor = Color.White;
                WhosMove.Text = WhiteUserName + "s Turn";

                string[] blockTypes = { "BPAWN", "BKING", "BQUEEN", "BBISHOP", "BHORSE", "BROOK", "WPAWN", "WKING", "WQUEEN", "WBISHOP", "WHORSE", "WROOK" };

                string[] blockPositions = { BlockA1, BlockA2, BlockA3, BlockA4, BlockA5, BlockA6, BlockA7, BlockA8,
                            BlockB1, BlockB2, BlockB3, BlockB4, BlockB5, BlockB6, BlockB7, BlockB8,
                            BlockC1, BlockC2, BlockC3, BlockC4, BlockC5, BlockC6, BlockC7, BlockC8,
                            BlockD1, BlockD2, BlockD3, BlockD4, BlockD5, BlockD6, BlockD7, BlockD8,
                            BlockE1, BlockE2, BlockE3, BlockE4, BlockE5, BlockE6, BlockE7, BlockE8,
                            BlockF1, BlockF2, BlockF3, BlockF4, BlockF5, BlockF6, BlockF7, BlockF8,
                            BlockG1, BlockG2, BlockG3, BlockG4, BlockG5, BlockG6, BlockG7, BlockG8,
                            BlockH1, BlockH2, BlockH3, BlockH4, BlockH5, BlockH6, BlockH7, BlockH8 };

                PictureBox[] buttons = { A1, A2, A3, A4, A5, A6, A7, A8,
                     B1, B2, B3, B4, B5, B6, B7, B8,
                     C1, C2, C3, C4, C5, C6, C7, C8,
                     D1, D2, D3, D4, D5, D6, D7, D8,
                     E1, E2, E3, E4, E5, E6, E7, E8,
                     F1, F2, F3, F4, F5, F6, F7, F8,
                     G1, G2, G3, G4, G5, G6, G7, G8,
                     H1, H2, H3, H4, H5, H6, H7, H8 };

                for (int i = 0; i < blockPositions.Length; i++)
                {
                    for (int j = 0; j < blockTypes.Length; j++)
                    {
                        if (blockPositions[i] == blockTypes[j])
                        {
                            buttons[i].Enabled = false;

                            if (!blockTypes[j].StartsWith("B"))
                            {
                                buttons[i].Enabled = true;
                            }
                            break;
                        }
                    }
                }
            }
        }



        string CheckColorOfPiece(string Position)
        {
                string Resultz = "";
                Dictionary<string, string> blockVariables = new Dictionary<string, string>
            {
                { "A1", BlockA1 }, { "A2", BlockA2 }, { "A3", BlockA3 }, { "A4", BlockA4 },
                { "A5", BlockA5 }, { "A6", BlockA6 }, { "A7", BlockA7 }, { "A8", BlockA8 },
                { "B1", BlockB1 }, { "B2", BlockB2 }, { "B3", BlockB3 }, { "B4", BlockB4 },
                { "B5", BlockB5 }, { "B6", BlockB6 }, { "B7", BlockB7 }, { "B8", BlockB8 },
                { "C1", BlockC1 }, { "C2", BlockC2 }, { "C3", BlockC3 }, { "C4", BlockC4 },
                { "C5", BlockC5 }, { "C6", BlockC6 }, { "C7", BlockC7 }, { "C8", BlockC8 },
                { "D1", BlockD1 }, { "D2", BlockD2 }, { "D3", BlockD3 }, { "D4", BlockD4 },
                { "D5", BlockD5 }, { "D6", BlockD6 }, { "D7", BlockD7 }, { "D8", BlockD8 },
                { "E1", BlockE1 }, { "E2", BlockE2 }, { "E3", BlockE3 }, { "E4", BlockE4 },
                { "E5", BlockE5 }, { "E6", BlockE6 }, { "E7", BlockE7 }, { "E8", BlockE8 },
                { "F1", BlockF1 }, { "F2", BlockF2 }, { "F3", BlockF3 }, { "F4", BlockF4 },
                { "F5", BlockF5 }, { "F6", BlockF6 }, { "F7", BlockF7 }, { "F8", BlockF8 },
                { "G1", BlockG1 }, { "G2", BlockG2 }, { "G3", BlockG3 }, { "G4", BlockG4 },
                { "G5", BlockG5 }, { "G6", BlockG6 }, { "G7", BlockG7 }, { "G8", BlockG8 },
                { "H1", BlockH1 }, { "H2", BlockH2 }, { "H3", BlockH3 }, { "H4", BlockH4 },
                { "H5", BlockH5 }, { "H6", BlockH6 }, { "H7", BlockH7 }, { "H8", BlockH8 },
            };

                string currentBlock = blockVariables.ContainsKey(Position) ? blockVariables[Position] : "";

                switch (currentBlock)
                {
                    case "BPAWN":
                    case "BROOK":
                    case "BHORSE":
                    case "BBISHOP":
                    case "BQUEEN":
                    case "BKING":
                        Resultz = "BLACK";
                        break;

                    case "WPAWN":
                    case "WROOK":
                    case "WHORSE":
                    case "WBISHOP":
                    case "WQUEEN":
                    case "WKING":
                        Resultz = "WHITE";
                        break; 

                    default:
                        Resultz = "";
                        break; 
                }

                return Resultz;
            }

        






        void Highlighter(string Glow)
        {
            if (Glow == "A1") { A1.Enabled = true; A1.BackColor = Color.White; }
            if (Glow == "A2") { A2.Enabled = true; A2.BackColor = Color.Yellow; }
            if (Glow == "A3") { A3.Enabled = true; A3.BackColor = Color.White; }
            if (Glow == "A4") { A4.Enabled = true; A4.BackColor = Color.Yellow; }
            if (Glow == "A5") { A5.Enabled = true; A5.BackColor = Color.White; }
            if (Glow == "A6") { A6.Enabled = true; A6.BackColor = Color.Yellow; }
            if (Glow == "A7") { A7.Enabled = true; A7.BackColor = Color.White; }
            if (Glow == "A8") { A8.Enabled = true; A8.BackColor = Color.Yellow; }

            if (Glow == "B1") { B1.Enabled = true; B1.BackColor = Color.Yellow; }
            if (Glow == "B2") { B2.Enabled = true; B2.BackColor = Color.White; }
            if (Glow == "B3") { B3.Enabled = true; B3.BackColor = Color.Yellow; }
            if (Glow == "B4") { B4.Enabled = true; B4.BackColor = Color.White; }
            if (Glow == "B5") { B5.Enabled = true; B5.BackColor = Color.Yellow; }
            if (Glow == "B6") { B6.Enabled = true; B6.BackColor = Color.White; }
            if (Glow == "B7") { B7.Enabled = true; B7.BackColor = Color.Yellow; }
            if (Glow == "B8") { B8.Enabled = true; B8.BackColor = Color.White; }

            if (Glow == "C1") { C1.Enabled = true; C1.BackColor = Color.White; }
            if (Glow == "C2") { C2.Enabled = true; C2.BackColor = Color.Yellow; }
            if (Glow == "C3") { C3.Enabled = true; C3.BackColor = Color.White; }
            if (Glow == "C4") { C4.Enabled = true; C4.BackColor = Color.Yellow; }
            if (Glow == "C5") { C5.Enabled = true; C5.BackColor = Color.White; }
            if (Glow == "C6") { C6.Enabled = true; C6.BackColor = Color.Yellow; }
            if (Glow == "C7") { C7.Enabled = true; C7.BackColor = Color.White; }
            if (Glow == "C8") { C8.Enabled = true; C8.BackColor = Color.Yellow; }

            if (Glow == "D1") { D1.Enabled = true; D1.BackColor = Color.Yellow; }
            if (Glow == "D2") { D2.Enabled = true; D2.BackColor = Color.White; }
            if (Glow == "D3") { D3.Enabled = true; D3.BackColor = Color.Yellow; }
            if (Glow == "D4") { D4.Enabled = true; D4.BackColor = Color.White; }
            if (Glow == "D5") { D5.Enabled = true; D5.BackColor = Color.Yellow; }
            if (Glow == "D6") { D6.Enabled = true; D6.BackColor = Color.White; }
            if (Glow == "D7") { D7.Enabled = true; D7.BackColor = Color.Yellow; }
            if (Glow == "D8") { D8.Enabled = true; D8.BackColor = Color.White; }
        
            if (Glow == "E1") { E1.Enabled = true; E1.BackColor = Color.White; }
            if (Glow == "E2") { E2.Enabled = true; E2.BackColor = Color.Yellow; }
            if (Glow == "E3") { E3.Enabled = true; E3.BackColor = Color.White; }
            if (Glow == "E4") { E4.Enabled = true; E4.BackColor = Color.Yellow; }
            if (Glow == "E5") { E5.Enabled = true; E5.BackColor = Color.White; }
            if (Glow == "E6") { E6.Enabled = true; E6.BackColor = Color.Yellow; }
            if (Glow == "E7") { E7.Enabled = true; E7.BackColor = Color.White; }
            if (Glow == "E8") { E8.Enabled = true; E8.BackColor = Color.Yellow; }

            if (Glow == "F1") { F1.Enabled = true; F1.BackColor = Color.Yellow; }
            if (Glow == "F2") { F2.Enabled = true; F2.BackColor = Color.White; }
            if (Glow == "F3") { F3.Enabled = true; F3.BackColor = Color.Yellow; }
            if (Glow == "F4") { F4.Enabled = true; F4.BackColor = Color.White; }
            if (Glow == "F5") { F5.Enabled = true; F5.BackColor = Color.Yellow; }
            if (Glow == "F6") { F6.Enabled = true; F6.BackColor = Color.White; }
            if (Glow == "F7") { F7.Enabled = true; F7.BackColor = Color.Yellow; }
            if (Glow == "F8") { F8.Enabled = true; F8.BackColor = Color.White; }
     
            if (Glow == "G1") { G1.Enabled = true; G1.BackColor = Color.White; }
            if (Glow == "G2") { G2.Enabled = true; G2.BackColor = Color.Yellow; }
            if (Glow == "G3") { G3.Enabled = true; G3.BackColor = Color.White; }
            if (Glow == "G4") { G4.Enabled = true; G4.BackColor = Color.Yellow; }
            if (Glow == "G5") { G5.Enabled = true; G5.BackColor = Color.White; }
            if (Glow == "G6") { G6.Enabled = true; G6.BackColor = Color.Yellow; }
            if (Glow == "G7") { G7.Enabled = true; G7.BackColor = Color.White; }
            if (Glow == "G8") { G8.Enabled = true; G8.BackColor = Color.Yellow; }

            if (Glow == "H1") { H1.Enabled = true; H1.BackColor = Color.Yellow; }
            if (Glow == "H2") { H2.Enabled = true; H2.BackColor = Color.White; }
            if (Glow == "H3") { H3.Enabled = true; H3.BackColor = Color.Yellow; }
            if (Glow == "H4") { H4.Enabled = true; H4.BackColor = Color.White; }
            if (Glow == "H5") { H5.Enabled = true; H5.BackColor = Color.Yellow; }
            if (Glow == "H6") { H6.Enabled = true; H6.BackColor = Color.White; }
            if (Glow == "H7") { H7.Enabled = true; H7.BackColor = Color.Yellow; }
            if (Glow == "H8") { H8.Enabled = true; H8.BackColor = Color.White; }
        }


        void ButtonsDisable()
        {
            if (TforBlackAndFforWhite == false)
            {
                WhosMove.Text = BlackUserName + "s Selecting Piece";
                WhosMove.ForeColor = Color.Black;
            }
            else if (TforBlackAndFforWhite == true)
            {
                WhosMove.Text = WhiteUserName + "s Selecting Piece";
                WhosMove.ForeColor = Color.White;
            }
            A1.Enabled = false;
            A2.Enabled = false;
            A3.Enabled = false;
            A4.Enabled = false;
            A5.Enabled = false;
            A6.Enabled = false;
            A7.Enabled = false;
            A8.Enabled = false;

            B1.Enabled = false;
            B2.Enabled = false;
            B3.Enabled = false;
            B4.Enabled = false;
            B5.Enabled = false;
            B6.Enabled = false;
            B7.Enabled = false;
            B8.Enabled = false;

            C1.Enabled = false;
            C2.Enabled = false;
            C3.Enabled = false;
            C4.Enabled = false;
            C5.Enabled = false;
            C6.Enabled = false;
            C7.Enabled = false;
            C8.Enabled = false;

            D1.Enabled = false;
            D2.Enabled = false;
            D3.Enabled = false;
            D4.Enabled = false;
            D5.Enabled = false;
            D6.Enabled = false;
            D7.Enabled = false;
            D8.Enabled = false;

            E1.Enabled = false;
            E2.Enabled = false;
            E3.Enabled = false;
            E4.Enabled = false;
            E5.Enabled = false;
            E6.Enabled = false;
            E7.Enabled = false;
            E8.Enabled = false;

            F1.Enabled = false;
            F2.Enabled = false;
            F3.Enabled = false;
            F4.Enabled = false;
            F5.Enabled = false;
            F6.Enabled = false;
            F7.Enabled = false;
            F8.Enabled = false;

            G1.Enabled = false;
            G2.Enabled = false;
            G3.Enabled = false;
            G4.Enabled = false;
            G5.Enabled = false;
            G6.Enabled = false;
            G7.Enabled = false;
            G8.Enabled = false;

            H1.Enabled = false;
            H2.Enabled = false;
            H3.Enabled = false;
            H4.Enabled = false;
            H5.Enabled = false;
            H6.Enabled = false;
            H7.Enabled = false;
            H8.Enabled = false;
        }

        void PawnEveloving()
        {
            if (BlockH1 == "BPAWN") { ButtonsDisable(); LocationOfPawn = "H1"; SelectPiece.Visible = true; }
            if (BlockH2 == "BPAWN") { ButtonsDisable(); LocationOfPawn = "H2"; SelectPiece.Visible = true; }
            if (BlockH3 == "BPAWN") { ButtonsDisable(); LocationOfPawn = "H3"; SelectPiece.Visible = true; }
            if (BlockH4 == "BPAWN") { ButtonsDisable(); LocationOfPawn = "H4"; SelectPiece.Visible = true; }
            if (BlockH5 == "BPAWN") { ButtonsDisable(); LocationOfPawn = "H5"; SelectPiece.Visible = true; }
            if (BlockH6 == "BPAWN") { ButtonsDisable(); LocationOfPawn = "H6"; SelectPiece.Visible = true; }
            if (BlockH7 == "BPAWN") { ButtonsDisable(); LocationOfPawn = "H7"; SelectPiece.Visible = true; }
            if (BlockH8 == "BPAWN") { ButtonsDisable(); LocationOfPawn = "H8"; SelectPiece.Visible = true; }

            if (BlockA1 == "WPAWN") { ButtonsDisable(); LocationOfPawn = "A1"; SelectPieceWhite.Visible = true; }
            if (BlockA2 == "WPAWN") { ButtonsDisable(); LocationOfPawn = "A2"; SelectPieceWhite.Visible = true; }
            if (BlockA3 == "WPAWN") { ButtonsDisable(); LocationOfPawn = "A3"; SelectPieceWhite.Visible = true; }
            if (BlockA4 == "WPAWN") { ButtonsDisable(); LocationOfPawn = "A4"; SelectPieceWhite.Visible = true; }
            if (BlockA5 == "WPAWN") { ButtonsDisable(); LocationOfPawn = "A5"; SelectPieceWhite.Visible = true; }
            if (BlockA6 == "WPAWN") { ButtonsDisable(); LocationOfPawn = "A6"; SelectPieceWhite.Visible = true; }
            if (BlockA7 == "WPAWN") { ButtonsDisable(); LocationOfPawn = "A7"; SelectPieceWhite.Visible = true; }
            if (BlockA8 == "WPAWN") { ButtonsDisable(); LocationOfPawn = "A8"; SelectPieceWhite.Visible = true; }
        }


        void QueenMove(char Letter, int Number, string Piece)
        {
            if (Piece == "BQUEEN")
            {
                int Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    Num++;
                    string Glow = Letter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }

                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    Num--;
                    string Glow = Letter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }

                int movLetter = (int)Letter;
                for (int i = 0; i <= 8; i++)
                {
                    movLetter--;
                    char ConsLetter = (char)movLetter;
                    string Glow = ConsLetter + Number.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }

                movLetter = (int)Letter;
                for (int i = 0; i <= 8; i++)
                {
                    movLetter++;
                    char ConsLetter = (char)movLetter;
                    string Glow = ConsLetter + Number.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }

                 int IncLetter = (int)Letter;
                 Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter++;
                    Num++;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }


                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter--;
                    Num++;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }

                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter--;
                    Num--;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }

                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter++;
                    Num--;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }
            }

            if (Piece == "WQUEEN")
            {
                int Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    Num++;
                    string Glow = Letter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    Num--;
                    string Glow = Letter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                int movLetter = (int)Letter;
                for (int i = 0; i <= 8; i++)
                {
                    movLetter--;
                    char ConsLetter = (char)movLetter;
                    string Glow = ConsLetter + Number.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                movLetter = (int)Letter;
                for (int i = 0; i <= 8; i++)
                {
                    movLetter++;
                    char ConsLetter = (char)movLetter;
                    string Glow = ConsLetter + Number.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                int IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter++;
                    Num++;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }


                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter--;
                    Num++;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter--;
                    Num--;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter++;
                    Num--;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }
            }
        }


        void RookMove(char Letter, int Number, string Piece)
        {
            if (Piece == "BROOK")
            {
                int Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    Num++;
                    string Glow = Letter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE"){ Highlighter(Glow); break;} 
                }

                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    Num--;
                    string Glow = Letter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }

                int movLetter = (int)Letter;
                for (int i = 0; i <= 8; i++)
                {
                    movLetter--;
                    char ConsLetter = (char)movLetter;
                    string Glow = ConsLetter + Number.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }

                movLetter = (int)Letter;
                for (int i = 0; i <= 8; i++)
                {
                    movLetter++;
                    char ConsLetter = (char)movLetter;
                    string Glow = ConsLetter + Number.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }
            }

            if (Piece == "WROOK")
            {
                int Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    Num++;
                    string Glow = Letter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    Num--;
                    string Glow = Letter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                int movLetter = (int)Letter;
                for (int i = 0; i <= 8; i++)
                {
                    movLetter--;
                    char ConsLetter = (char)movLetter;
                    string Glow = ConsLetter + Number.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                movLetter = (int)Letter;
                for (int i = 0; i <= 8; i++)
                {
                    movLetter++;
                    char ConsLetter = (char)movLetter;
                    string Glow = ConsLetter + Number.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }
            }
        }


        void BishopMove(char Letter, int Number, string Piece)
        {
            if (Piece == "BBISHOP")
            {
                int IncLetter = (int)Letter;
                int Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter++;
                    Num++;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }


                 IncLetter = (int)Letter;
                 Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter--;
                    Num++;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }

                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter--;
                    Num--;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }

                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter++;
                    Num--;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "BLACK") break;
                    else if (WhatColor == "WHITE") { Highlighter(Glow); break; }
                }
            }

            if (Piece == "WBISHOP")
            {
                int IncLetter = (int)Letter;
                int Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter++;
                    Num++;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }


                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter--;
                    Num++;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter--;
                    Num--;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }

                IncLetter = (int)Letter;
                Num = Number;
                for (int i = 0; i <= 8; i++)
                {
                    IncLetter++;
                    Num--;
                    char FinalLetter = (char)IncLetter;
                    string Glow = FinalLetter + Num.ToString();
                    string WhatColor = CheckColorOfPiece(Glow);

                    if (WhatColor == "") Highlighter(Glow);
                    else if (WhatColor == "WHITE") break;
                    else if (WhatColor == "BLACK") { Highlighter(Glow); break; }
                }
            }
        }


        void HorseMove(char Letter, int Number, string Piece)
        {
            if (Piece == "BHORSE")
            {
                int IncLetter = (int)Letter;
                int Num = Number;
                IncLetter-=2;
                Num++;
                char FinalLetter = (char)IncLetter;
                string Glow = FinalLetter + Num.ToString();
                string WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter -= 2;
                Num--;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);


                IncLetter = (int)Letter;
                Num = Number;
                IncLetter += 2;
                Num++;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter += 2;
                Num--;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);


                IncLetter = (int)Letter;
                Num = Number;
                IncLetter--;
                Num+=2;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter++;
                Num += 2;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);


                IncLetter = (int)Letter;
                Num = Number;
                IncLetter--;
                Num -= 2;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter++;
                Num -= 2;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);
            }

            if (Piece == "WHORSE")
            {
                int IncLetter = (int)Letter;
                int Num = Number;
                IncLetter -= 2;
                Num++;
                char FinalLetter = (char)IncLetter;
                string Glow = FinalLetter + Num.ToString();
                string WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter -= 2;
                Num--;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);


                IncLetter = (int)Letter;
                Num = Number;
                IncLetter += 2;
                Num++;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter += 2;
                Num--;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);


                IncLetter = (int)Letter;
                Num = Number;
                IncLetter--;
                Num += 2;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter++;
                Num += 2;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);


                IncLetter = (int)Letter;
                Num = Number;
                IncLetter--;
                Num -= 2;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter++;
                Num -= 2;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);
            }
        }


        void PawnMove(char Letter, int Number, string Piece)
        {
            if(Piece == "BPAWN")
            { 
                int IncLetter = (int)Letter;
                IncLetter++;
                char FinalLetter = (char)IncLetter;
                int Num = Number;
                Num++;
                string EatRightSide = FinalLetter + Num.ToString();
                
                string WhatColor = CheckColorOfPiece(EatRightSide);

                if (WhatColor == "WHITE")
                {
                    Highlighter(EatRightSide);
                }

                IncLetter = (int)Letter;
                IncLetter++;
                FinalLetter = (char)IncLetter;
                Num = Number;
                Num--;
                string EatLeftSide = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(EatLeftSide);
                if (WhatColor == "WHITE")
                {
                    Highlighter(EatLeftSide);

                }
                IncLetter = (int)Letter;
                IncLetter++;
                FinalLetter = (char)IncLetter;
                string MovesAvail = FinalLetter + Number.ToString();
                WhatColor = CheckColorOfPiece(MovesAvail);
                if (Letter == 'B' && WhatColor != "BLACK")
                {
                    Highlighter(MovesAvail);
                    IncLetter++;
                    FinalLetter = (char)IncLetter;
                    MovesAvail = FinalLetter + Number.ToString();
                    WhatColor = CheckColorOfPiece(MovesAvail);
                    if(WhatColor == "" || WhatColor == "WHITE") Highlighter(MovesAvail);
                }
                else if (WhatColor == "")
                {
                    Highlighter(MovesAvail);
                }
            }
            

            if (Piece == "WPAWN")
            {
                int IncLetter = (int)Letter;
                IncLetter--;
                char FinalLetter = (char)IncLetter;
                int Num = Number;
                Num++;
                string EatRightSide = FinalLetter + Num.ToString();

                string WhatColor = CheckColorOfPiece(EatRightSide);
                if (WhatColor == "BLACK")
                {
                    Highlighter(EatRightSide);
                }

                IncLetter = (int)Letter;
                IncLetter--;
                FinalLetter = (char)IncLetter;
                Num = Number;
                Num--;
                string EatLeftSide = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(EatLeftSide);
                if (WhatColor == "BLACK")
                {
                    Highlighter(EatLeftSide);

                }

                IncLetter = (int)Letter;
                IncLetter--;
                FinalLetter = (char)IncLetter;
                string MovesAvail = FinalLetter + Number.ToString();
                WhatColor = CheckColorOfPiece(MovesAvail);
                if (Letter == 'G' && WhatColor != "WHITE")
                {
                    Highlighter(MovesAvail);
                    IncLetter--;
                    FinalLetter = (char)IncLetter;
                    MovesAvail = FinalLetter + Number.ToString();
                    WhatColor = CheckColorOfPiece(MovesAvail);
                    if (WhatColor == "" || WhatColor == "BLACK") Highlighter(MovesAvail);
                }
                else if (WhatColor == "")
                {
                    Highlighter(MovesAvail);
                }
            }
        }


        void KingMove(char Letter, int Number, string Piece)
        {
            if (Piece == "BKING")
            {
                int IncLetter = (int)Letter;
                int Num = Number;
                IncLetter++;
                Num ++;
                char FinalLetter = (char)IncLetter;
                string Glow = FinalLetter + Num.ToString();
                string WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);

                Num = Number;
                Num++;
                Glow = Letter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter--;
                Num++;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);


                IncLetter = (int)Letter;
                Num = Number;
                IncLetter++;
                Num--;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);

                Num = Number;
                Num--;
                Glow = Letter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter--;
                Num--;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);


                IncLetter = (int)Letter;
                IncLetter--;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Number.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);

                IncLetter = (int)Letter;
                IncLetter++;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Number.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "BLACK") { }
                else if (WhatColor == "WHITE") Highlighter(Glow);
            }


            if (Piece == "WKING")
            {
                int IncLetter = (int)Letter;
                int Num = Number;
                IncLetter++;
                Num++;
                char FinalLetter = (char)IncLetter;
                string Glow = FinalLetter + Num.ToString();
                string WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);

                Num = Number;
                Num++;
                Glow = Letter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter--;
                Num++;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);


                IncLetter = (int)Letter;
                Num = Number;
                IncLetter++;
                Num--;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);

                Num = Number;
                Num--;
                Glow = Letter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);

                IncLetter = (int)Letter;
                Num = Number;
                IncLetter--;
                Num--;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Num.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);


                IncLetter = (int)Letter;
                IncLetter--;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Number.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);

                IncLetter = (int)Letter;
                IncLetter++;
                FinalLetter = (char)IncLetter;
                Glow = FinalLetter + Number.ToString();
                WhatColor = CheckColorOfPiece(Glow);
                if (WhatColor == "") Highlighter(Glow);
                else if (WhatColor == "WHITE") { }
                else if (WhatColor == "BLACK") Highlighter(Glow);
            }
        }

        void BaseHighlight(string Base)
        {
            if (Base == "A1") A1.BackColor = Color.Pink;
            if (Base == "A2") A2.BackColor = Color.Pink;
            if (Base == "A3") A3.BackColor = Color.Pink;
            if (Base == "A4") A4.BackColor = Color.Pink;
            if (Base == "A5") A5.BackColor = Color.Pink;
            if (Base == "A6") A6.BackColor = Color.Pink;
            if (Base == "A7") A7.BackColor = Color.Pink;
            if (Base == "A8") A8.BackColor = Color.Pink;

            if (Base == "B1") B1.BackColor = Color.Pink;
            if (Base == "B2") B2.BackColor = Color.Pink;
            if (Base == "B3") B3.BackColor = Color.Pink;
            if (Base == "B4") B4.BackColor = Color.Pink;
            if (Base == "B5") B5.BackColor = Color.Pink;
            if (Base == "B6") B6.BackColor = Color.Pink;
            if (Base == "B7") B7.BackColor = Color.Pink;
            if (Base == "B8") B8.BackColor = Color.Pink;

            if (Base == "C1") C1.BackColor = Color.Pink;
            if (Base == "C2") C2.BackColor = Color.Pink;
            if (Base == "C3") C3.BackColor = Color.Pink;
            if (Base == "C4") C4.BackColor = Color.Pink;
            if (Base == "C5") C5.BackColor = Color.Pink;
            if (Base == "C6") C6.BackColor = Color.Pink;
            if (Base == "C7") C7.BackColor = Color.Pink;
            if (Base == "C8") C8.BackColor = Color.Pink;

            if (Base == "D1") D1.BackColor = Color.Pink;
            if (Base == "D2") D2.BackColor = Color.Pink;
            if (Base == "D3") D3.BackColor = Color.Pink;
            if (Base == "D4") D4.BackColor = Color.Pink;
            if (Base == "D5") D5.BackColor = Color.Pink;
            if (Base == "D6") D6.BackColor = Color.Pink;
            if (Base == "D7") D7.BackColor = Color.Pink;
            if (Base == "D8") D8.BackColor = Color.Pink;

            if (Base == "E1") E1.BackColor = Color.Pink;
            if (Base == "E2") E2.BackColor = Color.Pink;
            if (Base == "E3") E3.BackColor = Color.Pink;
            if (Base == "E4") E4.BackColor = Color.Pink;
            if (Base == "E5") E5.BackColor = Color.Pink;
            if (Base == "E6") E6.BackColor = Color.Pink;
            if (Base == "E7") E7.BackColor = Color.Pink;
            if (Base == "E8") E8.BackColor = Color.Pink;

            if (Base == "F1") F1.BackColor = Color.Pink;
            if (Base == "F2") F2.BackColor = Color.Pink;
            if (Base == "F3") F3.BackColor = Color.Pink;
            if (Base == "F4") F4.BackColor = Color.Pink;
            if (Base == "F5") F5.BackColor = Color.Pink;
            if (Base == "F6") F6.BackColor = Color.Pink;
            if (Base == "F7") F7.BackColor = Color.Pink;
            if (Base == "F8") F8.BackColor = Color.Pink;

            if (Base == "G1") G1.BackColor = Color.Pink;
            if (Base == "G2") G2.BackColor = Color.Pink;
            if (Base == "G3") G3.BackColor = Color.Pink;
            if (Base == "G4") G4.BackColor = Color.Pink;
            if (Base == "G5") G5.BackColor = Color.Pink;
            if (Base == "G6") G6.BackColor = Color.Pink;
            if (Base == "G7") G7.BackColor = Color.Pink;
            if (Base == "G8") G8.BackColor = Color.Pink;

            if (Base == "H1") H1.BackColor = Color.Pink;
            if (Base == "H2") H2.BackColor = Color.Pink;
            if (Base == "H3") H3.BackColor = Color.Pink;
            if (Base == "H4") H4.BackColor = Color.Pink;
            if (Base == "H5") H5.BackColor = Color.Pink;
            if (Base == "H6") H6.BackColor = Color.Pink;
            if (Base == "H7") H7.BackColor = Color.Pink;
            if (Base == "H8") H8.BackColor = Color.Pink;
        }

        void CheckPiece(char Letter, int Number, string Piece)
        {
            if (Piece == "BPAWN" || Piece == "WPAWN") PawnMove(Letter, Number, Piece);
            if (Piece == "BKING" || Piece == "WKING") KingMove(Letter, Number, Piece);
            if (Piece == "BQUEEN" || Piece == "WQUEEN") QueenMove(Letter, Number, Piece);
            if (Piece == "BBISHOP" || Piece == "WBISHOP") BishopMove(Letter, Number, Piece);
            if (Piece == "BHORSE" || Piece == "WHORSE") HorseMove(Letter, Number, Piece);
            if (Piece == "BROOK" || Piece == "WROOK") RookMove(Letter, Number, Piece);

            if (moveover == true) Unselect.Visible = true;

            BlockToClear = Letter + Number.ToString();
            if (moveover == true && TforBlackAndFforWhite == true) { WhosMove.Text = BlackUserName + " is Holding"; WhosMove.ForeColor = Color.Black; }
            if (moveover == true && TforBlackAndFforWhite == false) { WhosMove.Text = WhiteUserName + " is Holding"; WhosMove.ForeColor = Color.White; }

            string HighlightBase = Letter + Number.ToString();
            BaseHighlight(HighlightBase);
        }


        void ClearRecentBlock()
        {
            if (BlockToClear == "A1") BlockA1 = "";
            if (BlockToClear == "A2") BlockA2 = "";
            if (BlockToClear == "A3") BlockA3 = "";
            if (BlockToClear == "A4") BlockA4 = "";
            if (BlockToClear == "A5") BlockA5 = "";
            if (BlockToClear == "A6") BlockA6 = "";
            if (BlockToClear == "A7") BlockA7 = "";
            if (BlockToClear == "A8") BlockA8 = "";

            if (BlockToClear == "B1") BlockB1 = "";
            if (BlockToClear == "B2") BlockB2 = "";
            if (BlockToClear == "B3") BlockB3 = "";
            if (BlockToClear == "B4") BlockB4 = "";
            if (BlockToClear == "B5") BlockB5 = "";
            if (BlockToClear == "B6") BlockB6 = "";
            if (BlockToClear == "B7") BlockB7 = "";
            if (BlockToClear == "B8") BlockB8 = "";

            if (BlockToClear == "C1") BlockC1 = "";
            if (BlockToClear == "C2") BlockC2 = "";
            if (BlockToClear == "C3") BlockC3 = "";
            if (BlockToClear == "C4") BlockC4 = "";
            if (BlockToClear == "C5") BlockC5 = "";
            if (BlockToClear == "C6") BlockC6 = "";
            if (BlockToClear == "C7") BlockC7 = "";
            if (BlockToClear == "C8") BlockC8 = "";

            if (BlockToClear == "D1") BlockD1 = "";
            if (BlockToClear == "D2") BlockD2 = "";
            if (BlockToClear == "D3") BlockD3 = "";
            if (BlockToClear == "D4") BlockD4 = "";
            if (BlockToClear == "D5") BlockD5 = "";
            if (BlockToClear == "D6") BlockD6 = "";
            if (BlockToClear == "D7") BlockD7 = "";
            if (BlockToClear == "D8") BlockD8 = "";

            if (BlockToClear == "E1") BlockE1 = "";
            if (BlockToClear == "E2") BlockE2 = "";
            if (BlockToClear == "E3") BlockE3 = "";
            if (BlockToClear == "E4") BlockE4 = "";
            if (BlockToClear == "E5") BlockE5 = "";
            if (BlockToClear == "E6") BlockE6 = "";
            if (BlockToClear == "E7") BlockE7 = "";
            if (BlockToClear == "E8") BlockE8 = "";

            if (BlockToClear == "F1") BlockF1 = "";
            if (BlockToClear == "F2") BlockF2 = "";
            if (BlockToClear == "F3") BlockF3 = "";
            if (BlockToClear == "F4") BlockF4 = "";
            if (BlockToClear == "F5") BlockF5 = "";
            if (BlockToClear == "F6") BlockF6 = "";
            if (BlockToClear == "F7") BlockF7 = "";
            if (BlockToClear == "F8") BlockF8 = "";

            if (BlockToClear == "G1") BlockG1 = "";
            if (BlockToClear == "G2") BlockG2 = "";
            if (BlockToClear == "G3") BlockG3 = "";
            if (BlockToClear == "G4") BlockG4 = "";
            if (BlockToClear == "G5") BlockG5 = "";
            if (BlockToClear == "G6") BlockG6 = "";
            if (BlockToClear == "G7") BlockG7 = "";
            if (BlockToClear == "G8") BlockG8 = "";

            if (BlockToClear == "H1") BlockH1 = "";
            if (BlockToClear == "H2") BlockH2 = "";
            if (BlockToClear == "H3") BlockH3 = "";
            if (BlockToClear == "H4") BlockH4 = "";
            if (BlockToClear == "H5") BlockH5 = "";
            if (BlockToClear == "H6") BlockH6 = "";
            if (BlockToClear == "H7") BlockH7 = "";
            if (BlockToClear == "H8") BlockH8 = "";

            BlockToClear = "";
            MoveSound.Play();
        }

        private void Unselect_Click(object sender, EventArgs e)
        {
            BlockToClear = "";
            PieceToMove = "";
            moveover = false;
            ResetBoard();
        }

        private void A1_Click(object sender, EventArgs e)
        {
            if (BlockA1 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockA1 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockA1)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockA1)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockA1 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'A'; //
                    int Number = 1; // 
                    PieceToMove = BlockA1; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockA1); //
                }
            }
        }

        private void B2_Click(object sender, EventArgs e)
        {
            if (BlockB2 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockB2 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockB2)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockB2)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockB2 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'B'; //
                    int Number = 2; // 
                    PieceToMove = BlockB2; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockB2); //
                }
            }
        }

        private void G2_Click(object sender, EventArgs e)
        {
            if (BlockG2 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockG2 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockG2)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockG2)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockG2 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'G'; //
                    int Number = 2; // 
                    PieceToMove = BlockG2; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockG2); //
                }
            }
        }

        private void F2_Click(object sender, EventArgs e)
        {
            if (BlockF2 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockF2 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockF2)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockF2)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockF2 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'F'; //
                    int Number = 2; // 
                    PieceToMove = BlockF2; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockF2); //
                }
            }
        }

        private void B1_Click(object sender, EventArgs e)
        {
            if (BlockB1 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockB1 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockB1)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockB1)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockB1 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'B'; //
                    int Number = 1; // 
                    PieceToMove = BlockB1; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockB1); //
                }
            }
        }

        private void C1_Click(object sender, EventArgs e)
        {
            if (BlockC1 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockC1 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockC1)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockC1)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockC1 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'C'; //
                    int Number = 1; // 
                    PieceToMove = BlockC1; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockC1); //
                }
            }
        }

        private void RookSelect_Click(object sender, EventArgs e)
        {
            SelectPiece.Visible = false;
            if (LocationOfPawn == "H1") BlockH1 = "BROOK";
            if (LocationOfPawn == "H2") BlockH2 = "BROOK";
            if (LocationOfPawn == "H3") BlockH3 = "BROOK";
            if (LocationOfPawn == "H4") BlockH4 = "BROOK";
            if (LocationOfPawn == "H5") BlockH5 = "BROOK";
            if (LocationOfPawn == "H6") BlockH6 = "BROOK";
            if (LocationOfPawn == "H7") BlockH7 = "BROOK";
            if (LocationOfPawn == "H8") BlockH8 = "BROOK";
            LocationOfPawn = "";
            ResetBoard();
        }

        private void G1_Click(object sender, EventArgs e)
        {
            if (BlockG1 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockG1 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockG1)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockG1)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockG1 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'G'; //
                    int Number = 1; // 
                    PieceToMove = BlockG1; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockG1); //
                }
            }
        }

        private void H1_Click(object sender, EventArgs e)
        {
            if (BlockH1 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockH1 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockH1)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockH1)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockH1 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'H'; //
                    int Number = 1; // 
                    PieceToMove = BlockH1; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockH1); //
                }
            }
        }

        private void E2_Click(object sender, EventArgs e)
        {
            if (BlockE2 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockE2 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockE2)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockE2)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockE2 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'E'; //
                    int Number = 2; // 
                    PieceToMove = BlockE2; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockE2); //
                }
            }
        }

        private void D2_Click(object sender, EventArgs e)
        {
            if (BlockD2 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockD2 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockD2)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockD2)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockD2 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'D'; //
                    int Number = 2; // 
                    PieceToMove = BlockD2; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockD2); //
                }
            }
        }

        private void D1_Click(object sender, EventArgs e)
        {
            if (BlockD1 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockD1 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockD1)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockD1)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockD1 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'D'; //
                    int Number = 1; // 
                    PieceToMove = BlockD1; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockD1); //
                }
            }
        }

        private void E1_Click(object sender, EventArgs e)
        {
            if (BlockE1 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockE1 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockE1)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockE1)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockE1 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'E'; //
                    int Number = 1; // 
                    PieceToMove = BlockE1; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockE1); //
                }
            }
        }

        private void F1_Click(object sender, EventArgs e)
        {
            if (BlockF1 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockF1 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockF1)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockF1)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockF1 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'F'; //
                    int Number = 1; // 
                    PieceToMove = BlockF1; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockF1); //
                }
            }
        }

        private void C2_Click(object sender, EventArgs e)
        {
            if (BlockC2 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockC2 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockC2)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockC2)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockC2 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'C'; //
                    int Number = 2; // 
                    PieceToMove = BlockC2; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockC2); //
                }
            }
        }

        private void H2_Click(object sender, EventArgs e)
        {
            if (BlockH2 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockH2 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockH2)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockH2)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockH2 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'H'; //
                    int Number = 2; // 
                    PieceToMove = BlockH2; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockH2); //
                }
            }
        }

        private void HorseSelect_Click(object sender, EventArgs e)
        {
            SelectPiece.Visible = false;
            if (LocationOfPawn == "H1") BlockH1 = "BHORSE";
            if (LocationOfPawn == "H2") BlockH2 = "BHORSE";
            if (LocationOfPawn == "H3") BlockH3 = "BHORSE";
            if (LocationOfPawn == "H4") BlockH4 = "BHORSE";
            if (LocationOfPawn == "H5") BlockH5 = "BHORSE";
            if (LocationOfPawn == "H6") BlockH6 = "BHORSE";
            if (LocationOfPawn == "H7") BlockH7 = "BHORSE";
            if (LocationOfPawn == "H8") BlockH8 = "BHORSE";
            LocationOfPawn = "";
            ResetBoard();
        }

        private void BishopSelect_Click(object sender, EventArgs e)
        {
            SelectPiece.Visible = false;
            if (LocationOfPawn == "H1") BlockH1 = "BBISHOP";
            if (LocationOfPawn == "H2") BlockH2 = "BBISHOP";
            if (LocationOfPawn == "H3") BlockH3 = "BBISHOP";
            if (LocationOfPawn == "H4") BlockH4 = "BBISHOP";
            if (LocationOfPawn == "H5") BlockH5 = "BBISHOP";
            if (LocationOfPawn == "H6") BlockH6 = "BBISHOP";
            if (LocationOfPawn == "H7") BlockH7 = "BBISHOP";
            if (LocationOfPawn == "H8") BlockH8 = "BBISHOP";
            LocationOfPawn = "";
            ResetBoard();
        }

        private void QueenSelect_Click(object sender, EventArgs e)
        {
            SelectPiece.Visible = false;
            if (LocationOfPawn == "H1") BlockH1 = "BQUEEN";
            if (LocationOfPawn == "H2") BlockH2 = "BQUEEN";
            if (LocationOfPawn == "H3") BlockH3 = "BQUEEN";
            if (LocationOfPawn == "H4") BlockH4 = "BQUEEN";
            if (LocationOfPawn == "H5") BlockH5 = "BQUEEN";
            if (LocationOfPawn == "H6") BlockH6 = "BQUEEN";
            if (LocationOfPawn == "H7") BlockH7 = "BQUEEN";
            if (LocationOfPawn == "H8") BlockH8 = "BQUEEN";
            LocationOfPawn = "";
            ResetBoard();
        }

        private void WRookSelect_Click(object sender, EventArgs e)
        {
            SelectPieceWhite.Visible = false;
            if (LocationOfPawn == "A1") BlockA1 = "WROOK";
            if (LocationOfPawn == "A2") BlockA2 = "WROOK";
            if (LocationOfPawn == "A3") BlockA3 = "WROOK";
            if (LocationOfPawn == "A4") BlockA4 = "WROOK";
            if (LocationOfPawn == "A5") BlockA5 = "WROOK";
            if (LocationOfPawn == "A6") BlockA6 = "WROOK";
            if (LocationOfPawn == "A7") BlockA7 = "WROOK";
            if (LocationOfPawn == "A8") BlockA8 = "WROOK";
            LocationOfPawn = "";
            ResetBoard();
        }

        private void WHorseSelect_Click(object sender, EventArgs e)
        {
            SelectPieceWhite.Visible = false;
            if (LocationOfPawn == "A1") BlockA1 = "WHORSE";
            if (LocationOfPawn == "A2") BlockA2 = "WHORSE";
            if (LocationOfPawn == "A3") BlockA3 = "WHORSE";
            if (LocationOfPawn == "A4") BlockA4 = "WHORSE";
            if (LocationOfPawn == "A5") BlockA5 = "WHORSE";
            if (LocationOfPawn == "A6") BlockA6 = "WHORSE";
            if (LocationOfPawn == "A7") BlockA7 = "WHORSE";
            if (LocationOfPawn == "A8") BlockA8 = "WHORSE";
            LocationOfPawn = "";
            ResetBoard();
        }

        private void WBishopSelect_Click(object sender, EventArgs e)
        {
            SelectPieceWhite.Visible = false;
            if (LocationOfPawn == "A1") BlockA1 = "WBISHOP";
            if (LocationOfPawn == "A2") BlockA2 = "WBISHOP";
            if (LocationOfPawn == "A3") BlockA3 = "WBISHOP";
            if (LocationOfPawn == "A4") BlockA4 = "WBISHOP";
            if (LocationOfPawn == "A5") BlockA5 = "WBISHOP";
            if (LocationOfPawn == "A6") BlockA6 = "WBISHOP";
            if (LocationOfPawn == "A7") BlockA7 = "WBISHOP";
            if (LocationOfPawn == "A8") BlockA8 = "WBISHOP";
            LocationOfPawn = "";
            ResetBoard();
        }

        private void WQueenSelect_Click(object sender, EventArgs e)
        {
            SelectPieceWhite.Visible = false;
            if (LocationOfPawn == "A1") BlockA1 = "WQUEEN";
            if (LocationOfPawn == "A2") BlockA2 = "WQUEEN";
            if (LocationOfPawn == "A3") BlockA3 = "WQUEEN";
            if (LocationOfPawn == "A4") BlockA4 = "WQUEEN";
            if (LocationOfPawn == "A5") BlockA5 = "WQUEEN";
            if (LocationOfPawn == "A6") BlockA6 = "WQUEEN";
            if (LocationOfPawn == "A7") BlockA7 = "WQUEEN";
            if (LocationOfPawn == "A8") BlockA8 = "WQUEEN";
            LocationOfPawn = "";
            ResetBoard();
        }

        private void A2_Click(object sender, EventArgs e)
        {
            if (BlockA2 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockA2 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockA2)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockA2)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockA2 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'A'; //
                    int Number = 2; // 
                    PieceToMove = BlockA2; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockA2); //
                }
            }
        }

        private void A3_Click(object sender, EventArgs e)
        {
            if (BlockA3 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockA3 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockA3)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockA3)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockA3 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'A'; //
                    int Number = 3; // 
                    PieceToMove = BlockA3; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockA3); //
                }
            }
        }

        private void A4_Click(object sender, EventArgs e)
        {
            if (BlockA4 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockA4 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockA4)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockA4)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockA4 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'A'; //
                    int Number = 4; // 
                    PieceToMove = BlockA4; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockA4); //
                }
            }
        }

        private void A5_Click(object sender, EventArgs e)
        {
            if (BlockA5 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockA5 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockA5)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockA5)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockA5 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'A'; //
                    int Number = 5; // 
                    PieceToMove = BlockA5; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockA5); //
                }
            }
        }

        private void A6_Click(object sender, EventArgs e)
        {
            if (BlockA6 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockA6 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockA6)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockA6)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockA6 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'A'; //
                    int Number = 6; // 
                    PieceToMove = BlockA6; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockA6); //
                }
            }
        }

        private void A7_Click(object sender, EventArgs e)
        {
            if (BlockA7 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockA7 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockA7)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockA7)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockA7 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'A'; //
                    int Number = 7; // 
                    PieceToMove = BlockA7; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockA7); //
                }
            }
        }

        private void A8_Click(object sender, EventArgs e)
        {
            if (BlockA8 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockA8 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockA8)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockA8)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockA8 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'A'; //
                    int Number = 8; // 
                    PieceToMove = BlockA8; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockA8); //
                }
            }
        }

        private void B3_Click(object sender, EventArgs e)
        {
            if (BlockB3 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockB3 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockB3)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockB3)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockB3 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'B'; //
                    int Number = 3; // 
                    PieceToMove = BlockB3; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockB3); //
                }
            }
        }

        private void B4_Click(object sender, EventArgs e)
        {
            if (BlockB4 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockB4 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockB4)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockB4)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockB4 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'B'; //
                    int Number = 4; // 
                    PieceToMove = BlockB4; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockB4); //
                }
            }
        }

        private void B5_Click(object sender, EventArgs e)
        {
            if (BlockB5 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockB5 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockB5)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockB5)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockB5 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'B'; //
                    int Number = 5; // 
                    PieceToMove = BlockB5; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockB5); //
                }
            }
        }

        private void B6_Click(object sender, EventArgs e)
        {
            if (BlockB6 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockB6 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockB6)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockB6)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockB6 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'B'; //
                    int Number = 6; // 
                    PieceToMove = BlockB6; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockB6); //
                }
            }
        }

        private void B7_Click(object sender, EventArgs e)
        {
            if (BlockB7 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockB7 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockB7)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockB7)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockB7 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'B'; //
                    int Number = 7; // 
                    PieceToMove = BlockB7; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockB7); //
                }
            }
        }

        private void B8_Click(object sender, EventArgs e)
        {
            if (BlockB8 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockB8 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockB8)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockB8)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockB8 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'B'; //
                    int Number = 8; // 
                    PieceToMove = BlockB8; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockB8); //
                }
            }
        }

        private void C3_Click(object sender, EventArgs e)
        {
            if (BlockC3 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockC3 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockC3)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockC3)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockC3 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'C'; //
                    int Number = 3; // 
                    PieceToMove = BlockC3; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockC3); //
                }
            }
        }

        private void C4_Click(object sender, EventArgs e)
        {
            if (BlockC4 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockC4 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockC4)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockC4)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockC4 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'C'; //
                    int Number = 4; // 
                    PieceToMove = BlockC4; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockC4); //
                }
            }
        }

        private void C5_Click(object sender, EventArgs e)
        {
            if (BlockC5 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockC5 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockC5)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockC5)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockC5 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'C'; //
                    int Number = 5; // 
                    PieceToMove = BlockC5; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockC5); //
                }
            }
        }

        private void C6_Click(object sender, EventArgs e)
        {
            if (BlockC6 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockC6 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockC6)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockC6)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockC6 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'C'; //
                    int Number = 6; // 
                    PieceToMove = BlockC6; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockC6); //
                }
            }
        }

        private void C7_Click(object sender, EventArgs e)
        {
            if (BlockC7 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockC7 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockC7)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockC7)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockC7 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'C'; //
                    int Number = 7; // 
                    PieceToMove = BlockC7; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockC7); //
                }
            }
        }

        private void C8_Click(object sender, EventArgs e)
        {
            if (BlockC8 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockC8 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockC8)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockC8)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockC8 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'C'; //
                    int Number = 8; // 
                    PieceToMove = BlockC8; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockC8); //
                }
            }
        }

        private void D3_Click(object sender, EventArgs e)
        {
            if (BlockD3 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockD3 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockD3)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockD3)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockD3 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'D'; //
                    int Number = 3; // 
                    PieceToMove = BlockD3; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockD3); //
                }
            }
        }

        private void D4_Click(object sender, EventArgs e)
        {
            if (BlockD4 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockD4 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockD4)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockD4)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockD4 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'D'; //
                    int Number = 4; // 
                    PieceToMove = BlockD4; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockD4); //
                }
            }
        }

        private void D5_Click(object sender, EventArgs e)
        {
            if (BlockD5 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockD5 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockD5)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockD5)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockD5 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'D'; //
                    int Number = 5; // 
                    PieceToMove = BlockD5; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockD5); //
                }
            }
        }

        private void D6_Click(object sender, EventArgs e)
        {
            if (BlockD6 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockD6 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockD6)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockD6)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockD6 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'D'; //
                    int Number = 6; // 
                    PieceToMove = BlockD6; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockD6); //
                }
            }
        }

        private void D7_Click(object sender, EventArgs e)
        {
            if (BlockD7 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockD7 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockD7)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockD7)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockD7 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'D'; //
                    int Number = 7; // 
                    PieceToMove = BlockD7; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockD7); //
                }
            }
        }

        private void D8_Click(object sender, EventArgs e)
        {
            if (BlockD8 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockD8 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockD8)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockD8)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockD8 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'D'; //
                    int Number = 8; // 
                    PieceToMove = BlockD8; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockD8); //
                }
            }
        }

        private void E3_Click(object sender, EventArgs e)
        {
            if (BlockE3 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockE3 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockE3)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockE3)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockE3 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'E'; //
                    int Number = 3; // 
                    PieceToMove = BlockE3; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockE3); //
                }
            }
        }

        private void E4_Click(object sender, EventArgs e)
        {
            if (BlockE4 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockE4 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockE4)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockE4)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockE4 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'E'; //
                    int Number = 4; // 
                    PieceToMove = BlockE4; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockE4); //
                }
            }
        }

        private void E5_Click(object sender, EventArgs e)
        {
            if (BlockE5 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockE5 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockE5)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockE5)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockE5 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'E'; //
                    int Number = 5; // 
                    PieceToMove = BlockE5; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockE5); //
                }
            }
        }

        private void E6_Click(object sender, EventArgs e)
        {
            if (BlockE6 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockE6 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockE6)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockE6)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockE6 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'E'; //
                    int Number = 6; // 
                    PieceToMove = BlockE6; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockE6); //
                }
            }
        }

        private void E7_Click(object sender, EventArgs e)
        {
            if (BlockE7 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockE7 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockE7)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockE7)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockE7 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'E'; //
                    int Number = 7; // 
                    PieceToMove = BlockE7; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockE7); //
                }
            }
        }

        private void E8_Click(object sender, EventArgs e)
        {
            if (BlockE8 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockE8 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockE8)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockE8)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockE8 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'E'; //
                    int Number = 8; // 
                    PieceToMove = BlockE8; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockE8); //
                }
            }
        }

        private void F3_Click(object sender, EventArgs e)
        {
            if (BlockF3 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockF3 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockF3)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockF3)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockF3 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'F'; //
                    int Number = 3; // 
                    PieceToMove = BlockF3; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockF3); //
                }
            }
        }

        private void F4_Click(object sender, EventArgs e)
        {
            if (BlockF4 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockF4 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockF4)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockF4)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockF4 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'F'; //
                    int Number = 4; // 
                    PieceToMove = BlockF4; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockF4); //
                }
            }
        }

        private void F5_Click(object sender, EventArgs e)
        {
            if (BlockF5 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockF5 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockF5)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockF5)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockF5 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'F'; //
                    int Number = 5; // 
                    PieceToMove = BlockF5; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockF5); //
                }
            }
        }

        private void F6_Click(object sender, EventArgs e)
        {
            if (BlockF6 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockF6 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockF6)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockF6)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockF6 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'F'; //
                    int Number = 6; // 
                    PieceToMove = BlockF6; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockF6); //
                }
            }
        }

        private void F7_Click(object sender, EventArgs e)
        {
            if (BlockF7 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockF7 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockF7)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockF7)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockF7 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'F'; //
                    int Number = 7; // 
                    PieceToMove = BlockF7; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockF7); //
                }
            }
        }

        private void F8_Click(object sender, EventArgs e)
        {
            if (BlockF8 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockF8 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockF8)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockF8)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockF8 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'F'; //
                    int Number = 8; // 
                    PieceToMove = BlockF8; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockF8); //
                }
            }
        }

        private void G3_Click(object sender, EventArgs e)
        {
            if (BlockG3 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockG3 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockG3)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockG3)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockG3 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'G'; //
                    int Number = 3; // 
                    PieceToMove = BlockG3; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockG3); //
                }
            }
        }

        private void G4_Click(object sender, EventArgs e)
        {
            if (BlockG4 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockG4 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockG4)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockG4)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockG4 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'G'; //
                    int Number = 4; // 
                    PieceToMove = BlockG4; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockG4); //
                }
            }
        }

        private void G5_Click(object sender, EventArgs e)
        {
            if (BlockG5 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockG5 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockG5)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockG5)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockG5 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'G'; //
                    int Number = 5; // 
                    PieceToMove = BlockG5; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockG5); //
                }
            }
        }

        private void G6_Click(object sender, EventArgs e)
        {
            if (BlockG6 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockG6 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockG6)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockG6)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockG6 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'G'; //
                    int Number = 6; // 
                    PieceToMove = BlockG6; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockG6); //
                }
            }
        }

        private void G7_Click(object sender, EventArgs e)
        {
            if (BlockG7 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockG7 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockG7)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockG7)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockG7 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'G'; //
                    int Number = 7; // 
                    PieceToMove = BlockG7; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockG7); //
                }
            }
        }

        private void G8_Click(object sender, EventArgs e)
        {
            if (BlockG8 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockG8 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockG8)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockG8)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockG8 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'G'; //
                    int Number = 8; // 
                    PieceToMove = BlockG8; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockG8); //
                }
            }
        }

        private void H3_Click(object sender, EventArgs e)
        {
            if (BlockH3 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockH3 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockH3)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockH3)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockH3 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'H'; //
                    int Number = 3; // 
                    PieceToMove = BlockH3; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockH3); //
                }
            }
        }

        private void H4_Click(object sender, EventArgs e)
        {
            if (BlockH4 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockH4 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockH4)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockH4)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockH4 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'H'; //
                    int Number = 4; // 
                    PieceToMove = BlockH4; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockH4); //
                }
            }
        }

        private void H5_Click(object sender, EventArgs e)
        {
            if (BlockH5 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockH5 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockH5)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockH5)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockH5 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'H'; //
                    int Number = 5; // 
                    PieceToMove = BlockH5; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockH5); //
                }
            }
        }

        private void H6_Click(object sender, EventArgs e)
        {
            if (BlockH6 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockH6 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockH6)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockH6)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockH6 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'H'; //
                    int Number = 6; // 
                    PieceToMove = BlockH6; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockH6); //
                }
            }
        }

        private void H7_Click(object sender, EventArgs e)
        {
            if (BlockH7 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockH7 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockH7)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockH7)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockH7 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'H'; //
                    int Number = 7; // 
                    PieceToMove = BlockH7; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockH7); //
                }
            }
        }

        private void H8_Click(object sender, EventArgs e)
        {
            if (BlockH8 == "") //
            {
                if (moveover)
                {
                    ClearRecentBlock();
                    BlockH8 = PieceToMove; //
                    PieceToMove = "";
                    moveover = false;
                    TforBlackAndFforWhite = !TforBlackAndFforWhite;
                    ResetBoard();
                }
            }
            else
            {
                string ColorOfThis = "";
                string ColorOfThat = "";

                string[] blackPieces = { "BPAWN", "BROOK", "BHORSE", "BBISHOP", "BKING", "BQUEEN" };
                string[] whitePieces = { "WPAWN", "WROOK", "WHORSE", "WBISHOP", "WKING", "WQUEEN" };

                if (blackPieces.Contains(BlockH8)) //
                    ColorOfThis = "BLACK";
                else if (whitePieces.Contains(BlockH8)) //
                    ColorOfThis = "WHITE";

                if (blackPieces.Contains(PieceToMove))
                    ColorOfThat = "BLACK";
                else if (whitePieces.Contains(PieceToMove))
                    ColorOfThat = "WHITE";


                if (ColorOfThis == ColorOfThat) { }

                else if (ColorOfThis != ColorOfThat && ColorOfThat != "")
                {
                    if (moveover)
                    {
                        ClearRecentBlock();
                        BlockH8 = PieceToMove; //
                        PieceToMove = "";
                        moveover = false;
                        TforBlackAndFforWhite = !TforBlackAndFforWhite;
                        ResetBoard();
                    }
                }
                else
                {
                    ResetBoard();
                    char Letter = 'H'; //
                    int Number = 8; // 
                    PieceToMove = BlockH8; //
                    moveover = true;
                    CheckPiece(Letter, Number, BlockH8); //
                }
            }
        }

        private void GotoMenu_Click(object sender, EventArgs e)
        {
            SoundPlayer BackgroundMusic = new SoundPlayer(Resources.ChessGameBackgroundMusic);
            BackgroundMusic.PlayLooping();
            this.Controls.Clear();
            WelcomeArea Menu = new WelcomeArea();
            this.Controls.Add(Menu);
        }
    }
}
