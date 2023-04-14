using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace bfs
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("E 로 부터 도망가라!");
            Console.WriteLine();
            Console.WriteLine("PLAYER => P");
            Console.WriteLine("ENEMY => E");
            Console.WriteLine("MOUNTAIN => M");
            Console.WriteLine();
            Console.WriteLine("M => 이동 불가");
            Console.WriteLine("조작 방법 :  방향키");

            Console.WriteLine();
            Console.WriteLine("맵크기 입력: ");
            int mapScale = int.Parse(Console.ReadLine());

            Game game = new Game(mapScale);

            while (true)
            {
                game.Render();
                Thread.Sleep(1000 / 60);
                Console.Clear();
            }
        }
    }
}
