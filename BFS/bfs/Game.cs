using Microsoft.Win32.SafeHandles;
using System;

namespace bfs
{
    internal class Game
    {
        //장애물 랜덤 생성을 위함
        Random ran = new Random();

        public int x;
        public int y;

        int mapScale;

        //위치 노드
        public Node[,] node;

        //게임 오브젝트
        public Player player;
        Enemy enemy;

        //장애물 생성갯수
        int ObstacleCount;

        //최적경로
        Node[] Route;
        bool isExistRoute = false;

        //생성자
        public Game(int mapScale)
        {
            //맵 초기화
            this.mapScale = mapScale;
            node = new Node[mapScale, mapScale];

            //맵 노드 이니셜라이즈
            for (int y = 0; y < mapScale; y++)
            {
                for (int x = 0; x < mapScale; x++)
                {
                    node[x, y] = new Node(x, y);
                }
            }

            GameObjectInit();
        }

        //좌표 입력
        public int[] GameObjectPositionInput()
        {
            int[] pos = new int[2];
            int x;
            int y;

            do
            {
                Console.WriteLine($"AddPredecessor표 범위 => 0 ~ {mapScale - 1}");
                Console.Write("X좌표 값을 입력:");
                x = int.Parse(Console.ReadLine());

                Console.Write("Y좌표 값을 입력:");
                y = int.Parse(Console.ReadLine());

                if (x >= mapScale || y >= mapScale || x < 0 || y < 0)
                {
                    Console.WriteLine("입력된 값이 범위를 벗어났습니다. 다시 입력해주세요.");
                }
            }
            while (x >= mapScale || y >= mapScale || x < 0 || y < 0);

            pos[0] = x;
            pos[1] = y;

            Console.WriteLine(x +" "+ y);

            return pos;
        }

        //장애물 랜덤 생성
        public void ObstacleRandInit()
        {
            Console.WriteLine("위치는 랜덤으로 정해집니다.");
            int randX;
            int randY;

            for (int i = 0; i < ObstacleCount; i++)
            {
                //플레이어나 적 좌표와 겹치지 않을때 까지 실행
                do
                {
                    //랜덤한 위치
                    randX = ran.Next(0, mapScale - 1);
                    randY = ran.Next(0, mapScale - 1);
                }
                while ((randX == player.x && randY == player.y) || (randX == enemy.x && randY == enemy.y));

                //노드에 저장
                node[randX, randY].gameObject = new Obstacle(randX, randY, "M");
                node[randX, randY].canCross = false;

            }
        }

        //게임 오브젝트 이니셜라이즈
        public void GameObjectInit()
        {
            int[] pos;

            //플레이어 이니셜라이즈
            Console.WriteLine("플레이어(P)");
            pos = GameObjectPositionInput();
            player = new Player(pos[0], pos[1],"P");
            //노드 위치에 저장
            node[player.x, player.y].gameObject = player;

            //적 이니셜라이즈
            Console.WriteLine("적(E)");
            pos = GameObjectPositionInput();
            enemy = new Enemy(pos[0], pos[1],"E");
            //노드 위치에 저장
            node[enemy.x, enemy.y].gameObject = enemy;

            //장애물 이니셜라이즈
            Console.Write("장애물(M) 갯수를 정하시요");
            ObstacleCount = int.Parse(Console.ReadLine());
            ObstacleRandInit();
        }

        //BFS경로 초기화
        public void BFSRouteInit()
        {
            for(int i =0;i<mapScale;i++)
            {
                for (int j = 0; j < mapScale; j++)
                {
                    node[i, j].bfsRoute = false;
                }
            }
        }

        //렌더
        public void Render()
        {
            //잡히게 되면 게임 오버
            if(player.x == enemy.x && player.y == enemy.y)
            {
                Console.WriteLine("GAME OVER");
            }
            else
            {
                Chase();
                Input();
                DrawRectangularBoard();
            }
        }

        //맵 출력
        public void DrawRectangularBoard()
        {
            // 말판을 그림
            for (int y = 0; y < mapScale; y++)
            {
                for (int x = 0; x < mapScale; x++)
                {
                    //노드에 오브젝트 있으면 오브젝트 출력
                    if (node[x, y].gameObject != null)
                    {
                        Console.Write(" ");
                        Console.Write(" ");
                        if (node[x, y].gameObject.name == "P")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (node[x, y].gameObject.name == "E")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (node[x, y].gameObject.name == "M")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write(node[x, y].gameObject.name);
                        Console.Write(" ");
                        Console.Write(" ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        if (node[x, y].bfsRoute == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" ");
                            Console.Write(" ");
                            Console.Write("\u2593");
                            Console.Write(" ");
                            Console.Write(" ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write(" ");
                            Console.Write(" ");
                            Console.Write("\u2593");
                            Console.Write(" ");
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine($"플레이어 위치 : [{player.x},{player.y}]");
            Console.WriteLine($"적 위치 : [{enemy.x},{enemy.y}]");

            if (isExistRoute) {
                Console.Write("경로 : ");
                for (int i = 0; i < Route.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"({Route[i].x},{Route[i].y})");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (i != Route.Length - 1)
                    {
                        Console.Write(" => ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("경로가 존재 하지 않습니다.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //캐릭터 이동
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                //위로 이동
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    //이미 맵의 끝자락 일 때
                    if (player.y == 0)
                    {
                        player.y = 0;
                    }
                    //장애물이 있을 때 
                    else if (node[player.x, player.y - 1].canCross == false)
                    {
                        return;
                    }
                    //이동 가능 할 때 
                    else
                    {
                        node[player.x, player.y].gameObject = null;
                        player.y--;
                        node[player.x, player.y].gameObject = player;
                    }
                    BFSRouteInit();
                    Chase();
                }
                //아래로 이동
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    //이미 맵의 끝자락 일 때
                    if (player.y == mapScale - 1)
                    {
                        player.y = mapScale - 1;
                    }
                    //장애물이 있을 때 
                    else if (node[player.x, player.y + 1].canCross == false)
                    {
                        return;
                    }
                    //이동 가능 할 때 
                    else
                    {
                        node[player.x, player.y].gameObject = null;
                        player.y++;
                        node[player.x, player.y].gameObject = player;
                    }
                    BFSRouteInit();
                    Chase();
                }
                //왼쪽으로 이동
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    //이미 맵의 끝자락 일 때
                    if (player.x == 0)
                    {
                        player.x = 0;
                    }
                    //장애물이 있을 때 
                    else if (node[player.x - 1, player.y].canCross == false)
                    {
                        return;
                    }
                    //이동 가능 할 때 
                    else
                    {
                        node[player.x, player.y].gameObject = null;
                        player.x--;
                        node[player.x, player.y].gameObject = player;
                    }
                    BFSRouteInit();
                    Chase();
                }
                //오른쪽으로 이동
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    //이미 맵의 끝자락 일 때
                    if (player.x == mapScale - 1)
                    {
                        player.x = mapScale - 1;
                    }
                    //장애물이 있을 때 
                    else if (node[player.x + 1, player.y].canCross == false)
                    {
                        return;
                    }
                    //이동 가능 할 때 
                    else
                    {
                        node[player.x, player.y].gameObject = null;
                        player.x++;
                        node[player.x, player.y].gameObject = player;
                    }
                    BFSRouteInit();
                    Chase();
                }
            }
        }

        //BFS

        public void Chase()
        {
            BFSRouteInit();
            Queue<Node> que = new Queue<Node>();

            Node enemyPos = node[enemy.x, enemy.y];

            //방문여부
            bool[,] check = new bool[mapScale, mapScale];
            Node bestNode = null;

            //초기화
            for (int i = 0; i < mapScale; i++)
            {
                for (int j = 0; j < mapScale; j++)
                {
                    check[i, j] = false;
                }
            }

            //상하좌우
            int[] dx = { 0, 0, 1, -1 };
            int[] dy = { 1, -1, 0, 0 };

            //현재 적 위치 큐에 저장
            //시작
            que.Enqueue(node[enemy.x, enemy.y]);
            check[enemy.x, enemy.y] = true;

            //큐가 빌 때까지
            while (que.Count != 0)
            {
                //현재 노드
                Node now = que.Dequeue();

                // 현재 노드가 목표 지점일 경우
                if (now.x == player.x && now.y == player.y)
                {
                    //최고 노드가 비어있을 때 혹은 최고노드의 경로가 더 오래 걸릴 때
                    if (bestNode == null || (bestNode.prevCount > now.prevCount))
                    {
                        bestNode = now;
                    }
                }

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
                        Node searchNode = new Node(nx, ny);
                        searchNode.AddPredecessor(now);

                        que.Enqueue(searchNode);

                        check[nx, ny] = true;
                    }
                }
            }

            try
            {
                Route = new Node[bestNode.prevCount];
                int routeCount = 0;

                while (bestNode.prevCount > 0)
                {
                    //경로 배열에 저장
                    Route[routeCount] = bestNode;

                    node[bestNode.x, bestNode.y].bfsRoute = true;

                    routeCount++;

                    //자식 노드로 변경
                    bestNode = bestNode.Predecessor[0];
                }

                //거꾸로 뒤집기
                Array.Reverse(Route);

                ////적 이동
                //node[enemy.x, enemy.y].gameObject = null;
                //enemy.x = Route[0].x;
                //enemy.y = Route[0].y;
                //node[enemy.x, enemy.y].gameObject = enemy;

                isExistRoute = true;
            }
            catch
            {
                isExistRoute = false;
            }
        }
    }
}
