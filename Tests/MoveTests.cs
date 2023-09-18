using AaduPuliAattam;

namespace Tests
{
    [TestClass]
    public class MoveTests 
    {
        public static Graph CreateBoard() 
        {
            List<Vertex> vertices = new List<Vertex> { new Vertex(0,0), new Vertex(0, 1), new Vertex(1,1)};
            Graph board = new Graph(vertices, new List<List<Vertex>>());
            return board;
        }

        [TestMethod]
        public void MoveTigerOneSpace()
        {
            Graph board = CreateBoard();
            board.Vertices[0].OccupiedBy = Vertex.Occupancy.TIGER;
            board.Vertices[1].OccupiedBy = Vertex.Occupancy.NOTHING;
            board.Vertices[2].OccupiedBy = Vertex.Occupancy.NOTHING;

            AIPlayer player = new AIPlayer(true, 4, 5, 3);
            player.OccupiedIndicesT = new List<int> { 0 };
            player.OccupiedIndicesL = new List<int> { };
            player.CapturedCount = 0;
            player.PlacedCount = 0;

            Move move = new Move(false, board.Vertices[0], board.Vertices[1]);
            move.Apply(board, player);

            Assert.AreEqual(Vertex.Occupancy.NOTHING, board.Vertices[0].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.TIGER, board.Vertices[1].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.NOTHING, board.Vertices[2].OccupiedBy);

            Assert.IsTrue(player.OccupiedIndicesT.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesT.Contains(1));

            Assert.IsTrue(player.OccupiedIndicesL.Count == 0);

            Assert.AreEqual(0, player.CapturedCount);
            Assert.AreEqual(0, player.PlacedCount);
        }

        [TestMethod]
        public void ReverseTigerOneSpace()
        {
            Graph board = CreateBoard();
            board.Vertices[0].OccupiedBy = Vertex.Occupancy.NOTHING;
            board.Vertices[1].OccupiedBy = Vertex.Occupancy.TIGER;
            board.Vertices[2].OccupiedBy = Vertex.Occupancy.NOTHING;

            AIPlayer player = new AIPlayer(true, 4, 5, 3);
            player.OccupiedIndicesT = new List<int> { 1 };
            player.OccupiedIndicesL = new List<int> { };
            player.CapturedCount = 0;
            player.PlacedCount = 0;

            Move move = new Move(false, board.Vertices[0], board.Vertices[1]);
            move.Reverse(board, player);

            Assert.AreEqual(Vertex.Occupancy.TIGER, board.Vertices[0].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.NOTHING, board.Vertices[1].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.NOTHING, board.Vertices[2].OccupiedBy);

            Assert.IsTrue(player.OccupiedIndicesT.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesT.Contains(0));

            Assert.IsTrue(player.OccupiedIndicesL.Count == 0);

            Assert.AreEqual(0, player.CapturedCount);
            Assert.AreEqual(0, player.PlacedCount);
        }

        [TestMethod]
        public void MoveTigerCapture() 
        {
            Graph board = CreateBoard();
            board.Vertices[0].OccupiedBy = Vertex.Occupancy.TIGER;
            board.Vertices[1].OccupiedBy = Vertex.Occupancy.LAMB;
            board.Vertices[2].OccupiedBy = Vertex.Occupancy.NOTHING;

            AIPlayer player = new AIPlayer(true, 4, 5, 3);
            player.OccupiedIndicesT = new List<int> { 0 };
            player.OccupiedIndicesL = new List<int> { 1 };
            player.CapturedCount = 0;
            player.PlacedCount = 1;

            Move move = new Move(false, board.Vertices[0], board.Vertices[2], board.Vertices[1]);
            move.Apply(board, player);

            Assert.AreEqual(Vertex.Occupancy.NOTHING, board.Vertices[0].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.NOTHING, board.Vertices[1].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.TIGER, board.Vertices[2].OccupiedBy);

            Assert.IsTrue(player.OccupiedIndicesT.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesT.Contains(2));

            Assert.IsTrue(player.OccupiedIndicesL.Count == 0);

            Assert.AreEqual(1, player.CapturedCount);
            Assert.AreEqual(1, player.PlacedCount);
        }
        
        [TestMethod]
        public void ReverseTigerCapture() 
        {
            Graph board = CreateBoard();
            board.Vertices[0].OccupiedBy = Vertex.Occupancy.NOTHING;
            board.Vertices[1].OccupiedBy = Vertex.Occupancy.NOTHING;
            board.Vertices[2].OccupiedBy = Vertex.Occupancy.TIGER;

            AIPlayer player = new AIPlayer(true, 4, 5, 3);
            player.OccupiedIndicesT = new List<int> { 2 };
            player.OccupiedIndicesL = new List<int> { };
            player.CapturedCount = 1;
            player.PlacedCount = 1;

            Move move = new Move(false, board.Vertices[0], board.Vertices[2], board.Vertices[1]);
            move.Reverse(board, player);

            Assert.AreEqual(Vertex.Occupancy.TIGER, board.Vertices[0].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.LAMB, board.Vertices[1].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.NOTHING, board.Vertices[2].OccupiedBy);

            Assert.IsTrue(player.OccupiedIndicesT.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesT.Contains(0));

            Assert.IsTrue(player.OccupiedIndicesL.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesL.Contains(1));

            Assert.AreEqual(0, player.CapturedCount);
            Assert.AreEqual(1, player.PlacedCount);
        }

        [TestMethod]
        public void MoveLambNew() 
        {
            Graph board = CreateBoard();
            board.Vertices[0].OccupiedBy = Vertex.Occupancy.LAMB;
            board.Vertices[1].OccupiedBy = Vertex.Occupancy.NOTHING;
            board.Vertices[2].OccupiedBy = Vertex.Occupancy.TIGER;

            AIPlayer player = new AIPlayer(true, 4, 5, 3);
            player.OccupiedIndicesT = new List<int> { 2 };
            player.OccupiedIndicesL = new List<int> { 0 };
            player.CapturedCount = 1;
            player.PlacedCount = 1;

            Move move = new Move(true, null, board.Vertices[1]);
            move.Apply(board, player);

            Assert.AreEqual(Vertex.Occupancy.LAMB, board.Vertices[0].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.LAMB, board.Vertices[1].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.TIGER, board.Vertices[2].OccupiedBy);

            Assert.IsTrue(player.OccupiedIndicesT.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesT.Contains(2));

            Assert.IsTrue(player.OccupiedIndicesL.Count == 2);
            Assert.IsTrue(player.OccupiedIndicesL.Contains(0));
            Assert.IsTrue(player.OccupiedIndicesL.Contains(1));

            Assert.AreEqual(1, player.CapturedCount);
            Assert.AreEqual(2, player.PlacedCount);
        }
        
        [TestMethod]
        public void ReverseLambNew() 
        {
            Graph board = CreateBoard();
            board.Vertices[0].OccupiedBy = Vertex.Occupancy.LAMB;
            board.Vertices[1].OccupiedBy = Vertex.Occupancy.LAMB;
            board.Vertices[2].OccupiedBy = Vertex.Occupancy.TIGER;

            AIPlayer player = new AIPlayer(true, 4, 5, 3);
            player.OccupiedIndicesT = new List<int> { 2 };
            player.OccupiedIndicesL = new List<int> { 0, 1 };
            player.CapturedCount = 1;
            player.PlacedCount = 2;

            Move move = new Move(true, null, board.Vertices[1]);
            move.Reverse(board, player);

            Assert.AreEqual(Vertex.Occupancy.LAMB, board.Vertices[0].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.NOTHING, board.Vertices[1].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.TIGER, board.Vertices[2].OccupiedBy);

            Assert.IsTrue(player.OccupiedIndicesT.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesT.Contains(2));

            Assert.IsTrue(player.OccupiedIndicesL.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesL.Contains(0));

            Assert.AreEqual(1, player.CapturedCount);
            Assert.AreEqual(1, player.PlacedCount);
        }

        [TestMethod]
        public void MoveLambOld() 
        {
            Graph board = CreateBoard();
            board.Vertices[0].OccupiedBy = Vertex.Occupancy.LAMB;
            board.Vertices[1].OccupiedBy = Vertex.Occupancy.NOTHING;
            board.Vertices[2].OccupiedBy = Vertex.Occupancy.TIGER;

            AIPlayer player = new AIPlayer(true, 4, 5, 3);
            player.OccupiedIndicesT = new List<int> { 2 };
            player.OccupiedIndicesL = new List<int> { 0 };
            player.CapturedCount = 1;
            player.PlacedCount = 1;

            Move move = new Move(true, board.Vertices[0], board.Vertices[1]);
            move.Apply(board, player);

            Assert.AreEqual(Vertex.Occupancy.NOTHING, board.Vertices[0].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.LAMB, board.Vertices[1].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.TIGER, board.Vertices[2].OccupiedBy);

            Assert.IsTrue(player.OccupiedIndicesT.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesT.Contains(2));

            Assert.IsTrue(player.OccupiedIndicesL.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesL.Contains(1));

            Assert.AreEqual(1, player.CapturedCount);
            Assert.AreEqual(1, player.PlacedCount);
        }
        
        [TestMethod]
        public void ReverseLambOld() 
        {   
            Graph board = CreateBoard();
            board.Vertices[0].OccupiedBy = Vertex.Occupancy.NOTHING;
            board.Vertices[1].OccupiedBy = Vertex.Occupancy.LAMB;
            board.Vertices[2].OccupiedBy = Vertex.Occupancy.TIGER;

            AIPlayer player = new AIPlayer(true, 4, 5, 3);
            player.OccupiedIndicesT = new List<int> { 2 };
            player.OccupiedIndicesL = new List<int> { 1 };
            player.CapturedCount = 1;
            player.PlacedCount = 1;

            Move move = new Move(true, board.Vertices[0], board.Vertices[1]);
            move.Reverse(board, player);

            Assert.AreEqual(Vertex.Occupancy.LAMB, board.Vertices[0].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.NOTHING, board.Vertices[1].OccupiedBy);
            Assert.AreEqual(Vertex.Occupancy.TIGER, board.Vertices[2].OccupiedBy);

            Assert.IsTrue(player.OccupiedIndicesT.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesT.Contains(2));

            Assert.IsTrue(player.OccupiedIndicesL.Count == 1);
            Assert.IsTrue(player.OccupiedIndicesL.Contains(0));

            Assert.AreEqual(1, player.CapturedCount);
            Assert.AreEqual(1, player.PlacedCount);

        }
    }
}