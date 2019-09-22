using System;
using System.Linq;
namespace Assignment1_F19
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);
            int n2 = 5;
            printSeries(n2);
            int n3 = 5;
            printTriangle(n3);
            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);
            int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            displayArray(r5);
            solvePuzzle();
        }
        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                //Initialize the for loop for checking each number
                for (int i = 1; i < 22; i++)
                {
                    //Separating the digits 
                    x = i % 10;
                    if (x != 0)
                    {
                        //checking for self-division
                        if (i % x == 0)
                        {
                            if (i > 9)
                            {
                                y = i / 10;
                                if (y != 0)
                                    if (i % y == 0)
                                        Console.Write(" " + i);
                            }
                            else
                            {
                                Console.Write(" " + i);
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }
        public static void printSeries(int n)
        {
            try
            {
                //Initialize the count for the limit set by the user
                int count = 0;
                Console.WriteLine("");
                //For loop to increment the value of the number in series
                for (int i = 1; i < n; i++)
                {
                    //For loop to print the number as many times as its value
                    for (int j = 0; j < i; j++)
                    {
                        count++;

                        Console.Write(" " + i);
                        if (count == n)
                        {
                            return;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }
        public static void printTriangle(int n)
        {
            try
            {
                //Initialize the varibles for sum, output string and end of line detection
                int sum = 1;
                String str = null, endL = "\n";
                Console.WriteLine("");
                //Value for number of stars in the triangle
                sum = (2 * n - 1);
                //Loop to print the stars in inverted triangle fashion
                for (int i = sum; i > 0; i--)
                {

                    str = str + "*";
                    //Set the cursor position to the centre while aligning the stars in centre
                    Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop);
                    //Printing the stars
                    if (str.Length == sum)
                    {
                        Console.Write(str);
                        i = sum;
                        sum = sum - 2;
                        str = null;
                        Console.Write(endL);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }
        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                //Initialize the count for the number of Jewels in the set of stones
                int count = 0;
                Console.WriteLine("");
                //For loops to compare the stones and the jewel set
                for (int i = 0; i < J.Length; i++)
                {
                    for (int k = 0; k < S.Length; k++)
                    {
                        //Compare the sets
                        if (J[i] == S[k])
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }
            return 0;
        }
        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            try
            {
                //Initialize the two-dimensional array to store the contigious arrays
                int[,] resultSet = new int[10, 10];
                int[] temp = new int[20], temp2 = new int[20];
                try
                {
                    //Initialize the indexes to keep track of the positions in two input arrays
                    int indx1 = 1, indx2 = 1, max = 0, acount = 0, bcount = 1;
                    if (indx1 > indx2)
                    {
                        max = a.Length;
                    }
                    else
                    {
                        max = b.Length;
                    }
                    for (int i = 1; i < 100; i++)
                    {
                        //Check if previous values of two arrays are not equal and current values are
                        if (a[indx1 - 1] != b[indx2 - 1] && a[indx1] == b[indx2])
                        {
                            acount++;
                        }
                        //Storing arrays in the 2d array
                        if (a[indx1 - 1] == b[indx2 - 1] && a[indx1] == b[indx2] && a[indx1 - 1] == a[indx1] - 1)
                        {
                            resultSet[acount, bcount - 1] = a[indx1 - 1];
                            resultSet[acount, bcount] = a[indx1];
                            indx1++;
                            indx2++;
                            bcount++;
                        }
                        //Increase the count value of the array containing smaller valued number
                        else if (a[indx1] > b[indx2])
                        {
                            indx2++;
                        }
                        else if (a[indx1] < b[indx2])
                        {
                            indx1++;

                        }
                        else
                        {
                            indx1++;
                            indx2++;
                        }

                    }

                }
                catch
                {
                    //Catch the end of array exception.
                    //Eliminate the unnecessary values in 2d array
                    for (int i = 0; i < 10; i++)
                    {
                        int count = 0;
                        for (int j = 0; j < 10; j++)
                        {
                            if (resultSet[i, j] != 0)
                            {
                                count++;
                            }
                        }
                        temp[i] = count;
                    }
                    //Find the max length array in 2d array
                    int maxValue = temp.Max();
                    int maxIndex = temp.ToList().IndexOf(maxValue);
                    for (int i = 0; i < 10; i++)
                    {
                        if (resultSet[maxIndex, i] != 0)
                        {
                            temp2[i] = resultSet[maxIndex, i];
                        }
                    }
                }
                return temp2;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }
            return null; // return the actual array
        }
        //Display the array for Problem 5
        public static void displayArray(int[] a)
        {
            for (int i = 0; i < 10; i++)
            {
                if (a[i] != 0)
                {
                    Console.Write(a[i] + " ");
                }
            }
        }
        public static void solvePuzzle()
        {
            try
            {
                //Initialize the variables and assign random negative values.
                int uber = -3, cool = -5, uncle = -1;
                Console.WriteLine("");
                //Initialize for loops to check all the permutations for the equation.
                for (int u = 0; u < 10; u++)
                {
                    for (int b = 0; b < 10; b++)
                    {
                        for (int e = 0; e < 10; e++)
                        {
                            for (int r = 0; r < 10; r++)
                            {
                                for (int c = 0; c < 10; c++)
                                {
                                    for (int o = 0; o < 10; o++)
                                    {
                                        for (int l = 0; l < 10; l++)
                                        {
                                            for (int n = 0; n < 10; n++)
                                            {
                                                //Assign the digits to the characters
                                                uber = u * 1000 + b * 100 + e * 10 + r;
                                                cool = c * 1000 + o * 100 + o * 10 + l;
                                                uncle = u * 10000 + n * 1000 + c * 100 + l * 10 + e;
                                                if (uber + cool == uncle)
                                                {
                                                    //Check for uniqueness
                                                    int[] dis = { u, b, e, r, c, o, l, n };
                                                    if (dis.ToArray().Distinct().Count() == 8)
                                                    {
                                                        if (uber > 999 && uncle > 9999 && cool > 999)
                                                        {
                                                            //Display the result
                                                            Console.WriteLine("The solution is :" + " " + uber + " " + " " + cool + " " + uncle + " ");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
            }
        }
    }
}
/* Self- reflection: The Assignment was fun to do and I learnt a great deal from this assignment. The first 2 were easy, next 2 being a little challenging and finally the last 2 were difficult ones.
   The things that I learnt were how to implement logic into the code, and also about some features and functions of .Net and Visual Studio (eg. the LinQ library).*/

