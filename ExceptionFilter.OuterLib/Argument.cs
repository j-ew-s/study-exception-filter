using System;
using System.IO;

namespace ExceptionFilter.OuterLib
{
    public static class Argument
    {
        public static void ArgumentEx()
        {
            throw  new ArgumentException();
        }

        public static void ArgumentNullException()
        {
            throw new ArgumentNullException();
        }

        public static void ArgumentOutOfRangeException()
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
