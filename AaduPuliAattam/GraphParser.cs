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

                List<Vertex> vertices = new List<Vertex>();

                string[] tigers = reader.ReadLine().Split(' ');

                if (!(tigers.Length == 3)) 
                {
                    throw new Exception("There should be exactly 3 tigers.");
                }

                int[] tigerPositions = new int[tigers.Length];
                for (int t = 0; t < tigers.Length; ++t) 
                {
                    if (!int.TryParse(tigers[t], out int position))
                    {
                        throw new Exception("Tiger position should be an Integer.");
                    }
                    tigerPositions[t] = position;
                }

                for (int i = 0; i < n; ++i) 
                {
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

                    vertices.Add(new Vertex(x, y));
                }

                foreach (Vertex v in vertices) 
                {
                    v.occupiedBy = Vertex.Occupancy.NOTHING;
                }

                foreach (int p in tigerPositions) 
                {
                    vertices[p].occupiedBy = Vertex.Occupancy.TIGER;
                }

                List<List<Vertex>> edges = new List<List<Vertex>>();

                while (!reader.EndOfStream) 
                {
                    string edge = reader.ReadLine();
                    string[] splitEdge = edge.Split(' ');

                    List<Vertex> edgeVertices = new List<Vertex>();

                    foreach (string vertex in splitEdge) 
                    {
                        if (!int.TryParse(vertex, out int v)) 
                        {
                            throw new Exception("Vertex index should be an Integer.");
                        }

                        edgeVertices.Add(vertices[v]);
                    }

                    edges.Add(edgeVertices); 
                }

                return new Graph(vertices, edges);

            }
        }
    }
}
