using System;

namespace TrappingRainWater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rain Water Trapping!");
            Console.WriteLine("-------------------");

            Console.WriteLine("Enter the number of elements in the array");
            try
            {
                int noElements = int.Parse(Console.ReadLine());
                int[] array = new int[noElements];
                Console.WriteLine("Enter the elements separated by space");
                String[] elements = Console.ReadLine().Split(' ');
                for (int i = 0; i < noElements; i++) {
                    array[i] = int.Parse(elements[i]);
                }
                Console.WriteLine("Collected rain water is "+GetRainWater(array) +"units.");
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }


            Console.ReadLine();
        }

        private static int GetRainWater(int[] array) {
            int result = 0;
            //O(n) space for precomputing results
            int[] left = new int[array.Length];
            int[] right = new int[array.Length];

            left[0] = array[0];
            right[array.Length-1] = array[array.Length-1];

            //Precomputing left and right max bars
            for (int i = 1; i< array.Length; i++){
                left[i] = Math.Max(left[i-1], array[i]);
            }


            for (int i = array.Length-2; i >=0; i--)
            {
                right[i] = Math.Max(right[i + 1], array[i]);
            }


            //Calculate water that every bar can hold
            for (int i = 0; i < array.Length; i++) {
                result += (Math.Min(left[i], right[i])) - array[i];
            }

            return result;
        }
    }
}
