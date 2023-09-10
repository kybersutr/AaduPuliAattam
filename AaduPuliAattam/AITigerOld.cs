using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class AITigerOld : AIPlayerOld, Tiger
    {
        public List<int> OccupiedIndicesT { get; set; } 
        public int CapturedCount { get; set; }
        public int Treshold { get; set; }

        public AITigerOld(int treshold)
        {
            this.Treshold = treshold;
            this.CapturedCount = 0;
            this.OccupiedIndicesT = new List<int>();
        }

        public void Play(Graph board)
        {
            int bestScore = int.MinValue;
            foreach (Move move in GenerateMoves(board)) 
            {
                move.Apply(board, null);
                // Do MinMax
                move.Reverse(board, null);
            }
        }

        private List<Move> GenerateMoves(Graph board)
        {
            List<Move> moves = new();
            foreach (int tigerIndex in OccupiedIndicesT) 
            {
                foreach (Vertex neighbor in board.Vertices[tigerIndex].Neighbors) 
                {
                    if (neighbor.occupiedBy == Vertex.Occupancy.NOTHING) 
                    {
                        moves.Add(new Move(false, board.Vertices[tigerIndex], neighbor));
                    }
                }

                foreach (Vertex skipNeighbor in board.Vertices[tigerIndex].SkipOneNeighbors) 
                {
                    if (skipNeighbor.occupiedBy == Vertex.Occupancy.NOTHING &
                        board.Between[board.Vertices[tigerIndex]][skipNeighbor].occupiedBy == Vertex.Occupancy.LAMB) 
                    {
                        moves.Add(new Move(false, board.Vertices[tigerIndex], skipNeighbor,
                            board.Between[board.Vertices[tigerIndex]][skipNeighbor]));
                    }
                }
            }

            return moves;
        }
    }
}
