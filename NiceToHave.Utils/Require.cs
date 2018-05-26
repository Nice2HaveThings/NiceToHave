using NiceToHave.Utils.Extension;
using System;

namespace NiceToHave.Utils
{
    public static class Require
    {
        public static void NotNull(object element)
        {
            NotNull(element, "Das Element darf nicht null sein");
        }

        public static void NotNull(object element, string message)
        {
            if(element == null)
            {
                throw new ArgumentException(message);
            }
        }

        public static void NotEmpty(string element)
        {
            NotEmpty(element, "Das Element darf nicht leer sein");
        }          

        public static void NotEmpty(string element, string message)
        {
            if(string.IsNullOrWhiteSpace(element))
            {
                throw new ArgumentException(message);
            }
        }
        
        public static void IsComplex(Type t)
        {
            IsComplex(t, "Das Element muss ein komplexter Type sein.");
        }
        
        public static void IsComplex(Type t, string message)
        {
            if(t.IsSimple())
            {
                throw new ArgumentException(message);
            }

        }
    }
}
