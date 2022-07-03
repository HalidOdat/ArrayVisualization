using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    /// <summary>
    ///  Class that contains some utility static methods.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        ///     Clamps a value to a given range `[min, max]`.
        /// </summary>
        /// <typeparam name="T">Any type that implement the IComperable<T> interface.</typeparam>
        /// <param name="value">The value that is to be clamped to the given range.</param>
        /// <param name="min">The minimum value in the range.</param>
        /// <param name="max">The minimum value in the range.</param>
        /// <returns>Returns the clamped value.</returns>
        public static T Clamp<T>(T value, T min, T max)
            where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            else if (value.CompareTo(max) > 0) return max;
            else return value;
        }


        /// <summary>
        /// This function will take an HSL value in the ranges of 0-1 and return a color object.  I use this function all the time.
        /// Given H,S,L in range of 0-1
        /// Returns a Color (RGB struct) in range of 0-255
        /// </summary>
        public static Color HSL2RGB(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);

            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            return Color.FromArgb(Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
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
