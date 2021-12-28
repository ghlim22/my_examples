using System;

namespace binary_search_recursive
{
    class Program
    {
        public static int BinarySearchRecursive(int[] arr, int low, int high, int key)
        {
            if (low <= high)
            {
                int middle = (high + low) / 2;
                if (arr[middle] > key)
                {
                    return BinarySearchRecursive(arr, low, middle - 1, key);
                }
                else if (arr[middle] < key)
                {
                    return BinarySearchRecursive(arr, middle + 1, high, key);
                }
                else if (arr[middle] == key)
                {
                    return middle;
                }
            }
            return -1;
        }

        public static void PrintArray(int[] arr)
        {
            int index = 0;
            foreach (var e in arr)
            {
                index++;
                Console.Write("{0, 5}{1}", e, (index % 10 == 0) ? "\n":"");
            }
        }

        public static void SortArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[i] > arr[j])
                    {
                        arr[i] ^= arr[j];
                        arr[j] ^= arr[i];
                        arr[i] ^= arr[j];
                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            Random random = new Random();
            const int MAX = 100;
            int[] numbers = new int[MAX];
            for (int i = 0; i < MAX; ++i)
            {
                numbers[i] = random.Next(0, 1001);
            }
            Console.WriteLine("Array before sort:");
            PrintArray(numbers);
            SortArray(ref numbers);
            Console.WriteLine("Array after sort:");
            PrintArray(numbers);

            Console.WriteLine("Enter number you want to search.");
            string? userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int key))
            {
                int index = BinarySearchRecursive(numbers, numbers.GetLowerBound(0), numbers.GetUpperBound(0), key);
                if (index == -1)
                {
                    Console.WriteLine("There's no value you find.");
                    return;
                }
                Console.WriteLine($"Key: {key}\nIndex: {index}\nValue: {numbers[index]}");
            }
            else
            {
                Console.WriteLine("Wrong Input.");
            }
        }
    }
}
