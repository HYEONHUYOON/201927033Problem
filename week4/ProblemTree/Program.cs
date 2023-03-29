using System;

namespace Tree
{
    class Node
    {
        int nodeVal;
        Node[] childNode;
        int childNodeCount = 0;

        public Node(int nodeName)
        {
            this.nodeVal = nodeName;
        }

        public Node(int nodeName,int parentNodeVal)
        {
            this.nodeVal = nodeName;
        }

        public void MakeChildNode(int CnodeVal)
        {
            childNode[childNodeCount] = new Node(CnodeVal,this.nodeVal);
            childNodeCount++;
        }
    }
}