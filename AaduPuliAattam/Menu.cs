namespace AaduPuliAattam
{
    public partial class Menu : Form
    {

        public static readonly string dir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
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
            boardPath = Path.Combine(dir, "GameBoards", "Intermediate.brd");

            // Recommended values from the rules
            maxLambs = 20;
            recommendedLambs = 15;
            lambs = recommendedLambs;

            recommendedTreshold = 5;
            treshold = recommendedTreshold;

            mode = 0;

            numericUpDown1.Maximum = maxLambs;
            numericUpDown1.Value = recommendedLambs;

            numericUpDown2.Value = recommendedTreshold;
            numericUpDown2.Maximum = lambs; // Treshold for tiger win cannot be greater than the total number of lambs
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Graph board = GraphParser.ParseGraph(boardPath);
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
            maxLambs = 7;
            recommendedLambs = 5;
            lambs = recommendedLambs;

            recommendedTreshold = 2;
            treshold = recommendedTreshold;

            numericUpDown1.Maximum = maxLambs;
            numericUpDown1.Value = recommendedLambs;

            numericUpDown2.Value = recommendedTreshold;
            numericUpDown2.Maximum = lambs;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            boardPath = Path.Combine(dir, "GameBoards", "Intermediate.brd");
            maxLambs = 20;
            recommendedLambs = 15;
            lambs = recommendedLambs;

            recommendedTreshold = 5;
            treshold = recommendedTreshold;

            numericUpDown1.Maximum = maxLambs;
            numericUpDown1.Value = recommendedLambs;

            numericUpDown2.Value = recommendedTreshold;
            numericUpDown2.Maximum = lambs;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            boardPath = Path.Combine(dir, "GameBoards", "Advanced.brd");
            maxLambs = 26;
            recommendedLambs = 21;
            lambs = recommendedLambs;

            recommendedTreshold = 9;
            treshold = recommendedTreshold;

            numericUpDown1.Maximum = maxLambs;
            numericUpDown1.Value = recommendedLambs;

            numericUpDown2.Value = recommendedTreshold;
            numericUpDown2.Maximum = lambs;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            lambs = (int)numericUpDown1.Value;
            numericUpDown2.Maximum = lambs;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            treshold = (int)numericUpDown2.Value;
        }
    }
}
