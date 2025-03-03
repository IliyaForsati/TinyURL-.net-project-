using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL.Application.util
{
    public class NumberGenerator
    {
        public static int generateNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}
