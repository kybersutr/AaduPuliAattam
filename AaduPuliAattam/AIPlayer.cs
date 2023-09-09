using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class AIPlayer : Tiger, Lamb
    {
        public bool isLamb;
        public int maxDepth;
        public int CapturedCount { get; set; }
        public List<int> OccupiedIndicesT { get; set; }

        public List<int> OccupiedIndicesL { get; set; }
        public int PlacedCount { get; set; }

        public int TotalCount { get; set; }

        private Tuple<int, Move> MinMax(Graph board, bool playAsLamb, int depth) 
        {
            int bestScore;
            if (playAsLamb)
            {
                bestScore = int.MinValue;
            }
            else
            {
                bestScore = int.MaxValue;
            }

            Move bestMove = null;

            if (depth <= 0)
            {
                foreach (Move move in GenerateMoves(board, playAsLamb))
                {
                    move.Apply(board, this);
                    int score = GetScore(board);
                    move.Reverse(board, this);

                    if (playAsLamb)
                    {
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = move;
                        }
                    }
                    else
                    {
                        if (score < bestScore)
                        {
                            bestScore = score;
                            bestMove = move;
                        }
                    }
                }
            }
            else 
            {
                foreach (Move move in GenerateMoves(board, playAsLamb)) 
                {
                    move.Apply(board, this);
                    Tuple<int, Move> bestForThisMove = MinMax(board, !playAsLamb, depth - 1);
                    int score = bestForThisMove.Item1;
                    move.Reverse(board, this);

                    if (playAsLamb)
                    {
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = move;
                        }
                    }
                    else
                    {
                        if (score < bestScore)
                        {
                            bestScore = score;
                            bestMove = move;
                        }
                    }

                }
            }

            return new Tuple<int, Move>(bestScore, bestMove);
        }
        public void Play(Graph board)
        {
            Tuple<int, Move> best = MinMax(board, isLamb, maxDepth);
            Move bestMove = best.Item2;
            bestMove.Apply(board, this);
        }

        private List<Move> GenerateMoves(Graph board, bool playAsLamb) 
        {
            List<Move> moves = new();
            if (playAsLamb)
            {
                if (this.PlacedCount < this.TotalCount)
                {
                    foreach (Vertex v in board.Vertices) 
                    {
                        if (v.occupiedBy == Vertex.Occupancy.NOTHING) 
                        {
                            moves.Add(new Move(true, null, v));
                        }
                    }
                }
                else 
                {
                    foreach (int lambIndex in OccupiedIndicesL) 
                    {
                        foreach (Vertex neighbor in board.Vertices[lambIndex].Neighbors) 
                        {
                            if (neighbor.occupiedBy == Vertex.Occupancy.NOTHING) 
                            {
                                moves.Add(new Move(true, board.Vertices[lambIndex], neighbor));
                            }
                        }
                    }
                }
            }
            else 
            {
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
            }
            return moves;
        }
    }
}
