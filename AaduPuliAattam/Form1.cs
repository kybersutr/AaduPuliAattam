using System.Runtime.CompilerServices;

namespace AaduPuliAattam
{
    public partial class Form1 : Form
    {
        private Graph graph = null;
        private List<Button> buttons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.DrawBoard(this.graph);
        }
        public void DrawBoard(Graph g)
        {
            if (g is null)
            {
                return;
            }

            this.graph = g;

            foreach (Button b in buttons)
            {
                this.Controls.Remove(b);
            }
            buttons.Clear();


            int padding = 50; // fixed space around the edges of the form
            int buttonSize = 20;

            int widthUnit = (this.ClientSize.Width - 2 * padding) / (g.Width);
            int heightUnit = (this.ClientSize.Height - 2 * padding) / (g.Height);

            foreach (Vertex v in g.Vertices)
            {
                Button newButton = new Button();
                newButton.Location = new Point(padding + (v.Position.Item1 - g.MinX) * widthUnit - buttonSize / 2,
                    padding + (v.Position.Item2 - g.MinY) * heightUnit - buttonSize / 2);
                newButton.Height = buttonSize;
                newButton.Width = buttonSize;
                newButton.BackColor = Color.Red;
                this.Controls.Add(newButton);
                buttons.Add(newButton);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}