using System;
using System.Linq;

namespace _0309PROBLEM
{
    public class RomaNum
    {
        string b;

        //다시 출력
        public void Re()
        {
            Console.WriteLine("다시 입력하세요");
        }

        //로마로 변환
        public  void AtorF(int origin)
        {
            //로마자 출력 저장
            string s = "";

            char[,] RomaS = new char[3, 2]
            {
                { 'I', 'V' }, { 'X', 'L' }, {'C','D'}
            };

            //자릿수 확인
            int[] numberSection = new int[4];
            numberSection[0] = origin / 1000;
            numberSection[1] = (origin % 1000) / 100;
            numberSection[2] = (origin % 100) / 10;
            numberSection[3] = (origin % 10);

            for (int i = 0; i < numberSection[0]; i++)
            {
                s += "M";
            }

            int j = 2;

            for (int i = 0; i < 3; i++)
            {
                if (numberSection[i+1] > 5)
                {
                    s += RomaS[j,1];
                    numberSection[i+1] -= 1;
                }
                else if (numberSection[i+1] == 4)
                {
                    s += RomaS[j, 0];
                    s += RomaS[j, 1];
                    numberSection[1] -= 4;
                }

                for (int k = 0; k < numberSection[i+1]; k++)
                {
                    s += RomaS[j, 0];
                }
                j--;
            }

            Console.WriteLine(s);
        }
    }
}

