using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace bfs
{
    class Enemy : GameObject
    {
        public Enemy(int x, int y,string name) : base(x, y,name) { }
    }
}
