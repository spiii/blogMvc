﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog.helpers
{
    public static class MainHelper
    {
        public static String number2String(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }


    }
}