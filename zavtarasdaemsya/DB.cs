using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace zavtarasdaemsya
{
    internal class DB
    {
        static WebZad webZad = new WebZad();

        public static WebZad Instance
        {
            get => webZad;
        }
    }
}
