using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 8;
            int[] arr1 = new int[n];
            for (int i = 0; i < n; i++) arr1[i] = n - i;
            int[] arr2 = {  8, 0, 2, 2, 1, 0, 0, 0 };
            int[] arr3 = {  7, 8, 1, 3, 0, 0, 0, 0 };
            DrawHanoi(n, arr1, arr2, arr3);
        }
        
        static void DrawHanoi(int n,int[] A,int[] B, int[] C)
        {
            for(int i=-1;i<n;i++)
            {
                for (int j = -n; j <= n; j++)
                {
                    if (i == -1)
                    {
                        Console.Write(j == 0 ? "|" : " ");
                        continue;
                    } 
                    if (j < 0) Console.Write((j + A[n - i - 1] >= 0) ? "*" : " ");
                    else if (j == 0) Console.Write("|");
                    else Console.Write((j - A[n - i - 1] <= 0) ? "*" : " ");
                }
                Console.Write("  ");

                for (int j = -n; j <= n; j++)
                {
                    if (i == -1)
                    {
                        Console.Write(j == 0 ? "|" : " ");
                        continue;
                    }
                    if (j < 0) Console.Write((j + B[n - i - 1] >= 0) ? "*" : " ");
                    else if (j == 0) Console.Write("|");
                    else Console.Write((j - B[n - i - 1] <= 0) ? "*" : " ");
                }
                Console.Write("  ");

                for (int j = -n; j <= n; j++)
                {
                    if (i == -1)
                    {
                        Console.Write(j == 0 ? "|" : " ");
                        continue;
                    }
                    if (j < 0) Console.Write((j + C[n - i - 1] >= 0) ? "*" : " ");
                    else if (j == 0) Console.Write("|");
                    else Console.Write((j - C[n - i - 1] <= 0) ? "*" : " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
