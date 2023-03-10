using System;

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("숫자를 입력하세요: ");
        string input = Console.ReadLine();
        int inputint;

        bool isRight = int.TryParse(input, out inputint);
        if (isRight) {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            string reversed = new string(chars);
            Console.WriteLine(reversed);
        }
        
    }
}
