﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionFilter.OuterLib
{
    public static class Image
    {

        public static void BadImageFormatException()
        {
            throw new BadImageFormatException();
        }
    }
}
