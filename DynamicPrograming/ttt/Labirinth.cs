using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPrograming
{
    public static class Labirinth
    {
        static int[,] labirinth =
        {

            { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 1, 1, 0, 0, 1 },
            { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 1, 0, 0, 0, 1, 0, 0, 1 },
            { 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 },
        };
        static int[] direction = new int[labirinth.GetLength(0) * labirinth.GetLength(1)];
        static int position = 0;   
        public static void Print()
        {
            for (int row = 0; row < labirinth.GetLength(0); row++)
            {
                for (int col = 0; col < labirinth.GetLength(1); col++)
                {   
                    //if(labirinth[row, col]!=0)
                    Console.Write(labirinth[row,col] +",");
                }
                Console.WriteLine();

            }
            Console.ReadKey();
        }
        public static void Findpath(int row,int col,char dir)
        {
            if ((col < 0 || (row < 0) || (col >= labirinth.GetLength(1)) || (row >= labirinth.GetLength(0))))
            {

                //Console.WriteLine("Out of labirinth");

                return;
            }
                direction[position] = dir;
                position++;

            if (labirinth[row, col] == 2)
            {
                PrintPath(direction, 1, position - 1);
            }

               
            if (labirinth[row, col] != 0)
            {
                //Console.WriteLine("The cell is blocked");

            }
            if (labirinth[row, col] == 0) //The current cell is free
            {
                labirinth[row, col] ='Y';

                Findpath(row, col - 1, 'L');//left 
                Findpath(row - 1, col,'U');//up
                Findpath(row, col + 1,'R');//right
                Findpath(row + 1, col,'D');//down

            }

            position--;
        }
        public static void PrintPath(int[] numDir, int start, int end)
        {
            Console.WriteLine("Found path to the exit");
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(numDir[i]);
            }
        }




    }
}
