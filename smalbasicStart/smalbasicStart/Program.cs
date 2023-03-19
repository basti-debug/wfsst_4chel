using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;
using System.IO;

namespace smalbasicStart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            GraphicsWindow.DrawEllipse(50, 30, 33, 55);
            Turtle.Speed = 100;

            for (int i = 0; i < 100; i++)
            {
                Turtle.Move(10);
                Turtle.Turn(-5.6);
            }
            
        }
        
        private static void GraphicsWindow_KeyDown()
        {
            GraphicsWindow.FillEllipse(GraphicsWindow.MouseX, GraphicsWindow.MouseY, 5,5);
        }
    }
}
