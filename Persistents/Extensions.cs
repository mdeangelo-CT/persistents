using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistents
{
    static class Extensions
    {
        public static T[] SubArray<T>(this T[] array, int startIndex, int length)
        {
            int endIndex = startIndex + length;
            if (array.Length <= endIndex)
                throw new ArgumentException("The sub array cannot exceed the bounds of the array.");

            var result = new T[length];
            for(int i = 0; i < length; i++)
                result[i] = array[startIndex + i];
            return result;
        }

    }

}

