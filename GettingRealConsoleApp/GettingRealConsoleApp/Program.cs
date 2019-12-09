using System;
using System.Collections.Generic;
using System.Text;
using GettingRealConsoleApp.UI;
using System.Linq;

namespace GettingRealConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        void Run()
        {
            Menu menu = new Menu();
            menu.AddHardCode();
            menu.DisplayMenu();
        }
    }
}
