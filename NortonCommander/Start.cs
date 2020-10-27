using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander
{
    class Start
    {
        DrawCommander draw = new DrawCommander();
        Panels panels = new Panels();
        string pathR = "";
        string pathL = "";
        string panel_ = "left";

        public void launchCommander(string path, string panel)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            draw.DrawPanelLeft(panels.ConvertDirToList(dir), dir.FullName);
            draw.DrawPanelRight(panels.ConvertDirToList(dir), dir.FullName);
            Menu.VerticalMenu(panels.ConvertDirToList(dir), dir, panel);
        }

        public void launchPanelCommander(string pathL, string pathR, string panel)
        {
            DirectoryInfo dirL = new DirectoryInfo(pathL);
            DirectoryInfo dirR = new DirectoryInfo(pathR);

            draw.DrawPanelLeft(panels.ConvertDirToList(dirL), dirL.FullName);
            draw.DrawPanelRight(panels.ConvertDirToList(dirR), dirR.FullName);
            if (panel == "right")
                Menu.VerticalMenu(panels.ConvertDirToList(dirR), dirR, panel);
            else
                Menu.VerticalMenu(panels.ConvertDirToList(dirL), dirL, panel);
        }

        public void OpenDirectory(int pos, DirectoryInfo dir, string panel)
        {
            DirectoryInfo[] dirs = dir.GetDirectories();
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
                            pathL = dir.FullName;
                        }
                        else
                        {
                            pathR = dir.FullName;
                            pathL = item.FullName;
                        }
                    }

                    i++;
                }
            }
            launchPanelCommander(pathL, pathR, panel);
        }

        public void TabDirectory(int pos, DirectoryInfo dir, string panel)
        {
            if (panel == "right")
            {
                panel = "left";

                launchPanelCommander(pathL, pathR, panel);
            }
            else
            {
                launchPanelCommander(pathL, pathR, panel);
               
            }
        }
    }
}
