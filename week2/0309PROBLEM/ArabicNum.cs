using System;
namespace _0309PROBLEM
{
    public class ArabicNum
    {
        //로마자와 그에 맞는 값 Key and Value
        Dictionary<char, int> romaNum = new Dictionary<char, int>()
        {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
        };

        //올바른 로마자인지
        //public bool checkRom(string origin)
        //{
        //    string s = origin;
        //    string vld = "VLD";
        //    string ixcm = "IXCM";

        //    //카운트
        //    int vldcount = 0;
        //    int ixcmcount = 0;

        //    //검사
        //    foreach (char c in s)
        //    {
        //        if (vld.Contains(c))
        //        {
        //            Console.WriteLine(c);
        //            vldcount++;
        //        }
        //        else if (ixcm.Contains(c))
        //        {
        //            Console.WriteLine(c);
        //            ixcmcount++;
        //        }
        //    }

        //    //값의 허용 입력 카운트가 넘었을 때
        //    if (ixcmcount > 3 || vldcount > 1)
        //    {
        //        return false;
        //    }
        //    else
        //        return true;
        //}

        //로마자 -> 아라비아 숫자 메서드
        public int RtoaF(string origings)
        {
            //받은 문자열
            string s = origings;

            //포함되서는 안되는 문자
            var doNotContain = new string[] { "A", "B", "E", "F", "G", "H", "J", "K", "N", "O", "P", "Q", "R", "S", "T", "U", "W", "Y", "Z" };

            //반환할 최종 아라비아 숫자
            int resultV = 0;

            //카운트
            int count = 0;

            //검사할 값을 받을 변수
            int getValue1 = 0;
            int getValue2 = 0;

            //포함되서는 안되는 문자가 포함 되어있을 때
            if (doNotContain.Any(data => s.Contains(data)))
            {
                Console.WriteLine("잘못입력 했습니다.");
                return 0;
            }

            //받은 길이 만큼
            for (int j = 0; j < s.Length; j++)
            {
                //계산할 문자열이 하나 이상일 때
                if (count < s.Length-1)
                {
                    romaNum.TryGetValue(s[count], out getValue1);
                    romaNum.TryGetValue(s[count + 1], out getValue2);
                }
                //계산할 문자열이 하나 남았을 때
                else
                {
                    romaNum.TryGetValue(s[count], out getValue1);
                    resultV += getValue1;
                    count++;
                    break;
                }

                //받은 문자열 두개가 서로 같을 때 
                if (s[count] == s[count + 1])
                {
                    resultV += getValue1 + getValue2;
                    count += 2;
                }
                //둘이 같지 않을 때
                else if (s[count] != s[count + 1])
                {
                    //이미 하나 이상의 문자열을 검사 하였을 경우
                    if (count >= 1)
                    {
                        //첫번째 문자열과 바로 전 문자열이 같다면
                        if (s[count] == s[count - 1])
                        {
                            resultV += getValue1;
                            count++;
                        }
                        //2번째 문자열이 첫번째 문자열 보다 크다면
                        else if (getValue1 < getValue2)
                        {
                            resultV += getValue2 - getValue1;
                            count += 2;
                        }
                        //그외
                        else
                        {
                            resultV += getValue1;
                            count++;
                        }
                    }
                    //첫 검사일 때
                    else
                    {
                        if (getValue1 < getValue2)
                        {
                            resultV += getValue2 - getValue1;
                            count += 2;
                        }
                        else
                        {
                            resultV += getValue1;
                            count++;
                        }
                    }
                    
                }
                //else {
                //    resultV += getValue1;
                //    count++;
                //}

                //모두 검사 하였을 때
                if (count == s.Length)
                {
                    break;
                }
            }
            
            //아무것도 저장되지 않았을 경우
            if (resultV == 0)
            {
                Console.WriteLine("잘못입력함");
                return 0;
            }

            //4000을 넘을경우 계산범위 안에 들어오지 않기 때문에 반환
            else if (resultV > 4000)
            {
                Console.WriteLine("잘못입력함");
                return 0;
            }
            Console.WriteLine(resultV);

            return resultV;
        }

        //받은 문자열이 대문자 영어인지
        public bool isBig(string str)
        {
            return str.Equals(str.ToUpper());
        }
    }
}