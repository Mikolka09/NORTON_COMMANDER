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
                Menu.VerticalMenu(listR, dirR, dirL, panel);
            else
                Menu.VerticalMenu(listL, dirR, dirL, panel);
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
                Menu.VerticalMenu(listR, dirR, dirL, panel);
            else
                Menu.VerticalMenu(listL, dirR, dirL, panel);
        }

        public void OpenDirectory(int pos, string[] str, DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {
            DirectoryInfo[] dirs;
            if (panel == "right")
                dirs = dirR.GetDirectories();
            else
                dirs = dirL.GetDirectories();
            if (str[0] == "..".PadRight(12))
            {
                if (panel == "right")
                {
                    pathR = dirs[0].Parent.FullName;
                    pathL = dirL.FullName;
                }
                else
                {
                    pathR = dirR.FullName;
                    pathL = dirL.Parent.FullName;
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

                if (pos < dirs.Length - countD)
                {
                    int i = 0;
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
    }
}
