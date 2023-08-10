using System.Runtime.CompilerServices;

namespace AaduPuliAattam
{
    public partial class Form1 : Form
    {
        public Graph Graph { get; set; }
        private List<Button> buttons = new List<Button>();

        public Form1()
        {
            InitializeComponent();

            this.Text = "Aadu Puli Aattam";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        public void DrawBoard(Graphics gx)
        {
            Graph g = this.Graph;

            if (g is null)
            {
                return;
            }

            int padding = this.ClientSize.Height / 7; // fixed space around the edges of the form
            int buttonSize = 20;

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


            for (int i = 0; i < g.Vertices.Length; ++i)
            {
                Vertex v = g.Vertices[i];
                Button newButton;
                if (buttons.Count < i + 1)
                {
                    newButton = new Button();
                }
                else
                {
                    newButton = buttons[i];
                }

                newButton.Location = new Point(padding + (v.Position.Item1 - g.MinX) * widthUnit - buttonSize / 2,
                    padding + (v.Position.Item2 - g.MinY) * heightUnit - buttonSize / 2);
                newButton.Height = buttonSize;
                newButton.Width = buttonSize;
                newButton.BackColor = Color.Red;

                if (buttons.Count < i + 1)
                {
                    this.Controls.Add(newButton);
                    buttons.Add(newButton);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}