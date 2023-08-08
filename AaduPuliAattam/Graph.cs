using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class Vertex
    {
        private (int, int) Position { get; set; }
        public Vertex(int x, int y) 
        {
            this.Position = (x, y);
        }
    }
    internal class Graph
    {
        private Vertex[] vertices;
        private List<(Vertex, Vertex)> edges;

        public Graph(Vertex[] vertices, List<(Vertex, Vertex)> edges) 
        {
            this.vertices = vertices;
            this.edges = edges;
        }
    }
}
