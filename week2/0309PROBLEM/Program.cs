namespace _0309PROBLEM
{
    class Program
    {
        public static void Main()
        {
            //esc종료 쓰레드
            Thread threadESC = new Thread(escFunc);
            threadESC.Start();

            RomaNum a = new RomaNum();
            ArabicNum b = new ArabicNum();

            bool isRight;
            int receiveVal;
            string s;

            while (true)
            {
                s = Console.ReadLine();
                isRight = int.TryParse(s, out receiveVal);

                //숫자가 범위 안에 있는지
                if (isRight)
                {
                    if (receiveVal >= 4000)
                    {
                        a.Re();
                    }
                    else if (isRight == false)
                    {
                        a.Re();
                    }
                    else
                        a.AtorF(receiveVal);
                }
                //대문자영어인지
                else if (b.isBig(s))
                {
                    //if (b.checkRom(s)==false)
                    //{
                    //    Console.WriteLine("잘못 입력하였습니다.2");
                    //}
                    //else
                        b.RtoaF(s);
                }
                else
                    Console.WriteLine("잘못 입력하였습니다.");
            }
        }

        //쓰레드 함수
        private static void escFunc()
        {
            while (true)
            {
                //받은 키값이 esc일 때 종료 
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("종료");
                    Environment.Exit(0);
                }
            }
        }
    }
}
