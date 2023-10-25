using static System.Linq.Enumerable;
using static System.Math;
using static System.String;
using System.Text;

namespace Cours01
{
    public static class Exercises01
    {
        /// <summary>
        /// Determines if a given integer is an even number.
        /// </summary>
        /// <param name="number">The integer to check for parity.</param>
        /// <returns>True if the number is even, false otherwise.</returns>
        public static bool IsEven(int number)
        {
            return (number % 2) == 0;
        }

        /// <summary>
        /// Converts a temperature in Celsius degrees to Fahrenheit degrees.
        /// Ensure the temperature is above -271.15°C (absolute zero).
        /// Max precision is 2 decimals
        /// </summary>
        /// <param name="celsius">Temperature in Celsius degrees.</param>
        /// <returns>The temperature in Fahrenheit with a formatted result, or an error message for invalid input.</returns>
        public static string CelsiusToFahrenheit(double celsius)
        {
            if (celsius < -271.15)
            {
                return "Temperature below absolute zero!";
            }
            double result = (celsius * 9/5) + 32;
            return (result % 1) == 0 ? $"T = {result:#}F" : $"T = {result:0.00}F";
        }

        /// <summary>
        /// Determines whether an array of POSITIVE integers is sorted in ascending order.
        /// </summary>
        /// <param name="arr">The array of integers to check.</param>
        /// <returns>True if the array is sorted in ascending order, false otherwise.</returns>
        public static bool IsSortedAscending(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return false;
            }
            
            bool returnValue = true;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i+1 < arr.Length && Abs(arr[i]) > Abs(arr[i+1]))
                {
                    returnValue = false;
                    break;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Draws 3 Christmas tree shapes using asterisks.
        /// </summary>
        /// <returns>A string representing the Christmas tree shape.</returns>
        public static string DrawChristmasTree()
        {
            const int branchesNumber = 7;
            const int floorsNumber = 3;

            StringBuilder sb = new StringBuilder();

            for (int i = 0 ; i < floorsNumber ; i++)
            {
                for (int j = 3, k = 1 ; j >= 0 && k <= branchesNumber ; j--, k+=2)
                {
                    sb.AppendFormat(
                        "{0}{1}{2}\n",
                        Join(string.Empty, Repeat(" ", j)),
                        Join(string.Empty, Repeat("*", k)),
                        Join(string.Empty, Repeat(" ", branchesNumber-j))
                    );
                }
            }
            return sb.ToString();
        }
    }
}
