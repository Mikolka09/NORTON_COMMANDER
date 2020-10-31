using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander
{
    class Performance
    {
        DrawCommander draw = new DrawCommander();
        ConvertPanels panels = new ConvertPanels();
        string pathR = "D:\\";
        string pathL = "C:\\";
        string panel = "left";
        string nameR = "";
        string nameL = "";

        public void launchPanelCommander(string pathL, string pathR, string panel)
        {
            DirectoryInfo dirL = new DirectoryInfo(pathL);
            DirectoryInfo dirR = new DirectoryInfo(pathR);
            List<string[]> listR = new List<string[]>();
            List<string[]> listL = new List<string[]>();
            listR = panels.ConvertDirToList(dirR);
            listL = panels.ConvertDirToList(dirL);

            draw.DrawPanelLeft(listL, dirL.FullName, panel);
            draw.DrawPanelRight(listR, dirR.FullName, panel);
            if (panel == "right")
                Menu.VerticalMenu(listR, dirR, dirL, panel, nameR, nameL);
            else
                Menu.VerticalMenu(listL, dirR, dirL, panel, nameR, nameL);
        }

        public void launchPanelCommander()
        {
            DirectoryInfo dirL = new DirectoryInfo(pathL);
            DirectoryInfo dirR = new DirectoryInfo(pathR);
            List<string[]> listR = new List<string[]>();
            List<string[]> listL = new List<string[]>();
            listR = panels.ConvertDirToList(dirR);
            listL = panels.ConvertDirToList(dirL);

            draw.DrawPanelLeft(listL, dirL.FullName, panel);
            draw.DrawPanelRight(listR, dirR.FullName, panel);
            if (panel == "right")
                Menu.VerticalMenu(listR, dirR, dirL, panel, nameR, nameL);
            else
                Menu.VerticalMenu(listL, dirR, dirL, panel, nameR, nameL);
        }

        public void OpenDirectory(int pos, List<string[]> list, DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {

            DirectoryInfo[] dirs;
            if (panel == "right")
                dirs = dirR.GetDirectories();
            else
                dirs = dirL.GetDirectories();
            if (list[pos][0] == "..".PadRight(12))
            {
                if (panel == "right")
                {
                    nameR = dirR.Name.Length <= 12 ? dirR.Name.PadRight(12) : dirR.Name.Substring(0, 12);
                    pathR = dirR.Parent.FullName;
                    pathL = dirL.FullName;
                    nameL = dirL.Name.Length <= 12 ? dirL.Name.PadRight(12) : dirL.Name.Substring(0, 12);
                }
                else
                {
                    nameR = dirR.Name.Length <= 12 ? dirR.Name.PadRight(12) : dirR.Name.Substring(0, 12);
                    pathR = dirR.FullName;
                    pathL = dirL.Parent.FullName;
                    nameL = dirL.Name.Length <= 12 ? dirL.Name.PadRight(12) : dirL.Name.Substring(0, 12);
                }
            }
            else
            {
                int countD = 0;
                foreach (var item in dirs)
                {
                    if (item.Attributes.HasFlag(FileAttributes.Hidden))
                        countD++;
                }

                if (pos < dirs.Length - countD + 1)
                {
                    int i = 0;
                    if (dirL.FullName != dirL.Root.FullName || dirR.FullName != dirR.Root.FullName)
                        i = 1;
                    foreach (var item in dirs)
                    {
                        if (item.Attributes.HasFlag(FileAttributes.Hidden))
                            continue;
                        else if (i == pos)
                        {
                            if (panel == "right")
                            {
                                pathR = item.FullName;
                                pathL = dirL.FullName;
                            }
                            else
                            {
                                pathR = dirR.FullName;
                                pathL = item.FullName;
                            }
                        }
                        i++;
                    }
                }
            }
            launchPanelCommander(pathL, pathR, panel);
        }

        public void TabDirectory(DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {
            if (panel == "right")
            {
                panel = "left";
                pathL = dirL.FullName;
                pathR = dirR.FullName;
                launchPanelCommander(pathL, pathR, panel);
            }
            else
            {
                panel = "right";
                pathL = dirL.FullName;
                pathR = dirR.FullName;
                launchPanelCommander(pathL, pathR, panel);
            }
        }

        public void CreateDirectory(DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {
            if (panel == "right")
            {
                Console.Write("Name Directory: ");
                nameR = Console.ReadLine();
                string name = $"{dirR.FullName}" + "\\" + nameR;
                DirectoryInfo newDir = new DirectoryInfo(name);
                if (!newDir.Exists)
                {
                    newDir.Create();
                }
                pathR = newDir.Parent.FullName;
                nameR = nameR.Length <= 12 ? dirR.Name.PadRight(12) : dirR.Name.Substring(0, 12);
                launchPanelCommander(pathL, pathR, panel);
            }
            else
            {
                Console.Write("Name Directory: ");
                nameL = Console.ReadLine();
                string name = $"{dirL.FullName}" + "\\" + nameL;
                DirectoryInfo newDir = new DirectoryInfo(name);
                if (!newDir.Exists)
                {
                    newDir.Create();
                }
                pathL = newDir.Parent.FullName;
                nameR = nameL.Length <= 12 ? dirR.Name.PadRight(12) : dirR.Name.Substring(0, 12);
                launchPanelCommander(pathL, pathR, panel);
            }

        }

        public void DellDirectory(DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {

        }
}
