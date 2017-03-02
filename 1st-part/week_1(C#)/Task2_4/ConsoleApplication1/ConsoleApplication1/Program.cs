﻿using System;
using System.Collections;
namespace Arrays
{

        class MainClass
        {
            const int Row = 5;
            const int Column = 8;
            static Random random = new Random();
            static int[] FillArray(int[] arrayToFill)
            {
                // fills array a random nmb
                for (int i = 0; i < 10; i++)
                {
                    arrayToFill[i] = random.Next(-500, 500);
                }
                return arrayToFill;
            }
            static int[,] FillArray(int[,] arrayToFill)
            {
                // fills matrix a random nmb
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Column; j++)
                    {
                        arrayToFill[i, j] = random.Next(-500, 500);
                    }
                }
                return arrayToFill;
            }
            static void ShowArray(int[] arrayToShow)
            {
                // to show a array
                for (int i = 0; i < arrayToShow.Length; i++)
                {
                    Console.Write("{0} ", arrayToShow[i]);
                }
            }
            static void ShowArray(int[,] arrayToShow)
            {
                // to show a matrix
                int[] colSum = new int[Column];
                Console.Write("Sum: ");
                for (int j = 0; j < Column; j++)
                {
                    for (int i = 0; i < Row; i++)
                        colSum[j] += arrayToShow[i, j];
                    Console.Write("{0,3} {1,5}", "|", colSum[j]);
                }
                Console.WriteLine("\n");
                for (int i = 0; i < arrayToShow.GetLength(0); ++i)
                {
                    Console.Write("{0,5}", " ");
                    for (int j = 0; j < arrayToShow.GetLength(1); ++j)
                    {
                        Console.Write("{0,3} {1,5}", "|", arrayToShow[i, j]);
                    }
                    Console.WriteLine();
                }
            }
         
            static int[,] MatrixSort(int[,] matrixToSort)
            {
                // sorts the matrix by sum of columns
                int[] colSum = new int[Column];
                for (int j = 0; j < Column; j++)
                {
                    for (int i = 0; i < Row; i++)
                        colSum[j] += matrixToSort[i, j];
                }
                for (int j = 0; j < Column - 1; j++)
                {
                    for (int i = 0; i < (Column - j - 1); i++)
                    {
                        if (colSum[i] > colSum[i + 1])
                        {
                            int tmp = colSum[i];
                            colSum[i] = colSum[i + 1];
                            colSum[i + 1] = tmp;
                            for (int k = 0; k < Row; k++)
                            {
                                int tmpMatrix = matrixToSort[k, i];
                                matrixToSort[k, i] = matrixToSort[k, i + 1];
                                matrixToSort[k, i + 1] = tmpMatrix;
                            }
                        }
                    }
                }
                return matrixToSort;
            }
           
            static void Matrix()
            {
                int[,] myMatrix = new int[Row, Column];
                myMatrix = FillArray(myMatrix);
                Console.WriteLine("Before sorting:");
                ShowArray(myMatrix);
                Console.WriteLine("After sorting");
                Console.ResetColor();
                myMatrix = MatrixSort(myMatrix);
                ShowArray(myMatrix);
            }
         
            public static void Main(string[] args)
            {
                Matrix();

                Console.ReadKey();
            }
        }
    }
