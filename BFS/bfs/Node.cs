using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bfs
{
    internal class Node
    {
        public GameObject gameObject;

        //좌표
        public int x;
        public int y;

        //지나갈수 있는지
        public bool canCross = true;

        //이전 노드 갯수
        public int prevCount = 0;

        //최단경로 인지
        public bool bfsRoute = false;

        //이전노드
        public Node[] Predecessor = new Node[4];

        public Node(int x, int y)
        { 
            this.x = x;
            this.y = y;
        }

        //이전노드 등록
        public void AddPredecessor(Node Predecessor)
        {
            this.Predecessor[prevCount] = Predecessor;
            prevCount = Predecessor.prevCount + 1;
        }
    }
}
