using System;
using System.Linq;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            StartHere();
            Console.ReadKey();
        }

        private static void StartHere()
        {
            // local variables should have some consistency and a name that hints at their purpose
            int num1 = MyCalculator.Sum(1, 3);
            int num2 = MyCalculator.Sum(1, 3, 5);
            Console.WriteLine(num1);
            Console.WriteLine(num2);
        }
    }
    // no reason for this not to be static
    // class name should hint at its purpose
    static class MyCalculator
    {
        public static int Sum(params int[] input)// it can accept any number of parameters; method overload would also be fine(same name, different signature)
        {
            return input.Sum();
        }
    }
}
