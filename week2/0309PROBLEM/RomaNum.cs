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

            //백 - 일의 자릿수 표현 문자
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

            //천의자리
            for (int i = 0; i < numberSection[0]; i++)
            {
                s += "M";
            }

            //자릿수 카운트
            int j = 2;

            //백의자릿수 부터 일의 자릿수 까지 
            for (int i = 1; i <= 3; i++)
            {
                //5이거나 크면 5 50 500 을 표현 하는 문자 표시
                if (numberSection[i] >= 5)
                {
                    s += RomaS[j,1];
                    //카운트 5개 뺌
                    numberSection[i] -= 5;
                }
                //4일 때
                else if (numberSection[i] == 4)
                {
                    //4 40 400을 표현 할 수있는 문자 순으로 배치
                    s += RomaS[j, 0];
                    s += RomaS[j, 1];

                    //카운트 전부 삭제
                    numberSection[i] = 0;
                }
                //남아 있는 카운트 만큼 표시
                for (int k = 0; k < numberSection[i]; k++)
                {
                    s += RomaS[j, 0];
                }

                //자릿수 카운트 --
                j--;
            }

            Console.WriteLine("결과 :  " + s);
        }
    }
}

