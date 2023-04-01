using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace bfs
{
    internal class Enemy
    {
        public int x;
        public int y;

        public Node[,] node;

        public Enemy(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
