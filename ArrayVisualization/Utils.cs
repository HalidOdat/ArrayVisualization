using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    /// <summary>
    ///  An extension class that implements the `Clamp` function
    /// </summary>
    public static class ClampExtension
    {
        /// <summary>
        ///     Clamps a value to a given range `[min, max]`.
        /// </summary>
        /// <typeparam name="T">Any type that implement the IComperable<T> interface.</typeparam>
        /// <param name="value">The value that is to be clamped to the given range.</param>
        /// <param name="min">The minimum value in the range.</param>
        /// <param name="max">The minimum value in the range.</param>
        /// <returns>Returns the clamped value.</returns>
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            else if (value.CompareTo(max) > 0) return max;
            else return value;
        }
    }

    /// <summary>
    /// This is an extenstion on the random class, that implments the `Shuffle` method.
    /// </summary>
    static class RandomExtensions
    {
        /// <summary>
        /// Shuffles the array list.
        /// </summary>
        /// <typeparam name="T">Any type T</typeparam>
        /// <param name="rng">the Random class instance</param>
        /// <param name="array">The array to be shuffled</param>
        public static void Shuffle<T>(this Random rng, List<T> array)
        {
            int n = array.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
