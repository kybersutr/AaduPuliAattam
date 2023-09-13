using System.Runtime.CompilerServices;

namespace AaduPuliAattam
{
    public partial class Form1 : Form
    {
        private List<Button> buttons = new();
        private Game game;
        public static Image tigerImage = Image.FromFile("C:\\Users\\kyber\\Desktop\\skola\\2023_LS\\C#2.0\\AaduPuliAattam\\AaduPuliAattam\\Assets\\tiger.png");
        public static Image lambImage = Image.FromFile("C:\\Users\\kyber\\Desktop\\skola\\2023_LS\\C#2.0\\AaduPuliAattam\\AaduPuliAattam\\Assets\\lamb.png");

        public Form1(Graph graph)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            this.Text = "Aadu Puli Aattam";

            Invalidate();

            const int LNUM = 6;
            const int TRESHOLD = 3;
            const int AIDEPTH = 3;

            //this.game = new HumanGame(graph, new HumanLamb(LNUM), new HumanTiger(TRESHOLD));


            //this.game = new AIGame(graph, new HumanLamb(LNUM), new AIPlayer(false, AIDEPTH, LNUM, TRESHOLD));
            this.game = new AIGame(graph, new HumanTiger(TRESHOLD), new AIPlayer(true, AIDEPTH, LNUM, TRESHOLD));
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void DrawBoard(Graphics gx, bool RedrawAll = false)
        {
            Graph g = this.game.board;

            if (g is null)
            {
                return;
            }

            int padding = this.ClientSize.Height / 7; // fixed space around the edges of the form
            int buttonSize = 25;

            int widthUnit = (this.ClientSize.Width - 2 * padding) / (g.Width);
            int heightUnit = (this.ClientSize.Height - 2 * padding) / (g.Height);

            foreach (List<Vertex> line in g.Edges)
            {
                Point start = new(padding + (line.First().Position.Item1 - g.MinX) * widthUnit,
                    padding + (line.First().Position.Item2 - g.MinY) * heightUnit);

                Point end = new(padding + (line.Last().Position.Item1 - g.MinX) * widthUnit,
                    padding + (line.Last().Position.Item2 - g.MinY) * heightUnit);

                gx.DrawLine(Pens.Black, start, end);

            }


            for (int i = 0; i < g.Vertices.Count; ++i)
            {
                Vertex v = g.Vertices[i];
                Button newButton;
                if (buttons.Count < i + 1)
                {
                    newButton = new Button();
                    newButton.Click += Button_Click;
                }
                else
                {
                    newButton = buttons[i];
                }

                if (v.Selected)
                {
                    newButton.Height = (int)(buttonSize * 1.5);
                    newButton.Width = (int)(buttonSize * 1.5);
                }
                else
                {
                    newButton.Height = buttonSize;
                    newButton.Width = buttonSize;
                }
                newButton.Location = new Point(padding + (v.Position.Item1 - g.MinX) * widthUnit - newButton.Width / 2,
                    padding + (v.Position.Item2 - g.MinY) * heightUnit - newButton.Height / 2);

                switch (v.occupiedBy)
                {
                    case Vertex.Occupancy.NOTHING:
                        {
                            newButton.BackColor = Color.Green;
                            break;
                        }
                    case Vertex.Occupancy.LAMB:
                        {
                            newButton.BackColor = Color.White;
                            break;
                        }
                    case Vertex.Occupancy.TIGER:
                        {
                            newButton.BackColor = Color.Orange;
                            break;
                        }
                }


                //newButton.Width = buttonSize;
                //newButton.Height = buttonSize;

                if (buttons.Count < i + 1)
                {
                    this.Controls.Add(newButton);
                    buttons.Add(newButton);
                }

                GameStatus status = game.GetStatus();
                textBox1.Text = "Lambs left to place: " + status.lambsToPlace;
                textBox2.Text = "Lambs captured: " + status.lambsCaptured;
                if (status.lambsTurn)
                {
                    textBox3.Text = "It's lamb's turn.";
                }
                else 
                {
                    textBox3.Text = "It's tiger's turn.";
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            DrawBoard(e.Graphics);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int i = buttons.IndexOf(clickedButton);

            game.HandleButtonClick(i);
            int status = game.CheckForWin();

            if (status == 0)
            {
                MessageBox.Show("Lambs win.");
                foreach (Button b in buttons)
                {
                    b.Enabled = false;
                }
                return;
            }
            else if (status == 1)
            {
                MessageBox.Show("Tigers win.");
                foreach (Button b in buttons)
                {
                    b.Enabled = false;
                }
                return;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}