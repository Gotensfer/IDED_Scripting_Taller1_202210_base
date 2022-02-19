using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack)
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

            while (copyStack.Count > 0)
            {
                int element = copyStack.Pop();

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

            return result;
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = null;

            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            return 0;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = null;

            return result;
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = null;

            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = false;

            return result;
        }        
    }
}