using System;
namespace bfs
{
    public class GameObject
    {
        public int x;
        public int y;
        public string name;

        public GameObject()
        {
            this.x = 0;
            this.y = 0;
            this.name = "O";
        }

        public GameObject(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
    }
}

