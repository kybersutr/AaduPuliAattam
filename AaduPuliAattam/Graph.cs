﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaduPuliAattam
{
    public class Vertex
    {
        public (int, int) Position { get; private set; }
        public Vertex(int x, int y) 
        {
            this.Position = (x, y);
        }
    }
    public class Graph
    {
        public Vertex[] Vertices { get; private set; }
        public List<List<Vertex>> Edges { get; private set; }

        public int MinX { get; private set; }
        public int MaxX { get; private set; }
        public int MinY { get; private set; }

        public int MaxY { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Graph(Vertex[] vertices, List<List<Vertex>> edges) 
        {
            this.Vertices = vertices;
            this.Edges = edges;

            this.MinX = vertices.MinBy(v => v.Position.Item1).Position.Item1;
            this.MaxX = vertices.MaxBy(v => v.Position.Item1).Position.Item1;
            this.MinY = vertices.MinBy(v => v.Position.Item2).Position.Item2;
            this.MaxY = vertices.MaxBy(v => v.Position.Item2).Position.Item2;

            this.Width = this.MaxX - this.MinX;
            this.Height = this.MaxY - this.MinY;
        }
    }
}