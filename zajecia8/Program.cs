using System;

namespace zajecia8
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer();
            printer.OutOfPaperEvent += OutOfPaperEventHandler;
            printer.Print();
        }

        static void OutOfPaperEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine("Printer ran out of paper, please put new paper");
        }
    }
}