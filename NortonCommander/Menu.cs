using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NortonCommander
{
    class Menu
    {

        public static int VerticalMenu(List<string[]> list, DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {
            Performance perf = new Performance();
            DrawCommander draw = new DrawCommander();
            int j = 0;
            string[] str = new string[list.Count];
            foreach (var item in list)
            {
                str[j++] = item[0];
            }
            ConsoleColor bg = Console.BackgroundColor;
            ConsoleColor fg = Console.ForegroundColor;

            int x = 1;
            if (panel == "right")
                x = 41;
            int y = 2;
            Console.CursorVisible = false;
            int pos = 0;
            while (true)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (i < 16)
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
                        Console.Write(str[i]);
                    }
                    else
                    {
                           Console.SetCursorPosition(x, pos);
                                if (pos == 17)
                            {
                                Console.BackgroundColor = fg;
                                Console.ForegroundColor = bg;
                            }
                            else
                            {
                                Console.BackgroundColor = bg;
                                Console.ForegroundColor = fg;
                            }
                        
                            //draw.WriteLongList(list, i, panel);
                        
                    }
                }
                if (panel == "left")
                {
                    Console.SetCursorPosition(x, y + 18);
                    Console.Write(FullNamePos(str, list, pos));
                }
                else
                {
                    Console.SetCursorPosition(41, y + 18);
                    Console.Write(FullNamePos(str, list, pos));
                }
                ConsoleKey consoleKey = Console.ReadKey().Key;
                switch (consoleKey)
                {

                    case ConsoleKey.Enter:
                        if (panel == "right")
                            perf.OpenDirectory(pos, str, dirR, dirL, panel);
                        else
                            perf.OpenDirectory(pos, str, dirR, dirL, panel);
                        break;

                    case ConsoleKey.Tab:
                        perf.TabDirectory(dirR, dirL, panel);
                        break;

                    case ConsoleKey.F10:

                        break;

                    case ConsoleKey.UpArrow:
                        if (pos > 0)
                            pos--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pos < 16)
                        { 
                            pos++;
                          
                        }
                        else     
                        {
                            pos=17;
                            draw.WriteLongList(list, pos, panel);
                        }
                        break;

                }

            }
        }



        public static string FullNamePos(string[] str, List<string[]> list, int pos)
        {
            int i = 0;
            foreach (var item in list)
            {
                if (i == pos && str[pos] == item[0])
                    return $"{item[0]}".PadRight(12) + $"{item[1]}".PadLeft(10)
                        + $"{item[2]}".PadLeft(9) + $"{item[3]}".PadLeft(7);
                i++;
            }
            return $"..".PadRight(12) + $">UP--DIR<".PadLeft(10) + $"{DateTime.Now.Date:dd-MM-yy}".PadLeft(9)
                + $"{DateTime.Now.ToShortTimeString()}".PadLeft(7);
        }

    }
}
