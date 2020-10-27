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
        
        public static int VerticalMenu(List<string[]> list, DirectoryInfo dir, string panel)
        {
            DrawCommander draw = new DrawCommander();
            Start start = new Start();
            int maxLen = 12;
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
                if (panel == "left")
                {
                    Console.SetCursorPosition(x, y + 18);
                    Console.Write(FullNamePos(str, dir, pos));
                    for (int i = FullNamePos(str, dir, pos).Length; i < 38; i++)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    Console.SetCursorPosition(41, y + 18);
                    Console.Write(FullNamePos(str, dir, pos));
                    for (int i = FullNamePos(str, dir, pos).Length; i < 39; i++)
                    {
                        Console.Write(" ");
                    }
                }
                ConsoleKey consoleKey = Console.ReadKey().Key;
                switch (consoleKey)
                {

                    case ConsoleKey.Enter:
                        start.OpenDirectory(pos, dir, panel);
                        break;

                    case ConsoleKey.Tab:
                        start.TabDirectory(pos, dir, panel);
                       
                        break;

                    case ConsoleKey.F10:
                        
                        break;


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

        

        public static string FullNamePos(string[] str, DirectoryInfo dir, int pos)
        {
            string name = "";
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            int countD = 0;
            foreach (var item in dirs)
            {
                if (item.Attributes.HasFlag(FileAttributes.Hidden))
                    countD++;
            }

            if (pos < dirs.Length - countD)
            {
                int i = 0;
                foreach (var item in dirs)
                {
                    if (item.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;
                    else if (i == pos)
                        name = item.Name.Length <= 12 ? item.Name.PadRight(12) : item.Name.Substring(0, 12);
                    if (str[pos] == name)
                        return item.FullName;
                    i++;
                }
            }
            else
            {
                int i = dirs.Length - countD;
                foreach (var item in files)
                {
                    if (item.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;
                    else if (i == pos)
                        name = item.Name.Length <= 12 ? $"{item.Name}".Replace(item.Extension, "").PadRight(8) +
                        " " + $"{item.Extension}".Replace(".", "").PadLeft(3) : item.Name.Substring(0, 8).PadRight(8)
                        + " " + $"{item.Extension}".Replace(".", "").PadLeft(3); ;
                    if (str[pos] == name)
                        return item.FullName;
                    i++;
                }
            }
            return null;
        }

    }
}
