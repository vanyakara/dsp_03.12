using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public interface SortingStrategy
    {
        int Sort(int[] array);
    }
    public class BubbleSort : SortingStrategy
    {
        public int Sort(int[] array)
        {
            int swaps = 0;
            for(int i = 0; i < array.Length - 1; i++)
            {
                for(int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swaps++;
                    }
                }
            }
            return swaps;
        }
    }
    public class InsertionSort : SortingStrategy
    {
        public int Sort(int[] array)
        {
            int swaps = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                    swaps++;
                }
                array[j + 1] = key;
            }
            return swaps;
        }
    }
    public class SelectionSort : SortingStrategy
    {
        public int Sort(int[] array)
        {
            int swaps = 0;
            for(int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for(int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                    swaps++;
                }
            }
            return swaps;
        }
    }
    public class SortContext
    {
        private SortingStrategy strategy;
        public void SetStrategy(SortingStrategy strategy)
        {
            this.strategy = strategy;
        }
        public int ExecuteStrategy(int[] array)
        {
            return strategy.Sort(array);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 2, 9, 1, 5, 6 };
            int[] copy;
            SortContext context = new SortContext();
            Console.WriteLine("Choose Sort Method (1. Bubble Sort, 2. Insertion Sort, 3. Selection Sort): ");
            int sw = Int32.Parse(Console.ReadLine());
            switch (sw)
            {
                case 1:
                    copy = (int[])array.Clone();
                    context.SetStrategy(new BubbleSort());
                    int bubbleSwaps = context.ExecuteStrategy(copy);
                    Console.WriteLine($"Bubble Sort: {string.Join(", ", copy)} | Swaps: {bubbleSwaps}");
                    break;
                case 2:
                    copy = (int[])array.Clone();
                    context.SetStrategy(new InsertionSort());
                    int insertionSwaps = context.ExecuteStrategy(copy);
                    Console.WriteLine($"Insertion Sort: {string.Join(", ", copy)} | Swaps: {insertionSwaps}");
                    break;
                case 3:
                    copy = (int[])array.Clone();
                    context.SetStrategy(new SelectionSort());
                    int selectionSwaps = context.ExecuteStrategy(copy);
                    Console.WriteLine($"Selection Sort: {string.Join(", ", copy)} | Swaps: {selectionSwaps}");
                    break;
            }
            Console.ReadLine();
        }
    }
}
