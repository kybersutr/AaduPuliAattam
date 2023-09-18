using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    public class Move
    {
        public bool isLamb;
        public Vertex? from;
        public Vertex to;
        public Vertex? captures;

        public Move(bool lamb, Vertex from, Vertex to, Vertex? captures = null)
        {
            this.isLamb = lamb;
            this.from = from; // null if lamb moves from the void
            this.to = to;
            this.captures = captures;
        }

        public void Apply(Graph board, AIPlayer player)
        {
            if (isLamb) 
            {
                ApplyLamb(board, player);    
            }
            else 
            {
                ApplyTiger(board, player);
            }
        }

        private void ApplyLamb(Graph board, AIPlayer player) 
        {
            this.to.OccupiedBy = Vertex.Occupancy.LAMB;
            player.OccupiedIndicesL.Add(board.Vertices.IndexOf(this.to));
            if (this.from != null)
            {
                this.from.OccupiedBy = Vertex.Occupancy.NOTHING;
                player.OccupiedIndicesL.Remove(board.Vertices.IndexOf(this.from));
            }
            else 
            {
                player.PlacedCount++;
            }
        }

        private void ApplyTiger(Graph board, AIPlayer player) 
        {
            this.from.OccupiedBy = Vertex.Occupancy.NOTHING; // from cannot be null in this case
            player.OccupiedIndicesT.Remove(board.Vertices.IndexOf(from));
            this.to.OccupiedBy = Vertex.Occupancy.TIGER;
            player.OccupiedIndicesT.Add(board.Vertices.IndexOf(to)); 
            if (captures != null) 
            {
                this.captures.OccupiedBy = Vertex.Occupancy.NOTHING;
                player.OccupiedIndicesL.Remove(board.Vertices.IndexOf(this.captures));
                player.CapturedCount++;
            }
 
        }

        public void Reverse(Graph board, AIPlayer player)
        {
            if (isLamb)
            {
                ReverseLamb(board, player);    
            }
            else 
            {
                ReverseTiger(board, player); 
            }
        }

        private void ReverseLamb(Graph board, AIPlayer player) 
        {
            this.to.OccupiedBy = Vertex.Occupancy.NOTHING;
            player.OccupiedIndicesL.Remove(board.Vertices.IndexOf(this.to));
            if (this.from != null)
            {
                this.from.OccupiedBy = Vertex.Occupancy.LAMB;
                player.OccupiedIndicesL.Add(board.Vertices.IndexOf(this.from));
            }
            else 
            {
                player.PlacedCount--;
            }
        }

        private void ReverseTiger(Graph board, AIPlayer player) 
        {
            this.from.OccupiedBy = Vertex.Occupancy.TIGER; // from won't be null in this case
            player.OccupiedIndicesT.Add(board.Vertices.IndexOf(from));
            this.to.OccupiedBy = Vertex.Occupancy.NOTHING;
            player.OccupiedIndicesT.Remove(board.Vertices.IndexOf(to));
            if (captures != null) 
            {
                this.captures.OccupiedBy = Vertex.Occupancy.LAMB;
                player.OccupiedIndicesL.Add(board.Vertices.IndexOf(this.captures));
                player.CapturedCount--;
            }
        }
    }
}
