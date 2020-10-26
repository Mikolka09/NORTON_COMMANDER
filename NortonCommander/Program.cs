using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander
{
    class Program
    {
        class Menu1
        {
            public static int VerticalMenu1(List<string[]> list, string panel)
            {
                int maxLen = 12;
                int j=0;
                string[]str = new string[list.Count];
                foreach (var item in list)
                {
                    str[j++] = item[0];
                }
                ConsoleColor bg = Console.BackgroundColor;
                ConsoleColor fg = Console.ForegroundColor;
                int x = 1;
                int y = 2;
                Console.CursorVisible = false;
                int pos = 0;
                while (true)
                {

                    for (int i = 0; i < str.Length; i++)
                    {
                        Console.SetCursorPosition(x, y + i);
                        if (i == pos)
                        {
                            Console.BackgroundColor = fg;
                            Console.ForegroundColor = bg;
                        }
                        else
                        {
                            Console.BackgroundColor = bg;
                            Console.ForegroundColor = fg;
                        }
                        Console.Write(str[i].PadRight(maxLen));
                    }

                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    switch (consoleKey)
                    {

                        case ConsoleKey.Enter:
                            return pos;


                        case ConsoleKey.Escape:
                            return str.Length - 1;

                            
                        case ConsoleKey.UpArrow:
                            if (pos > 0)
                                pos--;
                            break;

                        case ConsoleKey.DownArrow:
                            if (pos < str.Length - 1)
                                pos++;
                            ;
                            break;

                    }

                }
            }

        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                DirectoryInfo dir = new DirectoryInfo("C:\\");
                Panels panels = new Panels();
               
                DrawCommander draw = new DrawCommander();
                draw.DrawPanelLeft(panels.DirDiscStart(dir),dir.FullName);
                draw.DrawPanelRight(panels.DirDiscStart(dir),dir.FullName);
                Menu1.VerticalMenu1(panels.DirDiscStart(dir), "left");
            }




            Console.ReadLine();

        }
    }
}
