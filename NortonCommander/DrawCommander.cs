﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander
{
    class DrawCommander
    {

        int sizeWindow = 38;
        int y = 22;
        string text = "";

        public void DrawPanelLeft(List<string[]> list, string adress, string name, string panel)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            int x = 0;
            text = adress;
            int k = 0;

            while (k != 4)
            {
                if (k == 0)
                {
                    int txt = 0;
                    int sizeText = text.Length + 2;
                    if (sizeText > 33)
                    {
                        string t = text.Remove(3);
                        text = t + ".." + "\\" + name;
                        if (text.Length > 33)
                        {
                            name = name.Remove(name.Length - (text.Length - 33));
                            text = t + ".." + "\\" + name;
                        }
                        sizeText = text.Length + 2;
                        txt = (sizeWindow / 2) - (sizeText / 2);
                    }
                    else
                        txt = (sizeWindow / 2) - (sizeText / 2);
                    Console.SetCursorPosition(x, 0);
                    Console.Write("\u2554");
                    for (int i = 0; i < sizeWindow; i++)
                    {
                        if (i == 12)
                            Console.Write("\u2566");
                        else if (i == 22 || i == 31)
                            Console.Write("\u2566");
                        else
                            Console.Write("\u2550");
                    }
                    Console.Write("\u2557");
                    if (panel == "left")
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.SetCursorPosition(txt, 0);
                    Console.Write(" " + text + " ");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;

                }
                if (k == 1)
                {

                    for (int i = k; i < y - 3; i++)
                    {
                        if (i == k)
                        {
                            Console.SetCursorPosition(x, i);
                            Console.Write("\u2551");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(x + 1, i);
                            Console.Write("    Name    ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(x + 13, i);
                            Console.Write("\u2551");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(x + 14, i);
                            Console.Write("   Size  ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(x + 23, i);
                            Console.Write("\u2551");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(x + 24, i);
                            Console.Write("  Date  ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(x + 32, i);
                            Console.Write("\u2551");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(x + 33, i);
                            Console.Write(" Time ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(sizeWindow + 1, i);
                            Console.WriteLine("\u2551");
                        }
                        else
                        {
                            Console.Write("\u2551");
                            Console.SetCursorPosition(x + 13, i);
                            Console.Write("\u2551");
                            Console.SetCursorPosition(x + 23, i);
                            Console.Write("\u2551");
                            Console.SetCursorPosition(x + 32, i);
                            Console.Write("\u2551");
                            Console.SetCursorPosition(sizeWindow + 1, i);
                            Console.Write("\u2551");
                            Console.WriteLine();
                        }
                    }
                }
                if (k == 2)
                {
                    for (int i = 0; i < sizeWindow + 2; i++)
                    {
                        if (i == 0)
                            Console.Write("\u2560");
                        else if (i == 13 || i == 23 || i == 32)
                            Console.Write("\u2569");
                        else if (i == sizeWindow + 1)
                            Console.Write("\u2563");
                        else
                            Console.Write("\u2550");
                    }
                }
                if (k == 3)
                {
                    Console.SetCursorPosition(x, y - 2);
                    Console.Write("\u2551");
                    Console.SetCursorPosition(x + 1, y - 2);
                    Console.Write(text);
                    for (int i = text.Length; i < sizeWindow; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(sizeWindow + 1, y - 2);
                    Console.WriteLine("\u2551");
                    for (int i = 0; i < sizeWindow; i++)
                    {
                        if (i == 0)
                            Console.Write("\u255A");
                        Console.Write("\u2550");
                    }
                    Console.WriteLine("\u255D");
                }
                k++;
            }
            PrintDF(list, "left");
            if (panel == "left")
                CommandString(text, panel);
        }

        public void DrawPanelRight(List<string[]> list, string adress, string name, string panel)
        {
            int x = sizeWindow + 2;
            text = adress;
            int k = 0;
            while (k != 4)
            {
                if (k == 0)
                {
                    int txt = 0;
                    int sizeText = text.Length + 2;
                    if (sizeText > 33)
                    {
                        string t = text.Remove(3);
                        text = t + ".." + "\\" + name;
                        if (text.Length > 33)
                        {
                            name = name.Remove(name.Length - (text.Length - 33));
                            text = t + ".." + "\\" + name;
                        }
                        sizeText = text.Length + 2;
                        txt = (sizeWindow / 2) - (sizeText / 2);
                    }
                    else
                        txt = (sizeWindow / 2) - (sizeText / 2);
                    Console.SetCursorPosition(x, 0);
                    Console.Write("\u2554");
                    for (int i = 0; i < sizeWindow; i++)
                    {
                        if (i == 12)
                        {
                            Console.SetCursorPosition(x + 13, 0);
                            Console.Write("\u2566");
                        }
                        else if (i == 22)
                        {
                            Console.SetCursorPosition(x + 23, 0);
                            Console.Write("\u2566");
                        }
                        else if (i == 31)
                        {
                            Console.SetCursorPosition(x + 32, 0);
                            Console.Write("\u2566");
                        }
                        else
                        {
                            Console.SetCursorPosition(x + i + 1, 0);
                            Console.Write("\u2550");
                        }

                    }
                    Console.SetCursorPosition(x + sizeWindow + 1, 0);
                    Console.WriteLine("\u2557");
                    if (panel == "right")
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.SetCursorPosition(x + txt, 0);
                    Console.Write(" " + text + " ");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (k == 1)
                {
                    for (int i = k; i < y - 3; i++)
                    {
                        if (i == k)
                        {
                            Console.SetCursorPosition(x, i);
                            Console.Write("\u2551");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(x + 1, i);
                            Console.Write("    Name    ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(x + 13, i);
                            Console.Write("\u2551");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(x + 14, i);
                            Console.Write("   Size  ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(x + 23, i);
                            Console.Write("\u2551");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(x + 24, i);
                            Console.Write("  Date  ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(x + 32, i);
                            Console.Write("\u2551");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(x + 33, i);
                            Console.Write(" Time ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(sizeWindow + 41, i);
                            Console.Write("\u2551");
                        }
                        else
                        {
                            Console.SetCursorPosition(x, i);
                            Console.Write("\u2551");
                            Console.SetCursorPosition(x + 13, i);
                            Console.Write("\u2551");
                            Console.SetCursorPosition(x + 23, i);
                            Console.Write("\u2551");
                            Console.SetCursorPosition(x + 32, i);
                            Console.Write("\u2551");
                            Console.SetCursorPosition(x + sizeWindow + 1, i);
                            Console.Write("\u2551");
                            Console.WriteLine();
                        }
                    }
                }
                if (k == 2)
                {
                    for (int i = 0; i < sizeWindow + 2; i++)
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(x, y - 3);
                            Console.Write("\u2560");
                        }
                        else if (i == 13)
                        {
                            Console.SetCursorPosition(x + 13, y - 3);
                            Console.Write("\u2569");
                        }
                        else if (i == 23)
                        {
                            Console.SetCursorPosition(x + 23, y - 3);
                            Console.Write("\u2569");
                        }
                        else if (i == 32)
                        {
                            Console.SetCursorPosition(x + 32, y - 3);
                            Console.Write("\u2569");
                        }
                        else if (i == sizeWindow + 1)
                        {
                            Console.SetCursorPosition(x + sizeWindow + 1, y - 3);
                            Console.Write("\u2563");
                        }
                        else
                        {
                            Console.SetCursorPosition(x + i, y - 3);
                            Console.Write("\u2550");
                        }
                    }
                }
                if (k == 3)
                {
                    Console.SetCursorPosition(x, y - 2);
                    Console.Write("\u2551");
                    Console.SetCursorPosition(x + 1, y - 2);
                    Console.Write(text);
                    for (int i = text.Length; i < sizeWindow + 1; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(x + sizeWindow + 1, y - 2);
                    Console.WriteLine("\u2551");
                    for (int i = 0; i < sizeWindow + 1; i++)
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(x, y - 1);
                            Console.Write("\u255A");
                        }
                        else
                        {
                            Console.SetCursorPosition(x + i, y - 1);
                            Console.Write("\u2550");
                        }
                    }
                    Console.SetCursorPosition(x + sizeWindow + 1, y - 1);
                    Console.WriteLine("\u255D");
                }
                k++;
            }
            if (panel == "right")
                CommandString(text, panel);
            CommandButtons();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            PrintDF(list, "right");
        }

        public void CommandString(string text, string panel)
        {
            if (panel == "right")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, y);
                Console.Write(text);
                for (int i = 0; i < sizeWindow * 2 - text.Length; i++)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, y);
                Console.Write(text);
                for (int i = 0; i < sizeWindow * 2 - text.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void CommandButtons()
        {
            Console.WriteLine();
            for (int i = 0; i < 11; i++)
            {
                switch (i)
                {
                    case 1:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Help  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        break;
                    case 2:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Menu  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        break;
                    case 3:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("View  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        break;
                    case 4:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Edit  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        break;
                    case 5:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Copy  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        break;
                    case 6:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("RenMov ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        break;
                    case 7:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("MkDir ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        break;
                    case 8:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Delete");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        break;
                    case 9:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("PullDn");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        break;
                    case 10:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Quit ");
                        Console.ResetColor();
                        break;
                }
            }
        }

        public void PrintDF(List<string[]> list, string panel)
        {
            int x = 0;
            int y = 2;
            int len = 17;
            if (panel == "left")
            {

                if (list.Count < len)
                {
                    int i = 0;
                    if (list.Count == 1 && list[0].Length == 1)
                    {
                        Console.SetCursorPosition(x + 1, y + i);
                        Console.WriteLine(list[0][0]);
                    }
                    else
                    {
                        foreach (var item in list)
                        {
                            Console.SetCursorPosition(x + 1, y + i);
                            Console.WriteLine(item[0]);
                            Console.SetCursorPosition(x + 14, y + i);
                            Console.WriteLine(item[1]);
                            Console.SetCursorPosition(x + 24, y + i);
                            Console.WriteLine(item[2]);
                            Console.SetCursorPosition(x + 33, y + i);
                            Console.WriteLine(item[3]);
                            i++;
                        }
                    }
                    for (int j = list.Count; j < len; j++)
                    {
                        Console.SetCursorPosition(x + 1, y + j);
                        Console.WriteLine(" ".PadLeft(12));
                        Console.SetCursorPosition(x + 14, y + j);
                        Console.WriteLine(" ".PadLeft(9));
                        Console.SetCursorPosition(x + 24, y + j);
                        Console.WriteLine(" ".PadLeft(8));
                        Console.SetCursorPosition(x + 33, y + j);
                        Console.WriteLine(" ".PadLeft(6));
                    }
                }
                else if (list.Count >= len)
                {
                    int i = 0;
                    if (list.Count == 1 && list[0].Length == 1)
                    {
                        Console.SetCursorPosition(x + 1, y + i);
                        Console.WriteLine(list[0][0]);
                    }
                    foreach (var item in list)
                    {
                        Console.SetCursorPosition(x + 1, y + i);
                        Console.WriteLine(item[0]);
                        Console.SetCursorPosition(x + 14, y + i);
                        Console.WriteLine(item[1]);
                        Console.SetCursorPosition(x + 24, y + i);
                        Console.WriteLine(item[2]);
                        Console.SetCursorPosition(x + 33, y + i);
                        Console.WriteLine(item[3]);
                        i++;
                        if (i > 16)
                            break;
                    }
                }
            }
            if (panel == "right")
            {
                x = sizeWindow + 2;
                if (list.Count < len)
                {
                    int i = 0;
                    if (list.Count == 1 && list[0].Length == 1)
                    {
                        Console.SetCursorPosition(x + 1, y + i);
                        Console.WriteLine(list[0][0]);
                    }
                    else
                    {
                        foreach (var item in list)
                        {
                            Console.SetCursorPosition(x + 1, y + i);
                            Console.WriteLine(item[0]);
                            Console.SetCursorPosition(x + 14, y + i);
                            Console.WriteLine(item[1]);
                            Console.SetCursorPosition(x + 24, y + i);
                            Console.WriteLine(item[2]);
                            Console.SetCursorPosition(x + 33, y + i);
                            Console.WriteLine(item[3]);
                            i++;
                        }
                    }
                    for (int j = list.Count; j < len; j++)
                    {
                        Console.SetCursorPosition(x + 1, y + j);
                        Console.WriteLine(" ".PadLeft(12));
                        Console.SetCursorPosition(x + 14, y + j);
                        Console.WriteLine(" ".PadLeft(9));
                        Console.SetCursorPosition(x + 24, y + j);
                        Console.WriteLine(" ".PadLeft(8));
                        Console.SetCursorPosition(x + 33, y + j);
                        Console.WriteLine(" ".PadLeft(6));
                    }
                }
                else if (list.Count >= len)
                {
                    int i = 0;
                    if (list.Count == 1 && list[0].Length == 1)
                    {
                        Console.SetCursorPosition(x + 1, y + i);
                        Console.WriteLine(list[0][0]);
                    }
                    foreach (var item in list)
                    {
                        Console.SetCursorPosition(x + 1, y + i);
                        Console.WriteLine(item[0]);
                        Console.SetCursorPosition(x + 14, y + i);
                        Console.WriteLine(item[1]);
                        Console.SetCursorPosition(x + 24, y + i);
                        Console.WriteLine(item[2]);
                        Console.SetCursorPosition(x + 33, y + i);
                        Console.WriteLine(item[3]);
                        i++;
                        if (i > 16)
                            break;
                    }
                }
            }
        }

        public string SizeCheck(string fullName, string name)
        {
            string text = fullName;
            int sizeText = fullName.Length + 2;
            if (sizeText > 33)
            {
                string t = text.Remove(3);
                text = t + ".." + "\\" + name;
                if (text.Length > 33)
                {
                    name = name.Remove(name.Length - (text.Length - 33));
                    return text = t + ".." + "\\" + name;
                }
                else
                    return text = t + ".." + "\\" + name;
            }
            else
                return text;
        }

        public void DrawWindowDisc()
        {
            int x = 32;
            int y = 7;
            for (int i = x; i < 47; i++)
            {
                for (int j = y; j < 12; j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine(" ");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public void DrawWindowShow(string st)
        {
            int sizeText = st.Length + 2;
            int x = sizeWindow - sizeText / 2;
            int y = 7;
            for (int i = x; i < (sizeWindow + sizeText / 2) + 1; i++)
            {
                for (int j = y; j < 12; j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine(" ");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(x + 1, 9);
            Console.WriteLine(st);
        }

        public string DrawWindowProcess(string textProcess, string name, string fullName, DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {
            int x = 0;
            int y = 7;
            int xt = 0;
            string nameP = "Name: " + SizeCheck(fullName, name);
            int sizeName = nameP.Length + 2;
            int sizeText = textProcess.Length + 2;
            if (sizeName >= sizeText)
            {
                x = sizeWindow - sizeName / 2;
                xt = sizeWindow + sizeName / 2;
            }
            else
            {
                x = sizeWindow - sizeText / 2;
                xt = sizeWindow + sizeText / 2;
            }

            for (int i = x; i < xt + 1; i++)
            {
                for (int j = y; j < 14; j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine(" ");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(x + 1, 8);
            Console.WriteLine(textProcess);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x + 1, 10);
            Console.WriteLine(nameP);
            return Menu.GorizontMenu2(textProcess, name, dirR, dirL, panel);
        }

        public void DrawWindowProcessCreate(string textProcess, string name, string fullName)
        {
            int x = 0;
            int y = 7;
            int xt = 0;
            int sizeText = textProcess.Length + 6;
            x = sizeWindow - sizeText / 2;
            xt = sizeWindow + sizeText / 2;
            for (int i = x; i < xt + 1; i++)
            {
                for (int j = y; j < 14; j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine(" ");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(x + 1, 8);
            Console.WriteLine(textProcess);
        }
    }
}
