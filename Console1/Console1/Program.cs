﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new MyClass().SayHello());
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        
    }
}
