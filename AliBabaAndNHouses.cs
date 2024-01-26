using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class AliBabaAndNHouses
    {
        #region YOUR CODE IS HERE

        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// find the maximum amount of money that Ali baba can get, given the number of houses (N) and a list of the net gained value for each consecutive house (V)
        /// </summary>
        /// <param name="values">Array of the values of each given house (ordered by their consecutive placement in the city)</param>
        /// <param name="N">The number of the houses</param>
        /// <returns>the maximum amount of money the Ali Baba can get </returns>


        static int result;
        static int[] storage;
        static int[] index;
        static int[] arr;

        static public int SolveValue(int[] values, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();

            List<int> path_houses = new List<int>();
            result = 0;
            int temp = 0;
            int temp1 = 0;
            storage = new int[N];
            index = new int[N];
            int c = 0;
            for (int i = 0; i < N; i++)
            {
                index[i] = -1;
            }

            for (int i = 0; i < N; i++)
            {

                if (c == 0)
                {
                    if (i + 2 >= N && i + 3 >= N)
                    {
                        result = Math.Max(values[i + 1], values[i]);
                        arr = new int[1];
                        if (result == values[i])
                        {
                            arr[0] = 1;
                        }
                        else
                        {
                            arr[0] = 2;
                        }

                    }
                    else if (i + 2 < N && i + 3 >= N)
                    {
                        storage[i] = values[i];
                        storage[i + 1] = values[i + 1];
                        storage[i + 2] = storage[i] + values[i + 2];

                        if (storage[i + 2] != result && result < storage[i + 2])
                        {
                            index[i + 2] = i;
                        }

                        result = Math.Max(storage[i + 2], result);
                    }
                    else if (i < N && i + 3 < N)
                    {
                        storage[i] = values[i];
                        storage[i + 1] = values[i + 1];
                        storage[i + 2] = storage[i] + values[i + 2];

                        if (storage[i + 2] != result && result < storage[i + 2])
                        {
                            index[i + 2] = i;
                        }

                        result = Math.Max(storage[i + 2], result);
                        storage[i + 3] = storage[i] + values[i + 3];

                        if (storage[i + 3] != result && result < storage[i + 3])
                        {
                            index[i + 3] = i;
                        }

                        result = Math.Max(result, storage[i + 3]);
                    }
                    c++;
                    continue;
                }

                if (i + 2 >= N && i + 3 >= N)
                {
                    result = Math.Max(result, values[i]);



                    break;
                }
                else if (i + 2 < N && i + 3 >= N)
                {
                    temp = storage[i] + values[i + 2];
                    result = Math.Max(result, temp);

                    if (storage[i + 2] != temp && temp > storage[i + 2])
                    {
                        index[i + 2] = i;
                    }

                    storage[i + 2] = Math.Max(storage[i + 2], temp);
                }
                else if (i < N && i + 3 < N)
                {
                    temp = storage[i] + values[i + 2];
                    result = Math.Max(result, temp);
                    temp1 = storage[i] + values[i + 3];
                    result = Math.Max(temp1, result);

                    if (storage[i + 2] != temp && temp > storage[i + 2])
                    {
                        index[i + 2] = i;
                    }

                    storage[i + 2] = Math.Max(storage[i + 2], temp);

                    if (storage[i + 3] != temp1 && temp1 > storage[i + 3])
                    {
                        index[i + 3] = i;
                    }

                    storage[i + 3] = Math.Max(storage[i + 3], temp1);
                }
                c++;
            }
            return result;
        }
        #endregion

        #region FUNCTION#2: Construct the Solution
        //Your Code is Here:
        //==================
        /// <returns>Array of the indices of the robbed houses (1-based and ordered from left to right) </returns>
        static public int[] ConstructSolution(int[] values, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();

            List<int> path_houses = new List<int>();
            int c = 0;
            if (N == 2)
            {
                return arr;
            }

            for (int i = N - 1; i >= 0; i--)
            {
                if (result == storage[i])
                {
                    path_houses.Add(i + 1);
                    if (index[i] == -1)
                    {
                        break;
                    }
                    path_houses.Add(index[i] + 1);
                    i = index[i] + 1;
                    continue;
                }
                else if (result != storage[i] && path_houses.Count() == 0)
                {
                    continue;
                }

                if (index[i] == -1)
                {
                    break;
                }
                path_houses.Add(index[i] + 1);
                i = index[i] + 1;

            }

            int n = path_houses.Count() - 1;
            int[] houses = new int[path_houses.Count()];
            for (int i = 0; i < path_houses.Count(); i++)
            {
                houses[i] = path_houses[n];
                n--;
            }

            return houses;
        }
        #endregion
        
        #endregion
    }
}
