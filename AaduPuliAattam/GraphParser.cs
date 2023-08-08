using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                Vertex[] vertcies = null;
                (Vertex, Vertex)[] edges = null;
                return new Graph(vertcies, edges);

            }
        }
    }
}
