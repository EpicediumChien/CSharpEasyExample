using System.Collections.Generic;
using System;

class MatrixLayerRotation
{

    /*
     * Complete the 'matrixRotation' function below.
     *
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY matrix
     *  2. INTEGER r
     */

    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        int rowCount = matrix.Count;
        int columnCount = matrix[0].Count;

        int layers = Math.Min(rowCount, columnCount) / 2;
        for (int l = 0; l < layers; l++)
        {
            List<int> layer = new List<int>();
            for (int i = l; i < columnCount - l; i++) layer.Add(matrix[l][i]);
            for (int i = l + 1; i < rowCount - l; i++) layer.Add(matrix[i][columnCount - l - 1]);
            for (int i = columnCount - l - 2; i >= l; i--) layer.Add(matrix[rowCount - l - 1][i]);
            for (int i = rowCount - l - 2; i > l; i--) layer.Add(matrix[i][l]);

            int r_eff = r % layer.Count;

            RotateList(layer, r_eff);

            int index = 0;

            for (int i = l; i < columnCount - l; i++) matrix[l][i] = layer[index++];
            for (int i = l + 1; i < rowCount - l; i++) matrix[i][columnCount - l - 1] = layer[index++];
            for (int i = columnCount - l - 2; i >= l; i--) matrix[rowCount - l - 1][i] = layer[index++];
            for (int i = rowCount - l - 2; i > l; i--) matrix[i][l] = layer[index++];
        }

        foreach (List<int> row in matrix)
        {
            foreach (int element in row)
            {
                Console.Write($"{element} ");
            }
            Console.Write("\n");
        }
    }

    private static void RotateList(List<int> list, int r)
    {
        int len = list.Count;

        ReverseList(list, 0, r - 1);
        ReverseList(list, r, len - 1);
        ReverseList(list, 0, len - 1);
    }

    private static void ReverseList(List<int> list, int start, int end)
    {
        while (start < end)
        {
            int temp = list[start];
            list[start] = list[end];
            list[end] = temp;
            start++;
            end--;
        }
    }
}