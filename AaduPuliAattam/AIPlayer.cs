using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    internal class AIPlayer : Tiger, Lamb
    {
        public bool isLamb;
        public int maxDepth;
        public int CapturedCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<int> OccupiedIndices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PlacedCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Move Play(Graph board, bool playAsLamb, int depth)
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

            if (depth >= this.maxDepth)
            {
                foreach (Move move in GenerateMoves(board))
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
                foreach (Move move in GenerateMoves(board)) 
                {
                    move.Apply(board, this);
                    move.Reverse(board, this);
                }
            }
        }
    }
}
