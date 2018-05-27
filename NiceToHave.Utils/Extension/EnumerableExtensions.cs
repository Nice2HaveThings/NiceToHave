using System;
using System.Collections.Generic;

namespace NiceToHave.Utils.Extension
{
    public static class EnumerableExtensions
    {
        public static TElement Second<TElement>(this IEnumerable<TElement> elements, Predicate<TElement> condition)
        {
            if(TryGetSecond(elements, condition, out TElement second))
            {
                return second;
            }

            throw new InvalidOperationException("Kein zweiter Eintrag gefunden.");
        }

        public static TElement SecondOrDefault<TElement>(this IEnumerable<TElement> elements, Predicate<TElement> condition)
        {
            TryGetSecond(elements, condition, out TElement second);
            return second;
        }

        private static bool TryGetSecond<TElement>(this IEnumerable<TElement> elements, Predicate<TElement> condition, out TElement second)
        {
            bool firstMatch = false;
            foreach (TElement element in elements)
            {
                if (condition(element))
                {
                    if (firstMatch)
                    {
                        second = element;
                        return true;
                    }
                    firstMatch = true;
                }
            }

            second = default(TElement);
            return false;
        }
    }
}
