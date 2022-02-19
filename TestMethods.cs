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
            //Crear una copia profunda del sourceStack guardandolo en un arreglo
            int[] arrayOfSourceStack = sourceStack.ToArray();   //Convertir el stack al array
            Stack<int> copyStack = new Stack<int>();            //Definir donde se guardará la copia profunda

            //Transformar el arreglo devuelta a un stack (Teniendo un stack idéntico al sourceStack)
            //Al colocar los elementos en un array, se desorganiza el stack, por lo que para organizarlo
            //se recorren los datos de forma inversa
            for (int i = arrayOfSourceStack.Length - 1; i >= 0; i--)
            {
                copyStack.Push(arrayOfSourceStack[i]);
            }

            Stack<int> result = new Stack<int>(); //Stack result que se entrega para el problema
            List<int> outs = new List<int>(); //Lista de las salidas que van saliendo del stack
            List<int> readyResults = new List<int>(); //Lista de los resultados listos pero que están sin ordernar (Se debe invertir luego)

            //Algoritmo en sí que me permite obtener los resultados que me exige el problema (Pero con su orden invertido)
            while (copyStack.Count > 0) //Mientras aun existan elementos en el stack
            {
                int element = copyStack.Pop(); //sacar el elemento de arriba del stack y guardarlo

                outs.Add(element); //añadirlo a la lista de salidas que se usará para buscar si hay un numero mayor

                int biggerElement = element; //inicializar el elemento más grande con el mismo elemento que se acaba de sacar

                //recorrer la lista de salidas para encontrar si hay algún número mayor al que acabamos de sacar
                for (int i = 0; i < outs.Count; i++)
                {
                    if (outs[i] > biggerElement) biggerElement = outs[i]; //si lo hay, actualizar el número más grande
                }

                if (biggerElement == element) readyResults.Add(-1); //si al final el elemento más grande sigue siendo el propio elemento, ponemos un -1 en el resultado(no hay nadie mas grande)
                else readyResults.Add(biggerElement); //si al final si hay un elemento más grande, se añade este a los resultados
            }

            //recorrer de forma inversa la lista de resultados para guardarlos en el stack final de result de la forma correcta en su orden
            for (int i = readyResults.Count - 1; i >= 0; i--)
            {
                result.Push(readyResults[i]);
            }

            return result; //Entregar el stack resultado
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>(); //Diccionario a entregar del problema

            //Crear una copia profunda del sourceArr usando el metodo CopyTo de los arrays
            int[] copy = new int[sourceArr.Length];
            sourceArr.CopyTo(copy, 0);

            //Realizar las pruebas correspondientes para añadir el par correcto de llave (el numero) y valor (el EValueType)
            for (int i = 0; i < copy.Length; i++)
            {
                //Hacerlo con else if garantiza que el primero de los casos sea el que se guarde
                //Si al realizar la operación módulo el residuo me da 0 significa que este número con el que operó es divisor (Lo cual implica ser multiplo)
                if (copy[i] % 2 == 0) result.Add(copy[i], EValueType.Two);
                else if (copy[i] % 3 == 0) result.Add(copy[i], EValueType.Three);
                else if (copy[i] % 5 == 0) result.Add(copy[i], EValueType.Five);
                else if (copy[i] % 7 == 0) result.Add(copy[i], EValueType.Seven);
                else result.Add(copy[i], EValueType.Prime); //Si el resto de casos no se cumplen, implica que el número es primo
            }

            return result; //Entregar el diccionario resultado
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            int result = 0; //contador de resultado a entregar al problema

            //Crear una copia profunda del sourceDict en un array usando el metodo CopyTo de los diccionarios
            int[] keys = new int[sourceDict.Count]; 
            sourceDict.Keys.CopyTo(keys, 0);

            //Recorrer el diccionario, si el elemento corresponde al type que busca el problema, se le suma 1 al contador de ocurrencias
            for (int i = 0; i < keys.Length; i++)
            {
                if (sourceDict[keys[i]] == type) result++;
            }

            return result; //Entregar el resultado
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>(); //Diccionario a entregar al problema

            //Extraer un array con todas las llaves del sourceDict
            int[] keys = new int[sourceDict.Count];
            sourceDict.Keys.CopyTo(keys, 0);

            //Extraer un array con todas los valores del sourceDict
            EValueType[] values = new EValueType[sourceDict.Count];
            sourceDict.Values.CopyTo(values, 0);

            //Ordenar de forma descendente el array de las llaves y los valores (manteniendo la correspondencia)
            //usando bubble sort
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

            //Como ya están ordenadas los pares de llaves y valores
            //se procede a añadirlos al diccionario del resultado
            for (int i = 0; i < keys.Length; i++)
            {
                result.Add(keys[i], values[i]);
            }

            return result; //Entregar el resultado
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = new Queue<Ticket>[3]; //Array de Queues a entregar del problema

            //Realizar una copia profunda del sourceList de tickets en un array usando el método CopyTo
            Ticket[] copy = new Ticket[sourceList.Count];
            sourceList.CopyTo(copy, 0);

            //Inicializar los 3 queues que irán en el array de queues
            Queue<Ticket> paymentQueue = new Queue<Ticket>();
            Queue<Ticket> subscriptionQueue = new Queue<Ticket>();
            Queue<Ticket> cancellationQueue = new Queue<Ticket>();

            //Organizar de forma ascendente todos los turnos independiente de su tramite
            //usando un bubble sort
            for (int i = 0; i < copy.Length; i++)
            {
                for (int k = 0; k < copy.Length - 1; k++)
                {
                    int nextTurn = copy[k + 1].Turn;
                    Ticket nextTicket = copy[k + 1];

                    if (copy[k].Turn > nextTurn)
                    {
                        copy[k + 1] = copy[k];
                        copy[k] = nextTicket;
                    }
                }
            }

            //Ya que los turnos ya están ordenados, se puede proceder a asignar los turnos
            //a los queues de su tipo correspondiente (y estos ya estarán ordenados)
            for (int i = 0; i < copy.Length; i++)
            {
                if (copy[i].RequestType == Ticket.ERequestType.Payment) paymentQueue.Enqueue(copy[i]);
                if (copy[i].RequestType == Ticket.ERequestType.Subscription) subscriptionQueue.Enqueue(copy[i]);
                if (copy[i].RequestType == Ticket.ERequestType.Cancellation) cancellationQueue.Enqueue(copy[i]);
            }

            //Una vez ya todos los turnos están en sus repectivas queues
            //se guardan las queues en el orden requerido en el array
            result[0] = paymentQueue;
            result[1] = subscriptionQueue;
            result[2] = cancellationQueue;

            return result; //entregar el resultado
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = false; //booleana que se entregara al problema

            //Se realiza un peek (dar un vistazo) a un elemento de la queue para poder obtener 
            //su RequestType y determinar el RequestType de esta targetQueue
            Ticket.ERequestType typeOfTicketQueue = targetQueue.Peek().RequestType; 

            //Si se cumple que:
            //  el RequestType del tiquete a ingresar es igual al RequestType del targetQueue
            //  el turno del tiquete entre 1 y 99
            //entonces se sabe que el tickete podrá ser ingresado por lo que el resultado que arrojará es true, en caso
            //contrario se mantendra en false
            if (ticket.RequestType == typeOfTicketQueue && ticket.Turn > 0 && ticket.Turn < 100) result = true;

            return result; //entregar el resultado
        }        
    }
}