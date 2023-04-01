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
            Console.WriteLine("X 로 부터 도망가라!");
            Console.WriteLine();
            Console.WriteLine("PLAYER => O");
            Console.WriteLine("ENEMY => X");
            Console.WriteLine("MOUNTAIN => M");
            Console.WriteLine();
            Console.WriteLine("M => 이동 불가");
            Console.WriteLine("조작 방법 :  방향키");

            Console.WriteLine();
            Console.WriteLine("맵크기 => 10");
            Console.Write("시작 -  엔터");

            Console.ReadLine();

            Game game = new Game(10);

            while (true)
            {
                game.Render();
                Thread.Sleep(1000 / 60);
                Console.Clear();
            }
        }
    }
}
