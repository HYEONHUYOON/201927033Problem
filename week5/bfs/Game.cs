using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace bfs
{
    internal class Game
    {
        public int x;
        public int y;
        int mapScale;

        public Node[,] node;

        public Player player = new Player(5, 5);
        Enemy enemy = new Enemy(1, 1);

        Obstacle[] o = new Obstacle[6];
        Obstacle obstacles = new Obstacle(1, 4);
        Obstacle obstacles2 = new Obstacle(3, 4);
        Obstacle obstacles3 = new Obstacle(4, 1);
        Obstacle obstacles4 = new Obstacle(7, 5);
        Obstacle obstacles5 = new Obstacle(9, 3);
        Obstacle obstacles6 = new Obstacle(6, 8);

        public Game(int mapScale)
        {
            int nodeIndex = 0;

            this.mapScale = mapScale;
            node = new Node[mapScale, mapScale];

            for (int y = 0; y < mapScale; y++)
            {
                for (int x = 0; x < mapScale; x++)
                {
                    node[x, y] = new Node(nodeIndex, x, y);

                    nodeIndex++;
                }
            }
            o[0] = new Obstacle(1, 4);
            o[1] = new Obstacle(4, 1);
            o[2] = new Obstacle(3, 4);
            o[3] = obstacles4;
            o[4] = obstacles5;
            o[5] = obstacles6;

            for (int i = 0; i < o.Length; i++)
            {
                node[o[i].x - 1, o[i].y - 1].canCross = false;
            }
        }

        public void Render()
        {
            if(player.x == enemy.x && player.y == enemy.y)
            {
                Console.WriteLine("GAME OVER");
            }
            else
            {
                DrawRectangularBoard();
                Input();
            }
        }

        public void DrawRectangularBoard()
        {
            int IndexNom = 1;
            // 말판을 그림
            for (int y = 0; y < mapScale; y++)
            {
                for (int x = 0; x < mapScale; x++)
                {
                    if (player.x - 1 == x && player.y - 1 == y)
                    {
                        Console.Write("O   ");
                    }

                    else if (enemy.x - 1 == x && enemy.y - 1 == y)
                    {
                        Console.Write("X   ");
                    }


                    else if (o[0].x - 1 == x && o[0].y - 1 == y)
                    {
                        Console.Write("M   ");
                    }

                    else if (o[1].x - 1 == x && o[1].y - 1 == y)
                    {
                        Console.Write("M  ");
                    }

                    else if (o[2].x - 1 == x && o[2].y - 1 == y)
                    {
                        Console.Write("M   ");
                    }
                    else if (o[3].x - 1 == x && o[3].y - 1 == y)
                    {
                        Console.Write("M   ");
                    }
                    else if (o[4].x - 1 == x && o[4].y - 1 == y)
                    {
                        Console.Write("M   ");
                    }
                    else if (o[5].x - 1 == x && o[5].y - 1 == y)
                    {
                        Console.Write("M   ");
                    }
                    else
                        Console.Write($"*   ");

                    IndexNom++;

                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        //캐릭터 이동
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (player.y == 1)
                    {
                        player.y = 1;
                    }
                    else if (node[player.x - 1, player.y - 2].canCross == false)
                    {
                        return;
                    }
                    else
                        player.y--;

                    Chase();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (player.y == mapScale)
                    {
                        player.y = mapScale;
                    }
                    else if (node[player.x - 1, player.y].canCross == false)
                    {
                        return;
                    }
                    else
                        player.y++;

                    Chase();
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (player.x == 1)
                    {
                        player.x = 1;
                    }
                    else if (node[player.x - 2, player.y - 1].canCross == false)
                    {
                        return;
                    }
                    else
                        player.x--;

                    Chase();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (player.x == mapScale)
                    {
                        player.x = mapScale;
                    }
                    else if (node[player.x, player.y - 1].canCross == false)
                    {
                        return;
                    }
                    else
                        player.x++;

                    Chase();
                }
            }
        }

        Queue<Node> que = new Queue<Node>();
        public void Chase()
        {
            //방문여부
            bool[,] check = new bool[mapScale, mapScale];
            
            
            Node[,] parent = new Node[mapScale, mapScale];

            
            List<Node> path = new List<Node>();

            //초기화
            for (int i = 0; i < mapScale; i++)
            {
                for (int j = 0; j < mapScale; j++)
                {
                    check[i, j] = false;
                    parent[i, j] = null;
                }
            }

            //상하좌우
            int[] dx = { 0, 0, 1, -1 };
            int[] dy = { 1, -1, 0, 0 };

            //현재 적 위치 큐에 저장
            que.Enqueue(node[enemy.x - 1, enemy.y - 1]);
            check[enemy.x - 1, enemy.y - 1] = true;

            //큐가 빌 때까지
            while (que.Count != 0)
            {
                //현재
                Node now = que.Dequeue();

                //상하좌우 
                for (int i = 0; i < 4; i++)
                {
                    int nx = now.x + dx[i];
                    int ny = now.y + dy[i];

                    //맵 범위
                    if (nx < 0 || nx >= mapScale || ny < 0 || ny >= mapScale)
                    {
                        continue;
                    }

                    //방문하지 않았거나 이동 할 수 있다면 
                    if (check[nx, ny] == false && node[nx, ny].canCross == true)
                    {
                        que.Enqueue(node[nx, ny]);
                        check[nx, ny] = true;
                        parent[nx, ny] = now;
                    }
                }
            }


            Node current = node[player.x - 1, player.y - 1];

            while (current != null)
            {
                path.Add(current);
                current = parent[current.x, current.y];
            }

            path.Reverse();

            enemy.x = path[1].x + 1;
            enemy.y = path[1].y + 1;
        }
    }
}
