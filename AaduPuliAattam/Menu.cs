using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AaduPuliAattam
{
    public partial class Menu : Form
    {

        GraphParser parser;
        string dir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
        // TODO: I hate this. Is there a normal way to get the base directory?
        string boardPath;

        int maxLambs;
        int recommendedLambs;
        int lambs;

        int recommendedTreshold;
        int treshold;

        int mode; // 0 = human, 1 = AI lamb, 2 = AI tiger

        public Menu()
        {
            InitializeComponent();
        }


        private void Menu_Load(object sender, EventArgs e)
        {
            parser = new GraphParser();
            boardPath = Path.Combine(dir, "GameBoards", "Intermediate.brd");

            maxLambs = 20;
            recommendedLambs = 15;
            lambs = recommendedLambs;

            recommendedTreshold = 5;
            treshold = recommendedTreshold;

            mode = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Graph board = parser.ParseGraph(boardPath);
            GameForm game = new GameForm(board, lambs, treshold, mode);
            game.ShowDialog();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.mode = 0;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.mode = 1;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this.mode = 2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            boardPath = Path.Combine(dir, "GameBoards", "Simple.brd");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            boardPath = Path.Combine(dir, "GameBoards", "Intermediate.brd");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            boardPath = Path.Combine(dir, "GameBoards", "Advanced.brd");
        }
    }
}
