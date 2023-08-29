using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    public class Vertex
    {
        public (int, int) Position { get; private set; }
        public enum Occupancy { NOTHING, TIGER, LAMB };
        public Occupancy occupiedBy = Occupancy.NOTHING;
        public List<Vertex> Neighbors { get; internal set; }
        public List<Vertex> SkipOneNeighbors { get; internal set; }

        public bool Selected { get; set; }

        public Vertex(int x, int y) 
        {
            this.Position = (x, y);
            this.Selected = false;
        }
    }
    public class Graph
    {
        public List<Vertex> Vertices { get; private set; }
        public List<List<Vertex>> Edges { get; private set; }

        public Dictionary<Vertex, Dictionary<Vertex, Vertex>> Between { get; private set; }

        public int MinX { get; private set; }
        public int MaxX { get; private set; }
        public int MinY { get; private set; }

        public int MaxY { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Graph(List<Vertex> vertices, List<List<Vertex>> edges) 
        {
            this.Vertices = vertices;
            this.Edges = edges;

            this.MinX = vertices.MinBy(v => v.Position.Item1).Position.Item1;
            this.MaxX = vertices.MaxBy(v => v.Position.Item1).Position.Item1;
            this.MinY = vertices.MinBy(v => v.Position.Item2).Position.Item2;
            this.MaxY = vertices.MaxBy(v => v.Position.Item2).Position.Item2;

            this.Width = this.MaxX - this.MinX;
            this.Height = this.MaxY - this.MinY;

            this.Between = new Dictionary<Vertex, Dictionary<Vertex, Vertex>>();

            foreach (Vertex v in vertices) 
            {
                Between[v] = new Dictionary<Vertex, Vertex>();
            }

            GetNeighbors();
        }

        private void GetNeighbors() 
        {
            foreach (Vertex v in this.Vertices) 
            {
                v.Neighbors = new List<Vertex>();
                v.SkipOneNeighbors = new List<Vertex>();
            }

            foreach (List<Vertex> e in this.Edges) 
            {
                for (int i = 0; i < e.Count; ++i) 
                {
                    if (i > 0) 
                    {
                        e[i].Neighbors.Add(e[i - 1]);
                    }
                    if (i > 1) 
                    {
                        e[i].SkipOneNeighbors.Add(e[i - 2]);
                        Between[e[i]][e[i - 2]] = e[i - 1];
                    }
                    if (i < e.Count - 1) 
                    {
                        e[i].Neighbors.Add(e[i + 1]);
                    }
                    if (i < e.Count - 2) 
                    {
                        e[i].SkipOneNeighbors.Add(e[i + 2]);
                        Between[e[i]][e[i + 2]] = e[i + 1];
                    }
                } 
            }
        }
    }
}
