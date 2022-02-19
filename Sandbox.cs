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
            Dictionary<int, EValueType> dic = new Dictionary<int, EValueType>();
            dic.Add(2, EValueType.Two);
            dic.Add(8, EValueType.Two);
            dic.Add(6, EValueType.Two);
            dic.Add(5, EValueType.Five);
            dic.Add(7, EValueType.Seven);

            int[] keys = new int[dic.Count];
            dic.Keys.CopyTo(keys, 0);

            EValueType[] values = new EValueType[dic.Count];
            dic.Values.CopyTo(values, 0);

            //Bubble sort

            for (int i = 0; i < keys.Length; i++)
            {                
                for (int k = 0; k < keys.Length - 1; k++)
                {
                    int nextElement = keys[k + 1];

                    if (keys[k] < nextElement)
                    {
                        keys[k + 1] = keys[k];
                        keys[k] = nextElement;
                    }
                }
            }


            for (int i = 0; i < keys.Length; i++)
            {
                Console.WriteLine(keys[i]);
            }

        }
    }
}