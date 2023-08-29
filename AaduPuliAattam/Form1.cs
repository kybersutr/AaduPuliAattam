using System.Runtime.CompilerServices;

namespace AaduPuliAattam
{
    public partial class Form1 : Form
    {
        private List<Button> buttons = new List<Button>();
        private HumanGame game;
        public static Image tigerImage = Image.FromFile("C:\\Users\\kyber\\Desktop\\skola\\2023_LS\\C#2.0\\AaduPuliAattam\\AaduPuliAattam\\Assets\\tiger.png");
        public static Image lambImage = Image.FromFile("C:\\Users\\kyber\\Desktop\\skola\\2023_LS\\C#2.0\\AaduPuliAattam\\AaduPuliAattam\\Assets\\lamb.png");

        public Form1(Graph graph)
        {
            InitializeComponent();

            this.Text = "Aadu Puli Aattam";

            Invalidate();

            const int LNUM = 5;
            const int TNUM = 3;
            const int TRESHOLD = 3;

            this.game = new HumanGame(graph, new Lamb(LNUM), new Tiger());
            game.PlaceTigers(TNUM);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void DrawBoard(Graphics gx)
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
                Point start = new Point(padding + (line.First().Position.Item1 - g.MinX) * widthUnit,
                    padding + (line.First().Position.Item2 - g.MinY) * heightUnit);

                Point end = new Point(padding + (line.Last().Position.Item1 - g.MinX) * widthUnit,
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

                newButton.Location = new Point(padding + (v.Position.Item1 - g.MinX) * widthUnit - buttonSize / 2,
                    padding + (v.Position.Item2 - g.MinY) * heightUnit - buttonSize / 2);

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
                //newButton.Width = buttonSize;
                //newButton.Height = buttonSize;

                if (buttons.Count < i + 1)
                {
                    this.Controls.Add(newButton);
                    buttons.Add(newButton);
                }
            }

        }

        private void NewButton_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}