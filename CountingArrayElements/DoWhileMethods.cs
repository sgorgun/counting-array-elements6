﻿using System;

namespace CountingArrayElements
{
    public static class DoWhileMethods
    {
        /// <summary>
        /// Searches an array of booleans for false elements, and returns the number of occurrences of false values.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of false values.</returns>
        public static int GetFalseValueCount(bool[]? arrayToSearch)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            int counter = 0;
            int index = 0;
            do
            {
                if (!arrayToSearch[index])
                {
                    counter++;
                }

                index++;
            }
            while (index < arrayToSearch.Length);

            return counter;
        }

        /// <summary>
        /// Searches an array of decimal floating-point numbers for zero elements, and returns the number of occurrences of zero values.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of zero values.</returns>
        public static int GetZeroDecimalCount(decimal[]? arrayToSearch)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            int counter = 0;
            int index = 0;
            do
            {
                if (arrayToSearch[index] == 0)
                {
                    counter++;
                }

                index++;
            }
            while (index < arrayToSearch.Length);

            return counter;
        }

        /// <summary>
        /// Searches an array of double-precision floating-point numbers for elements that can be rounded to even, and returns the number of occurrences of numbers that can be rounded to even.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of numbers that can be rounded to even.</returns>
        public static int GetRoundedToEvenCount(double[]? arrayToSearch)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            int counter = 0;
            int index = 0;
            do
            {
                if (Math.Round(arrayToSearch[index]) % 2 == 0)
                {
                    counter++;
                }

                index++;
            }
            while (index < arrayToSearch.Length);

            return counter;
        }

        /// <summary>
        /// Searches an array of booleans for false elements, and returns the number of occurrences of false values.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of false values.</returns>
        public static int GetFalseValueCountRecursive(bool[]? arrayToSearch)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            return GetFalseValueCountRecursive(arrayToSearch, arrayToSearch.Length, 0);
        }

        /// <summary>
        /// Searches an array of decimal floating-point numbers for zero elements, and returns the number of occurrences of zero values.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of zero values.</returns>
        public static int GetZeroDecimalCountRecursive(decimal[]? arrayToSearch)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            int middleIndex = arrayToSearch.Length / 2;
            decimal[] leftArrayToSearch = arrayToSearch[..middleIndex];
            decimal[] rightArrayToSearch = arrayToSearch[middleIndex..];

            int leftArrayCount = GetZeroDecimalCountRecursive(leftArrayToSearch, 0);
            int rightArrayCount = GetZeroDecimalCountRecursive(rightArrayToSearch, 0);

            return leftArrayCount + rightArrayCount;
        }

        /// <summary>
        /// Searches an array of double-precision floating-point numbers for elements that can be rounded to even, and returns the number of occurrences of numbers that can be rounded to even.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of numbers that can be rounded to even.</returns>
        public static int GetRoundedToEvenCountRecursive(double[]? arrayToSearch)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            static int ProcessArray(double[] array)
            {
                if (array.Length <= 0)
                {
                    return 0;
                }

                double currentElement = array[0];
                int currentIncrement = 0;
                bool isElementNearEvenNumber = (Math.Round(currentElement, MidpointRounding.ToEven) % 2) == 0;

                if (isElementNearEvenNumber)
                {
                    currentIncrement++;
                }

                if (array.Length > 1)
                {
                    return GetRoundedToEvenCountRecursive(array[1..]) + currentIncrement;
                }

                return currentIncrement;
            }

            static int GetRoundedToEvenCountRecursive(double[] array)
            {
                if (array.Length == 0)
                {
                    return 0;
                }

                int middleIndex = array.Length / 2;
                double[] leftArrayToSearch = array[..middleIndex];
                double[] rightArrayToSearch = array[middleIndex..];

                return ProcessArray(leftArrayToSearch) + ProcessArray(rightArrayToSearch);
            }

            return GetRoundedToEvenCountRecursive(arrayToSearch);
        }

        private static int GetFalseValueCountRecursive(bool[] arrayToSearch, int elementsLeft, int accumulator)
        {
            if (elementsLeft > 0)
            {
                accumulator = !arrayToSearch[^elementsLeft] ? ++accumulator : accumulator;
                return GetFalseValueCountRecursive(arrayToSearch, --elementsLeft, accumulator);
            }

            return accumulator;
        }

        private static int GetZeroDecimalCountRecursive(decimal[] arrayToSearch, int accumulator)
        {
            if (arrayToSearch.Length == 0)
            {
                return accumulator;
            }

            if (arrayToSearch[0] == decimal.Zero)
            {
                accumulator++;
            }

            return GetZeroDecimalCountRecursive(arrayToSearch[1..], accumulator);
        }
    }
}
