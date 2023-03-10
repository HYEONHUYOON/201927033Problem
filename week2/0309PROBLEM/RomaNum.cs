using System;
using System.Linq;

namespace _0309PROBLEM
{
    public class RomaNum
    {
        int a;
        string b;

        //다시 출력
        public void Re()
        {
            Console.WriteLine("ㄷㅏㅅㅣ");
        }

        //로마로 변환
        private string Roma(int origin)
        {
            //로마자 출력 저장
            string s = "";

            //자릿수 확인
            int chun = origin / 1000;
            int bak = (origin % 1000) / 100;
            int sib = (origin % 100) / 10;
            int sibP = origin & 100;
            int il = (origin % 10);

            //천의자리
            for (int i = 0; i < chun; i++)
            {
                s += "M";
            }

            //999일 떄
            if (origin % 1000 == 999)
            {
                s += "CMXCIX";
            }
            //120일 때
            else
            {
                if (origin % 100 == 120)
                {
                    s += "CXX";

                    //일의 자리
                    if (il > 0)
                    {
                        switch (il)
                        {
                            case 9:
                                s += "IX";
                                break;

                            case 8:
                                s += "VIII";
                                break;
                            case 7:
                                s += "VII";
                                break;
                            case 6:
                                s += "VI";
                                break;
                            case 5:
                                s += "V";
                                break;
                            case 4:
                                s += "IV";
                                break;
                            case 3:
                                s += "III";
                                break;
                            case 2:
                                s += "II";
                                break;
                            case 1:
                                s += "I";
                                break;

                        }
                    }
                }
                //110일 때
                else if (origin % 100 == 110)
                {
                    s += "CX";

                    if (il > 0)
                    {
                        //일의 자리
                        switch (il)
                        {
                            case 9:
                                s += "IX";
                                break;

                            case 8:
                                s += "VIII";
                                break;
                            case 7:
                                s += "VII";
                                break;
                            case 6:
                                s += "VI";
                                break;
                            case 5:
                                s += "V";
                                break;
                            case 4:
                                s += "IV";
                                break;
                            case 3:
                                s += "III";
                                break;
                            case 2:
                                s += "II";
                                break;
                            case 1:
                                s += "I";
                                break;

                        }
                    }
                }
                else
                {
                    //위의 경우 다 아닐 때100의자리
                    switch (bak)
                    {
                        case 9:
                            s += "CM";
                            break;

                        case 8:
                            s += "DCCC";
                            break;
                        case 7:
                            s += "DCC";
                            break;
                        case 6:
                            s += "DC";
                            break;
                        case 5:
                            s += "D";
                            break;
                        case 4:
                            s += "CD";
                            break;
                        case 3:
                            s += "CCC";
                            break;
                        case 2:
                            s += "CC";
                            break;
                        case 1:
                            s += "C";
                            break;
                    }

                    //11 - 19 일때
                    if (sibP >= 10 && sibP <= 19)
                    {
                        switch (sibP)
                        {
                            case 19:
                                s += "XIX";
                                break;

                            case 18:
                                s += "XVIII";
                                break;
                            case 17:
                                s += "XVII";
                                break;
                            case 16:
                                s += "XVI";
                                break;
                            case 15:
                                s += "XV";
                                break;
                            case 14:
                                s += "XIV";
                                break;
                            case 13:
                                s += "XIII";
                                break;
                            case 12:
                                s += "XII";
                                break;
                            case 11:
                                s += "XI";
                                break;
                        }
                    }
                    else
                    {
                        //10의자리
                        switch (sib)
                        {
                            case 9:
                                s += "XC";
                                break;

                            case 8:
                                s += "LXXX";
                                break;
                            case 7:
                                s += "LXX";
                                break;
                            case 6:
                                s += "LX";
                                break;
                            case 5:
                                s += "L";
                                break;
                            case 4:
                                s += "XL";
                                break;
                            case 3:
                                s += "XXX";
                                break;
                            case 2:
                                s += "XX";
                                break;
                            case 1:
                                s += "X";
                                break;
                        }

                        if (il > 0)
                        {
                            //마지막 일의 자리
                            switch (il)
                            {
                                case 9:
                                    s += "IX";
                                    break;

                                case 8:
                                    s += "VIII";
                                    break;
                                case 7:
                                    s += "VII";
                                    break;
                                case 6:
                                    s += "VI";
                                    break;
                                case 5:
                                    s += "V";
                                    break;
                                case 4:
                                    s += "IV";
                                    break;
                                case 3:
                                    s += "III";
                                    break;
                                case 2:
                                    s += "II";
                                    break;
                                case 1:
                                    s += "I";
                                    break;
                            }
                        }
                    }
                }
            }
            return s;
        }

        //아라비아 숫자 -> 로마자 메서드
        public String AtorF(int receiveVal)
        {

            Console.WriteLine(Roma(receiveVal));

            return b;
        }

        //로마자 -> 아라비아 숫자 메서드
        public int RtoaF(string origings)
        {
            //받은 문자열
            string s = origings;

            //줄로 끊어 저장할 공간
            string[] romaS = new string[4];

            //포함되서는 안되는 문자
            var doNotContain = new string[] { "A", "B", "E", "F", "G", "H", "J", "K", "N", "O", "P", "Q", "R", "S", "T", "U","W","Y","Z"};

            //완료된 자릿수
            bool hundredCom = true;
            bool tenCom = true;
            bool ilCom = true;

            //반환할 최종 아라비아 숫자
            int resultV = 0;

            //카운트
            int i = 0;
            int count = 0;

            //포함되서는 안되는 문자가 포함 되어있을 때
            if(doNotContain.Any(data=>s.Contains(data)))
            {
                Console.WriteLine("잘못입력 했습니다.");
                return 0;
            }

            //천의자리 
            while (true)
            {
                if (s[i] == 'M')
                {
                    i++;
                    romaS[0] += "M";

                    resultV += 1000;

                    count++;
                }
                if (s.Length == i || s[i] != 'M')
                {
                    break;
                }
            }

            //999일때
            for (int j = count; j < s.Length; j++)
            {
                romaS[1] += s[j];
            }

            if (romaS[1] == "CMXCIX")
            {
                resultV += 999;
                hundredCom = false;
                tenCom = false;
                ilCom = false;

                //종료
                Console.WriteLine(resultV);
                return resultV;
            }

            //100의자리는 최대 4개로 표현 되므로
            int hundCount = 4;

            //100
            if (hundredCom == true)
            {
                while (hundredCom)
                {
                    //저장된 문자열 초기화
                    romaS[1] = "";

                    //100의 자리

                    //셀자릿수 만큼 있는지
                    if (s.Length - count - hundCount >= 0)
                    {
                        //자릿수 저장 
                        for (int j = count; j < count + hundCount; j++)
                        {
                            romaS[1] += s[j];
                        }

                        //확인
                        switch (romaS[1])
                        {
                            case "CM":
                                resultV += 900;
                                hundredCom = false;
                                count++;
                                count++;
                                break;
                            case "DCCC":
                                resultV += 800;
                                hundredCom = false;
                                count++;
                                count++;
                                count++;
                                count++;
                                break;
                            case "DCC":
                                resultV += 700;
                                hundredCom = false;
                                count++;
                                count++;
                                count++;
                                break;
                            case "DC":
                                resultV += 600;
                                hundredCom = false;
                                count++;
                                count++;
                                break;
                            case "D":
                                resultV += 500;
                                hundredCom = false;
                                count++;
                                break;
                            case "CD":
                                resultV += 400;
                                hundredCom = false;
                                count++;
                                count++;
                                break;
                            case "CCC":
                                resultV += 300;
                                hundredCom = false;
                                count++;
                                count++;
                                count++;
                                break;
                            case "CC":
                                resultV += 200;
                                hundredCom = false;
                                count++;
                                count++;
                                break;
                            case "C":
                                resultV += 100;
                                hundredCom = false;
                                count++;
                                break;
                            case "CX":
                                resultV += 110;
                                hundredCom = false;
                                tenCom = false;
                                count++;
                                count++;
                                break;
                            case "CXX":
                                resultV += 120;
                                hundredCom = false;
                                tenCom = false;
                                count++;
                                count++;
                                count++;
                                break;
                            case " ":
                                Console.WriteLine("잘못입력(공백)");
                                break;
                            default: 
                                break;
                        }
                    }

                    hundCount--;

                    //카운트 끝나면 100의자리 종료
                    //100의 자릿수가 아닐 경우
                    if (hundCount == 0)
                    {
                        hundredCom = false;
                        break;
                    }
                }
            }

            //10의자리는 최대 4개로 표현 되므로
            int tenCount = 5;

            if (tenCom == true)
            {
                while (tenCom)
                {
                    romaS[2] = "";
                    //10의 자리

                    if (s.Length - count - tenCount >= 0)
                    {
                        for (int j = count; j < count + tenCount; j++)
                        {
                            romaS[2] += s[j];
                        }

                        switch (romaS[2])
                        {
                            case "XC":
                                resultV += 90;
                                tenCom = false;
                                count++;
                                count++;
                                break;
                            case "LXXX":
                                resultV += 80;
                                tenCom = false;
                                count++;
                                count++;
                                count++;
                                count++;
                                break;
                            case "LXX":
                                resultV += 70;
                                tenCom = false;
                                count++;
                                count++;
                                count++;
                                break;
                            case "LX":
                                resultV += 60;
                                tenCom = false;
                                count++;
                                count++;
                                break;
                            case "L":
                                resultV += 50;
                                tenCom = false;
                                count++;
                                break;
                            case "XL":
                                resultV += 40;
                                tenCom = false;
                                count++;
                                count++;
                                break;
                            case "XXX":
                                resultV += 30;
                                tenCom = false;
                                count++;
                                count++;
                                count++;
                                break;
                            case "XX":
                                resultV += 20;
                                tenCom = false;
                                count++;
                                count++;
                                break;
                            case "X":
                                resultV += 10;
                                tenCom = false;
                                count++;
                                break;
                            case "XI":
                                resultV += 11;
                                tenCom = false;
                                ilCom = false;
                                break;
                            case "XII":
                                resultV += 12;
                                tenCom = false;
                                ilCom = false;
                                break;
                            case "XIII":
                                resultV += 13;
                                tenCom = false;
                                ilCom = false;
                                break;
                            case "XIV":
                                resultV += 14;
                                tenCom = false;
                                ilCom = false;
                                break;
                            case "XV":
                                resultV += 15;
                                tenCom = false;
                                ilCom = false;
                                break;
                            case "XVI":
                                resultV += 16;
                                tenCom = false;
                                ilCom = false;
                                break;
                            case "XVII":
                                resultV += 17;
                                tenCom = false;
                                ilCom = false;
                                break;
                            case "XVIII":
                                resultV += 18;
                                tenCom = false;
                                ilCom = false;
                                break;
                            case "XIX":
                                resultV += 19;
                                tenCom = false;
                                ilCom = false;
                                break;
                            case " ":
                                Console.WriteLine("잘못입력(공백)");
                                break;
                            default:
                                break;
                        }
                    }
                    tenCount--;
                    if (tenCount == 0)
                    {
                        tenCom = false;
                        break;
                    }
                }
            }

            int ilCount = 4;

            if (ilCom == true)
            {
                while (ilCom)
                {
                    romaS[3] = "";
                    //1의 자리

                    if (s.Length - count - ilCount >= 0)
                    {

                        for (int j = count; j < count + ilCount; j++)
                        {
                            romaS[3] += s[j];
                        }

                        switch (romaS[3])
                        {
                            case "IX":
                                resultV += 9;
                                ilCom = false;
                                break;
                            case "VIII":
                                resultV += 8;
                                ilCom = false;
                                break;
                            case "VII":
                                resultV += 7;
                                ilCom = false;
                                break;
                            case "VI":
                                resultV += 6;
                                ilCom = false;
                                break;
                            case "V":
                                resultV += 5;
                                ilCom = false;
                                break;
                            case "IV":
                                resultV += 4;
                                ilCom = false;
                                break;
                            case "III":
                                resultV += 3;
                                ilCom = false;
                                break;
                            case "II":
                                resultV += 2;
                                ilCom = false;
                                break;
                            case "I":
                                resultV += 1;
                                ilCom = false;
                                break;
                            case " ":
                                Console.WriteLine("잘못입력(공백)");
                                break;
                            default:
                                break;
                        }
                    }
                    ilCount--;

                    if (ilCount == 0)
                    {
                        ilCom = false;
                        break;
                    }
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

