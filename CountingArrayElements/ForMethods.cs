using System;

namespace CountingArrayElements
{
    public static class ForMethods
    {
        /// <summary>
        /// Searches an array of integers for negative elements, and returns the number of occurrences of negative integers.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of negative integers.</returns>
        public static int GetNegativeIntegerCount(int[] arrayToSearch)
        {
            // TODO #1. Analyze the implementation of "GetNegativeIntegerCountRecursive" methods, and implement the method using the "for" loop statement.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches an array of single-precision floating-point numbers for even elements, and returns the number of occurrences of even numbers.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of even numbers.</returns>
        public static int GetEvenNumberCount(float[] arrayToSearch)
        {
            // TODO #2. Analyze the implementation of "GetEvenNumberCountRecursive" methods, and implement the method using the "for" loop statement.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches an array of bytes for elements with enabled bits in high nibble, and returns the number of occurrences of bytes with enabled bits in high nibble.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of bytes with enabled bits in high nibble.</returns>
        public static int GetByteWithBitsInHighNibbleCount(byte[] arrayToSearch)
        {
            // TODO #3. Analyze the implementation of "GetByteWithBitsInHighNibbleCountRecursive" methods, and implement the method using the "for" loop statement.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches an array of integers for negative elements, and returns the number of occurrences of negative integers.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of negative integers.</returns>
        public static int GetNegativeIntegerCountRecursive(int[] arrayToSearch)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            return GetNegativeIntegerCountRecursive(arrayToSearch, 0);
        }

        /// <summary>
        /// Searches an array of single-precision floating-point numbers for even elements, and returns the number of occurrences of even numbers.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of even numbers.</returns>
        public static int GetEvenNumberCountRecursive(float[] arrayToSearch)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            int currentIncrement = arrayToSearch[0] % 2 == 0 ? 1 : 0;
            return GetEvenNumberCountRecursive(arrayToSearch[1..]) + currentIncrement;
        }

        /// <summary>
        /// Searches an array of bytes for elements with enabled bits in high nibble, and returns the number of occurrences of bytes with enabled bits in high nibble.
        /// </summary>
        /// <param name="arrayToSearch">An <see cref="Array"/> to search.</param>
        /// <returns>The number of occurrences of bytes with enabled bits in high nibble.</returns>
        public static int GetByteWithBitsInHighNibbleCountRecursive(byte[] arrayToSearch)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            return GetByteWithBitsInHighNibbleCountRecursive(arrayToSearch, arrayToSearch.Length - 1, 0);
        }

        private static int GetNegativeIntegerCountRecursive(int[] arrayToSearch, int index)
        {
            if (index >= arrayToSearch.Length)
            {
                return 0;
            }

            int currentIncrement = arrayToSearch[index] < 0 ? 1 : 0;
            return GetNegativeIntegerCountRecursive(arrayToSearch, index + 1) + currentIncrement;
        }

        private static int GetByteWithBitsInHighNibbleCountRecursive(byte[] arrayToSearch, int index, int accumulator)
        {
            if (index < 0)
            {
                return accumulator;
            }

            int currentAccumulator = (arrayToSearch[index] & 0xF0) > 0 ? accumulator + 1 : accumulator;
            return GetByteWithBitsInHighNibbleCountRecursive(arrayToSearch, index - 1, currentAccumulator);
        }
    }
}
