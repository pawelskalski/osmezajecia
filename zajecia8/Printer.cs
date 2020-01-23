using System;
using System.Collections.Generic;
using System.Linq;

namespace zajecia8
{
    class Ink
    {
        public string inkName { get; set; }
        public int inkAmount { get; set; }

        public Ink(string name, int amount)
        {
            inkName = name;
            inkAmount = amount;
        }
    }

    public class Printer
    {
        private Random _random = new Random(387462837);
        public event EventHandler OutOfPaperEvent;
        public event EventHandler<OutOfInkEventArgs> OutOfInkEvent;
        
        List<Ink> ink = new List<Ink>()
        {
            new Ink("cyan", 100),
            new Ink("magenta", 100),
            new Ink("yellow", 100),
            new Ink("black", 100), 
        };

        public int paperAmount { get; set; } = 5;
        public void Print()
        {
            bool noInk = false;
            foreach (var color in ink)
            {
                if (color.inkAmount <= 0)
                {
                    noInk = true;
                    OutOfInkEvent?.Invoke(this, new OutOfInkEventArgs(color.inkName));
                }
            }
            
            if (!noInk)
            {
                if (paperAmount <= 0)
                {
                    OutOfPaperEvent?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    Console.WriteLine("Printing");
                    paperAmount--;
                    ink.ForEach(x => x.inkAmount -= _random.Next());
                }
            }
        }

        private void OutOfPaperEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine($"{DateTime.Now.ToShortDateString()} " + 
                              $"{DateTime.Now.ToShortTimeString()} | [PrinterLog]: Out of paper");
        }

        public Printer()
        {
            OutOfPaperEvent += OutOfPaperEventHandler;
            OutOfInkEvent += OutOfInkEventHandler;
        }
        
        private void OutOfInkEventHandler(object sender, OutOfInkEventArgs args)
        {
            Console.WriteLine($"{DateTime.Now.ToShortDateString()} " + 
                              $"{DateTime.Now.ToShortTimeString()} | [PrinterLog]: Out of {args.color} ink");
        }
    }
}