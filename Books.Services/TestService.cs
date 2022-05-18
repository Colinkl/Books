using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Services
{
    public class TestService
    {
        public int MagicThing(int a, int b, string x)
        {
            if (x is null)
            {
                throw new ArgumentNullException();
            }
            return a + b;
        }
    }
}
