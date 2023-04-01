using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bfs
{
    internal class Node
    {
        public int index;

        public int x;
        public int y;

        public bool canCross = true;

        Node[] child;

        int childCount = 0;

        public Node(int index, int x, int y)
        {
            this.index = index;
            this.x = x;
            this.y = y;
        }

        public void makeChild(Node child)
        {
            this.child[childCount] = child;
            childCount++;
        }
    }
}
