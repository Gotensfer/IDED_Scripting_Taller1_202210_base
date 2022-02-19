using System;
using System.Collections.Generic;

namespace TestProject1
{
    internal class Sandbox
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.WriteLine("Here you can write console prints to test your implementation outside the testing environment");
        
            Stack<int> sc = new Stack<int>();
            sc.Push(14);
            sc.Push(8);
            sc.Push(7);
            sc.Push(13);

            outResult(sc);
            sc.Clear();
            Console.WriteLine(sc.Count);

            sc.Push(26);
            sc.Push(3);
            sc.Push(6);
            sc.Push(5);

            outResult(sc);


        }
        
        static Stack<int> outResult (Stack<int> sourceStack)
        {

            int[] arrayOfSourceStack = sourceStack.ToArray();
            Stack<int> copyStack = new Stack<int>();

            for (int i = arrayOfSourceStack.Length - 1; i >= 0; i--)
            {
                copyStack.Push(arrayOfSourceStack[i]);
            }

            Stack<int> result = new Stack<int>();
            List<int> outs = new List<int>();
            List<int> readyResults = new List<int>();

            //--

            while (copyStack.Count > 0)
            {
                int element = copyStack.Pop();
                Console.WriteLine(element);

                outs.Add(element);

                int biggerElement = element;

                for (int i = 0; i < outs.Count; i++)
                {
                    if (outs[i] > biggerElement) biggerElement = outs[i];
                }

                if (biggerElement == element) readyResults.Add(-1);
                else readyResults.Add(biggerElement);
            }

            for (int i = readyResults.Count - 1; i >= 0; i--)
            {
                result.Push(readyResults[i]);
            }

            
            while (result.Count > 0)
            {
                Console.WriteLine(result.Pop());
            }

            return result;
        }
    }
}