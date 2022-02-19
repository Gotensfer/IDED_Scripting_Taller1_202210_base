using System;
using System.Collections.Generic;

namespace TestProject1
{
    internal class Sandbox
    {
        enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        public static void Main(string[] args)
        {

            /*
            int testNumber = 811;

            Console.WriteLine("Number: " + testNumber);
            Console.WriteLine("Is even: " + isEven(testNumber));
            Console.WriteLine("Is multiple of three: " + isMultipleOfThree(testNumber));
            Console.WriteLine("Is multiple of five: " + isMultipleOfFive(testNumber));
            Console.WriteLine("Is multiple of seven: " + isMultipleOfSeven(testNumber));
            Console.WriteLine("Is prime: " + isPrime(testNumber));
            */

            int[] arr = { 2, 5, 8, 2 };
            int[] arr2 = new int[arr.Length];
            arr.CopyTo(arr2, 0);


        }

        /*
        static bool isEven(int number)
        {
            if (number % 2 == 0) return true;
            else return false;

        }

        static bool isMultipleOfThree(int number)
        {
            if (number % 3 == 0) return true;
            else return false;
            
        }

        static bool isMultipleOfFive(int number)
        {
            if (number % 5 == 0) return true;
            else return false;
        }

        static bool isMultipleOfSeven(int number)
        {
            if (number % 7 == 0) return true;
            else return false;
        }

        
        static bool isPrime(int number)
        {
            int dividers = 0;

            for (int i = 2; i < 10; i++)
            {
                if (number % i == 0) dividers++;
                if (dividers > 1) return false;
            }

            return true;
        }
        */
    }
}