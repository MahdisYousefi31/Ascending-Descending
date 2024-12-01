using System;

class Program
{
    static void Main()
    {
        int[] array = { 5, 3, 8, 6, 2, 7, 4, 1 };

        Console.WriteLine("Original Array:");
        PrintArray(array);

        Console.WriteLine("\nMerge Sort Ascending:");
        int[] mergeSortedAsc = (int[])array.Clone();
        MergeSort(mergeSortedAsc, 0, mergeSortedAsc.Length - 1, true);
        PrintArray(mergeSortedAsc);

        Console.WriteLine("\nMerge Sort Descending:");
        int[] mergeSortedDesc = (int[])array.Clone();
        MergeSort(mergeSortedDesc, 0, mergeSortedDesc.Length - 1, false);
        PrintArray(mergeSortedDesc);

        Console.WriteLine("\nInsertion Sort Ascending:");
        int[] insertionSortedAsc = (int[])array.Clone();
        InsertionSort(insertionSortedAsc, true);
        PrintArray(insertionSortedAsc);

        Console.WriteLine("\nInsertion Sort Descending:");
        int[] insertionSortedDesc = (int[])array.Clone();
        InsertionSort(insertionSortedDesc, false);
        PrintArray(insertionSortedDesc);

        Console.WriteLine("\nSelection Sort Ascending:");
        int[] selectionSortedAsc = (int[])array.Clone();
        SelectionSort(selectionSortedAsc, true);
        PrintArray(selectionSortedAsc);

        Console.WriteLine("\nSelection Sort Descending:");
        int[] selectionSortedDesc = (int[])array.Clone();
        SelectionSort(selectionSortedDesc, false);
        PrintArray(selectionSortedDesc);

        Console.WriteLine("\nBubble Sort Ascending:");
        int[] bubbleSortedAsc = (int[])array.Clone();
        BubbleSort(bubbleSortedAsc, true);
        PrintArray(bubbleSortedAsc);

        Console.WriteLine("\nBubble Sort Descending:");
        int[] bubbleSortedDesc = (int[])array.Clone();
        BubbleSort(bubbleSortedDesc, false);
        PrintArray(bubbleSortedDesc);
    }

    static void MergeSort(int[] array, int left, int right, bool ascending)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(array, left, mid, ascending);
            MergeSort(array, mid + 1, right, ascending);
            Merge(array, left, mid, right, ascending);
        }
    }

    static void Merge(int[] array, int left, int mid, int right, bool ascending)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(array, left, L, 0, n1);
        Array.Copy(array, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if ((ascending && L[i] <= R[j]) || (!ascending && L[i] >= R[j]))
                array[k++] = L[i++];
            else
                array[k++] = R[j++];
        }

        while (i < n1)
            array[k++] = L[i++];

        while (j < n2)
            array[k++] = R[j++];
    }

    static void InsertionSort(int[] array, bool ascending)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && ((ascending && array[j] > key) || (!ascending && array[j] < key)))
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }

    static void SelectionSort(int[] array, bool ascending)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int index = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if ((ascending && array[j] < array[index]) || (!ascending && array[j] > array[index]))
                    index = j;
            }

            int temp = array[index];
            array[index] = array[i];
            array[i] = temp;
        }
    }

    static void BubbleSort(int[] array, bool ascending)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if ((ascending && array[j] > array[j + 1]) || (!ascending && array[j] < array[j + 1]))
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    static void PrintArray(int[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }
}
