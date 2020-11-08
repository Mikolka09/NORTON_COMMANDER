using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NortonCommander
{
    class Menu
    {

        public static int VerticalMenu(List<string[]> list, DirectoryInfo dirR, DirectoryInfo dirL, string panel, string nameR, string nameL)
        {
            Performance perf = new Performance();
            DrawCommander draw = new DrawCommander();
            ConsoleColor bg = Console.BackgroundColor;
            ConsoleColor fg = Console.ForegroundColor;
            int pos = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i][0] == nameR || list[i][0] == nameL)
                    pos = i;
            }
            int x = 0;
            if (panel == "right")
                x = 40;
            int y = 2;
            Console.CursorVisible = false;
            while (true)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i < 17)
                    {
                        Console.SetCursorPosition(x + 1, y + i);
                        if (pos == i)
                        {
                            Console.BackgroundColor = fg;
                            Console.ForegroundColor = bg;
                        }
                        else
                        {
                            Console.BackgroundColor = bg;
                            Console.ForegroundColor = fg;
                        }
                        Console.WriteLine(list[i][0]);
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(x + 14, y + i);
                        Console.WriteLine(list[i][1]);
                        Console.SetCursorPosition(x + 24, y + i);
                        Console.WriteLine(list[i][2]);
                        Console.SetCursorPosition(x + 33, y + i);
                        Console.WriteLine(list[i][3]);
                    }
                    else if (pos > 16)
                    {
                        for (int j = pos; j < pos + 17; j++)
                        {
                            Console.SetCursorPosition(x + 1, y + j - pos);
                            if (j == pos)
                            {
                                Console.BackgroundColor = fg;
                                Console.ForegroundColor = bg;
                            }
                            else
                            {
                                Console.BackgroundColor = bg;
                                Console.ForegroundColor = fg;
                            }
                            Console.WriteLine(list[j - pos + 1][0]);
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(x + 14, y + j - pos);
                            Console.WriteLine(list[j - pos + 1][1]);
                            Console.SetCursorPosition(x + 24, y + j - pos);
                            Console.WriteLine(list[j - pos + 1][2]);
                            Console.SetCursorPosition(x + 33, y + j - pos);
                            Console.WriteLine(list[j - pos + 1][3]);
                        }
                    }
                }


                if (panel == "left")
                {
                    Console.SetCursorPosition(x + 1, y + 18);
                    Console.Write(FullNamePos(list, pos));
                }
                else
                {
                    Console.SetCursorPosition(41, y + 18);
                    Console.Write(FullNamePos(list, pos));
                }

                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {
                    case ConsoleKey.Escape:
                        perf.launchPanelCommander(dirL.FullName, dirR.FullName, panel, true);
                        break;

                    case ConsoleKey.Enter:
                        perf.OpenDirectory(pos, list, dirR, dirL, panel);
                        break;

                    case ConsoleKey.Tab:
                        perf.TabDirectory(dirR, dirL, panel);
                        break;

                    case ConsoleKey.F1:
                        Process.Start("Notepad.exe", "help.txt");
                        break;

                    case ConsoleKey.F2:
                        perf.TabDisc(dirR, dirL, panel);
                        break;

                    case ConsoleKey.F3:
                        perf.ViewFile(list, dirR, dirL, panel, pos);
                        break;

                    case ConsoleKey.F4:
                        perf.EditFile(list, dirR, dirL, panel, pos);
                        break;

                    case ConsoleKey.F5:
                        perf.CopyDirectoryFile(list, dirR, dirL, panel, pos, true);
                        break;

                    case ConsoleKey.F6:
                        perf.MoveDirectoryFile(list, dirR, dirL, panel, pos, true);
                        break;

                    case ConsoleKey.F7:
                        perf.CreateDirectory(dirR, dirL, panel, true);
                        break;

                    case ConsoleKey.F8:
                        perf.DellDirectoryFile(list, dirR, dirL, panel, pos, true);
                        break;

                    case ConsoleKey.F9:
                        draw.DrawWindowShow("Back Start Page");
                        Thread.Sleep(1500);
                        perf.launchPanelCommander("C:\\", "D:\\", panel, true);
                        break;

                    case ConsoleKey.F10:
                        perf.ExitCommander(list, dirR, dirL, panel, pos, true);
                        break;

                    case ConsoleKey.UpArrow:
                        //if (list.Count > 16)
                        //{
                        //    if (pos > 0)
                        //    {
                        //        pos--;
                        //        draw.WriteLongListUp(list, pos, panel);
                        //    }
                        //    else
                        //        break;

                        //}
                        //else 
                        if (pos > 0)
                            pos--;
                        break;

                    case ConsoleKey.DownArrow:

                        //if (list.Count > 16)
                        //{
                        //    if (pos < list.Count - 1)
                        //    {
                        //        pos++;
                        //        if (pos > 16)
                        //            draw.WriteLongListDown(list, pos, panel);
                        //    }
                        //    else
                        //        break;
                        //}
                        //else 
                        if (pos < list.Count - 1)
                            pos++;
                        break;
                }

            }
        }

        public static int GorizontMenu(string[] discs, DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {
            DrawCommander draw = new DrawCommander();
            draw.DrawWindowDisc();
            Performance perf = new Performance();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(34, 8);
            Console.WriteLine("Switch Disk");
            int x = 38;
            int y = 10;
            Console.CursorVisible = false;
            int pos = 0;
            while (true)
            {

                for (int i = 0; i < discs.Length; i++)
                {
                    Console.SetCursorPosition(x + i * 3, y);
                    if (i == pos)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(discs[i]);
                }

                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {

                    case ConsoleKey.Enter:
                        perf.ChangeDisc(discs, panel, pos);
                        break;

                    case ConsoleKey.Escape:
                        perf.launchPanelCommander(dirL.FullName, dirR.FullName, panel, true);
                        break;

                    case ConsoleKey.RightArrow:
                        if (pos < discs.Length - 1)
                            pos++;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (pos > 0)
                            pos--;

                        break;

                    default:
                        break;
                }
            }

        }


        public static string GorizontMenu2(string textProcess, string name, DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {
            string[] mas = new string[2];
            mas[0] = "YES";
            mas[1] = "NO";
            Performance perf = new Performance();
            int x = 34;
            int y = 12;
            Console.CursorVisible = false;
            int pos = 0;
            while (true)
            {

                for (int i = 0; i < mas.Length; i++)
                {
                    Console.SetCursorPosition(x + i * 5, y);
                    if (i == pos)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(mas[i]);
                }

                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {

                    case ConsoleKey.Enter:
                      if(pos==0)
                            return "YES";
                      else
                            return "NO";
                       
                    case ConsoleKey.Escape:
                        perf.launchPanelCommander(dirL.FullName, dirR.FullName, panel, true);
                        break;

                    case ConsoleKey.RightArrow:
                        if (pos < mas.Length - 1)
                            pos++;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (pos > 0)
                            pos--;

                        break;

                    default:
                        break;
                }
            }

        }



        public static string FullNamePos(List<string[]> list, int pos)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            int i = 0;
            foreach (var item in list)
            {
                if (i == pos && list[pos][0] == item[0])
                    return $"{item[0]}".PadRight(12) + $"{item[1]}".PadLeft(10)
                        + $"{item[2]}".PadLeft(9) + $"{item[3]}".PadLeft(7);
                i++;
            }
            return $"{list[list.Count - 1][0]}".PadRight(12) + $"{list[list.Count - 1][1]}".PadLeft(10)
                        + $"{list[list.Count - 1][2]}".PadLeft(9) + $"{list[list.Count - 1][3]}".PadLeft(7);
        }

    }
}
