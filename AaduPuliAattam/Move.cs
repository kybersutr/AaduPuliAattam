using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class Move
    {
        public bool isLamb;
        public Vertex from;
        public Vertex to;
        public Vertex captures;

        public Move(bool lamb, Vertex from, Vertex to, Vertex? captures = null)
        {
            this.isLamb = lamb;
            this.from = from; // null if lamb moves from the void
            this.to = to;
            this.captures = captures;
        }

        internal void Apply(Graph board, AIPlayer player)
        {
            if (isLamb) 
            {
                this.to.occupiedBy = Vertex.Occupancy.LAMB;
                if (this.from != null)
                {
                    this.from.occupiedBy = Vertex.Occupancy.NOTHING;
                }
                else 
                {
                    player.PlacedCount++;
                }
            }
            else 
            {
                this.from.occupiedBy = Vertex.Occupancy.NOTHING;
                player.OccupiedIndices.Remove(board.Vertices.IndexOf(from));
                this.to.occupiedBy = Vertex.Occupancy.TIGER;
                player.OccupiedIndices.Add(board.Vertices.IndexOf(to)); 
                if (captures != null) 
                {
                    this.captures.occupiedBy = Vertex.Occupancy.NOTHING;
                    player.CapturedCount++;
                }
            }
        }

        internal void Reverse(Graph board, AIPlayer player)
        {
            if (isLamb)
            {
                this.to.occupiedBy = Vertex.Occupancy.NOTHING;
                if (this.from != null)
                {
                    this.from.occupiedBy = Vertex.Occupancy.LAMB;
                }
                else 
                {
                    player.PlacedCount--;
                }
            }
            else 
            {
                this.from.occupiedBy = Vertex.Occupancy.TIGER;
                player.OccupiedIndices.Add(board.Vertices.IndexOf(from));
                this.to.occupiedBy = Vertex.Occupancy.NOTHING;
                player.OccupiedIndices.Remove(board.Vertices.IndexOf(to));
                if (captures != null) 
                {
                    this.captures.occupiedBy = Vertex.Occupancy.LAMB;
                    player.CapturedCount--;
                }
            }
        }
    }
}
