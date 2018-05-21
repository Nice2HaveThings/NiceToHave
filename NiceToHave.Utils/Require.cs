using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceToHave.Utils
{
    public static class Require
    {
        public static void NotNull(object element, string message)
        {
            if(element == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
