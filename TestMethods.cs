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
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();


            int[] copy = new int[sourceArr.Length];
            sourceArr.CopyTo(copy, 0);

            for (int i = 0; i < copy.Length; i++)
            {
                if (copy[i] % 2 == 0) result.Add(copy[i], EValueType.Two);
                else if (copy[i] % 3 == 0) result.Add(copy[i], EValueType.Three);
                else if (copy[i] % 5 == 0) result.Add(copy[i], EValueType.Five);
                else if (copy[i] % 7 == 0) result.Add(copy[i], EValueType.Seven);
                else result.Add(copy[i], EValueType.Prime);
            }

            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            int result = 0;

            int[] keys = new int[sourceDict.Count];
            sourceDict.Keys.CopyTo(keys, 0);

            for (int i = 0; i < keys.Length; i++)
            {
                if (sourceDict[keys[i]] == type) result++;
            }

            return result;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();

            int[] keys = new int[sourceDict.Count];
            sourceDict.Keys.CopyTo(keys, 0);

            EValueType[] values = new EValueType[sourceDict.Count];
            sourceDict.Values.CopyTo(values, 0);

            for (int i = 0; i < keys.Length; i++)
            {
                for (int k = 0; k < keys.Length - 1; k++)
                {
                    int nextKey = keys[k + 1];
                    EValueType nextValue = values[k + 1];

                    if (keys[k] < nextKey)
                    {
                        keys[k + 1] = keys[k];
                        keys[k] = nextKey;

                        values[k + 1] = values[k];
                        values[k] = nextValue;
                    }
                }
            }

            for (int i = 0; i < keys.Length; i++)
            {
                result.Add(keys[i], values[i]);
            }

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