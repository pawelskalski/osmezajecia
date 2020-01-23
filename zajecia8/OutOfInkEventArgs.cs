using System;

namespace zajecia8
{
    public class OutOfInkEventArgs : EventArgs
    {
        public OutOfInkEventArgs(string color)
        {
            this.color = color;
        }
        public string color { get; set; }
    }
}