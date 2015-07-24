using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaDelivery
{
    class Program
    {
        static int rows, columns;

        static int[] rowCost;
        static int[] columnCost;

        static void Main(string[] args)
        {
            int cases = Convert.ToInt32(Console.ReadLine());

            for (int iter = 0; iter < cases; iter++)
            {
                string[] rowCols = Console.ReadLine().Split(new char[0]);

                rows = Convert.ToInt32(rowCols[0]);
                columns = Convert.ToInt32(rowCols[1]);

                rowCost = new int[rows];
                columnCost = new int[columns];

                // read the input
                for (int i = 0; i < columns; i++)
                {
                    string[] costStr = Console.ReadLine().Split(new char[0]);

                    int sum = 0;

                    for (int j = 0; j < rows; j++)
                    {
                        int cost = Convert.ToInt32(costStr[j]);
                        rowCost[j] += cost;
                        sum += cost;
                    }

                    columnCost[i] = sum;
                }

                int deliveryCostFinal = 0;
                findBest(out deliveryCostFinal);

                Console.WriteLine("{0} blocks", deliveryCostFinal);
            
            }

            // debug
            //Console.ReadLine();

        }

        static private void findBest(out int deliveryCostFinal)
        {
            int rowIndex, colIndex, rowIndexCost, colIndexCost;
            findBestIndex(rowCost, out rowIndex, out rowIndexCost);

            findBestIndex(columnCost, out colIndex, out colIndexCost);

            deliveryCostFinal = rowIndexCost + colIndexCost;
        }

        static private void findBestIndex(int[] vector, out int index, out int bestCostUntil)
        {
            index = 0;
            bestCostUntil = Int32.MaxValue;

            for (int i = 0; i < vector.Length; i++)
            {
                int cost = 0;

                for (int j = 0; j < vector.Length; j++)
                {
                    cost += Math.Abs(i - j) * vector[j];
                }

                if (cost < bestCostUntil)
                {
                    index = i;
                    bestCostUntil = cost;
                }
            }
        
        }


    }
}
