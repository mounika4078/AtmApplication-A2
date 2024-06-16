using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initializing the atm app to start taking inputs from user
            AtmApplication app = new AtmApplication();
            app.Start();
        }
    }
}
