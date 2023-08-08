using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace AaduPuliAattam
{
    internal class GraphParser
    {
        public Graph ParseGraph(string filename)
        {

            using (StreamReader reader = new StreamReader(filename))
            {
                if (!int.TryParse(reader.ReadLine(), out int n))
                {
                    throw new Exception("Number of vertices should be an Integer.");
                }

                Vertex[] vertices = new Vertex[n];

                for (int i = 0; i < n; ++i) 
                {
                    // TODO: if less lines than vertices
                    string position = reader.ReadLine();
                    string[] splitPosition = position.Split(' ');

                    if (!int.TryParse(splitPosition[0], out int x))
                    {
                        throw new Exception("Vertex coordinates should be an Integer.");
                    }

                    if (!int.TryParse(splitPosition[1], out int y)) 
                    {
                        throw new Exception("Vertex coordinates should be an Integer.");
                    }

                    vertices[i] = (new Vertex(x, y));
                }

                List<(Vertex, Vertex)> edges = new List<(Vertex, Vertex)>();

                while (!reader.EndOfStream) 
                {
                    string edge = reader.ReadLine();
                    string[] splitEdge = edge.Split(' ');

                    // TODO: vertex index out of range
                    if (!int.TryParse(splitEdge[0], out int from)) 
                    {
                        throw new Exception("Vertex number should be an Integer in range 0 to n.");
                    }
                    
                    if (!int.TryParse(splitEdge[1], out int to)) 
                    {
                        throw new Exception("Vertex number should be an Integer in range 0 to n.");
                    }

                    edges.Add((vertices[from], vertices[to])); 
                }

                return new Graph(vertices, edges);

            }
        }
    }
}
