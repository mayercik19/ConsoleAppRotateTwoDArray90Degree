using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRotateTwoDArray90Degree
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SIZE = 15; // length for each demension
            int[,] myArray = new int[SIZE, SIZE];
            int[,] myArrayCopy = new int[SIZE, SIZE];

            // ini arrays with numbers
            int num = 0;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    myArray[i, j] = num++;
                    myArrayCopy[i, j] = myArray[i, j]; // copy for dispalying to compare with rotated array
                }
            }

            // rotate myArray 90 degree. 
            // Move SIZE * SIZE elements to new positions.

            // choose target myArray[0, SIZE - 1] to start with.
            // save this target value
            int savedIndexI = 0, savedIndexJ = SIZE - 1;
            int savedElementValue = myArray[savedIndexI, savedIndexJ];
            int targetIndexI = savedIndexI, targetIndexJ = savedIndexJ;

            for (int n = 0; n < SIZE * SIZE; n++)
            {
                int sourceIndexI = (SIZE - 1) - targetIndexJ;
                int sourceIndexJ = targetIndexI;

                if (sourceIndexI == savedIndexI && sourceIndexJ == savedIndexJ)
                {
                    myArray[targetIndexI, targetIndexJ] = savedElementValue;

                    if (savedIndexJ - savedIndexI > 1)
                    {
                        savedIndexJ--;
                        savedElementValue = myArray[savedIndexI, savedIndexJ];

                        targetIndexI = savedIndexI;
                        targetIndexJ = savedIndexJ;
                    }
                    else
                    {
                        if (n == (SIZE * SIZE - 2) && (SIZE % 2 != 0))
                        {
                            break;
                        }
                        else
                        {
                            savedIndexI++;
                            savedIndexJ = SIZE - 1 - savedIndexI;

                            savedElementValue = myArray[savedIndexI, savedIndexJ];

                            targetIndexI = savedIndexI;
                            targetIndexJ = savedIndexJ;
                        }
                    }
                }
                else
                {
                    myArray[targetIndexI, targetIndexJ] = myArray[sourceIndexI, sourceIndexJ];

                    targetIndexI = sourceIndexI;
                    targetIndexJ = sourceIndexJ;
                }
            }

            // output resuts: orinial and rotated arrays
            Console.WriteLine(@"Rotate two demision array {0} x {1} 90 degree : ", SIZE, SIZE);
            for (int i = 0; i < SIZE; i++)
            {
                StringBuilder lineOutput = new StringBuilder("");
                for (int j = 0; j < SIZE; j++)
                {
                    lineOutput.Append(myArrayCopy[i, j].ToString().PadLeft(4) + "  ");
                }
                lineOutput.Append("  |  ");
                for (int j = 0; j < SIZE; j++)
                {
                    lineOutput.Append(myArray[i, j].ToString().PadLeft(4) + "  ");
                }
                Console.WriteLine(lineOutput);
            }
            Console.ReadLine();
        }
    }
}
