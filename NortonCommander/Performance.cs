using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

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

            draw.DrawPanelLeft(listL, dirL.FullName, dirL.Name, panel);
            draw.DrawPanelRight(listR, dirR.FullName, dirR.Name, panel);
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

            draw.DrawPanelLeft(listL, dirL.FullName, dirL.Name, panel);
            draw.DrawPanelRight(listR, dirR.FullName, dirR.Name, panel);
            if (panel == "right")
                Menu.VerticalMenu(listR, dirR, dirL, panel, nameR, nameL);
            else
                Menu.VerticalMenu(listL, dirR, dirL, panel, nameR, nameL);
        }

        public bool isFile(int pos, List<string[]> list, DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {
            string fileName = "";
            FileInfo[] files;
            if (panel == "right")
                files = dirR.GetFiles();
            else
                files = dirL.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension == "" && files[i].Name.Length <= 8)
                    fileName = $"{files[i].Name}".PadRight(7) + "     ".PadLeft(5);
                else if (files[i].Extension == "")
                    fileName = $"{files[i].Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                else if (files[i].Name.Replace(files[i].Extension, "").Length <= 8)
                    fileName = files[i].Extension.Length <= 4 ? $"{files[i].Name}".Replace(files[i].Extension, "").PadRight(8) +
                    " " + $"{files[i].Extension}".Replace(".", "").PadLeft(3) : $"{files[i].Name}".
                    Replace(files[i].Extension, "").PadRight(7) + " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                else
                    fileName = files[i].Extension.Length <= 4 ? files[i].Name.Replace(files[i].Extension, "").Substring(0, 8).PadRight(8) + " " +
                            $"{files[i].Extension}".Replace(".", "").PadLeft(3) : files[i].Name.Substring(0, 7).PadRight(7) +
                            " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                if (fileName == list[pos][0])
                    return true;
            }
            return false;
        }

        public void OpenDirectory(int pos, List<string[]> list, DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {
            if (!isFile(pos, list, dirR, dirL, panel))
            {
                string dirName = "";

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
                        if (dirL.FullName != dirL.Root.FullName && panel == "left" || dirR.FullName != dirR.Root.FullName && panel == "right")
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
            else
            {
                string fileName = "";
                string name = "";
                FileInfo[] files;
                if (panel == "right")
                    files = dirR.GetFiles();
                else
                    files = dirL.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Extension == "" && files[i].Name.Length <= 8)
                        fileName = $"{files[i].Name}".PadRight(7) + "     ".PadLeft(5);
                    else if (files[i].Extension == "")
                        fileName = $"{files[i].Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                    else if (files[i].Name.Replace(files[i].Extension, "").Length <= 8)
                        fileName = files[i].Extension.Length <= 4 ? $"{files[i].Name}".Replace(files[i].Extension, "").PadRight(8) +
                        " " + $"{files[i].Extension}".Replace(".", "").PadLeft(3) : $"{files[i].Name}".
                        Replace(files[i].Extension, "").PadRight(7) + " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                    else
                        fileName = files[i].Extension.Length <= 4 ? files[i].Name.Replace(files[i].Extension, "").Substring(0, 8).PadRight(8) + " " +
                                $"{files[i].Extension}".Replace(".", "").PadLeft(3) : files[i].Name.Substring(0, 7).PadRight(7) +
                                " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                    if (fileName == list[pos][0])
                    {
                        fileName = files[i].FullName;
                        name = $"{files[i].Extension}".Replace(".", "");
                        break;
                    }
                }
                if (name == "txt")
                    Process.Start("Notepad.exe", fileName);
                if (name == "jpg" || name == "bmp" || name == "gif" || name == "tiff" || name == "png")
                    Process.Start("mspaint.exe", fileName);
                else
                    Process.Start(fileName);
            }

        }


        public void TabDisc(DirectoryInfo dirR, DirectoryInfo dirL, string panel)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string[] discs = new string[allDrives.Length];
            int i = 0;
            foreach (var item in allDrives)
            {
                discs[i++] = item.Name.Substring(0, 1);
            }
            Menu.GorizontMenu(discs, dirR, dirL, panel);
        }

        public void ChangeDisc(string[] discs, string panel, int pos)
        {
            if (panel == "right")
                pathR = discs[pos] + ":\\";
            else
                pathL = discs[pos] + ":\\";
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
                nameL = nameL.Length <= 12 ? dirL.Name.PadRight(12) : dirL.Name.Substring(0, 12);
                launchPanelCommander(pathL, pathR, panel);
            }

        }

        public void ViewFile(List<string[]> list, DirectoryInfo dirR, DirectoryInfo dirL, string panel, int pos)
        {
            string fileName = "";
            FileInfo[] files;
            if (panel == "right")
                files = dirR.GetFiles();
            else
                files = dirL.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension == "" && files[i].Name.Length <= 8)
                    fileName = $"{files[i].Name}".PadRight(7) + "     ".PadLeft(5);
                else if (files[i].Extension == "")
                    fileName = $"{files[i].Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                else if (files[i].Name.Replace(files[i].Extension, "").Length <= 8)
                    fileName = files[i].Extension.Length <= 4 ? $"{files[i].Name}".Replace(files[i].Extension, "").PadRight(8) +
                    " " + $"{files[i].Extension}".Replace(".", "").PadLeft(3) : $"{files[i].Name}".
                    Replace(files[i].Extension, "").PadRight(7) + " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                else
                    fileName = files[i].Extension.Length <= 4 ? files[i].Name.Replace(files[i].Extension, "").Substring(0, 8).PadRight(8) + " " +
                            $"{files[i].Extension}".Replace(".", "").PadLeft(3) : files[i].Name.Substring(0, 7).PadRight(7) +
                            " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                if (fileName == list[pos][0])
                {
                    fileName = files[i].FullName;
                    break;
                }
            }
            Process.Start("Notepad.exe", fileName);

        }

        public void EditFile(List<string[]> list, DirectoryInfo dirR, DirectoryInfo dirL, string panel, int pos)
        {
            string fileName = "";
            FileInfo[] files;
            if (panel == "right")
                files = dirR.GetFiles();
            else
                files = dirL.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension == "" && files[i].Name.Length <= 8)
                    fileName = $"{files[i].Name}".PadRight(7) + "     ".PadLeft(5);
                else if (files[i].Extension == "")
                    fileName = $"{files[i].Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                else if (files[i].Name.Replace(files[i].Extension, "").Length <= 8)
                    fileName = files[i].Extension.Length <= 4 ? $"{files[i].Name}".Replace(files[i].Extension, "").PadRight(8) +
                    " " + $"{files[i].Extension}".Replace(".", "").PadLeft(3) : $"{files[i].Name}".
                    Replace(files[i].Extension, "").PadRight(7) + " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                else
                    fileName = files[i].Extension.Length <= 4 ? files[i].Name.Replace(files[i].Extension, "").Substring(0, 8).PadRight(8) + " " +
                            $"{files[i].Extension}".Replace(".", "").PadLeft(3) : files[i].Name.Substring(0, 7).PadRight(7) +
                            " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                if (fileName == list[pos][0])
                {
                    fileName = files[i].FullName;
                    break;
                }
            }
            Process.Start("Notepad.exe", fileName);
        }

        public void DellDirectoryFile(List<string[]> list, DirectoryInfo dirR, DirectoryInfo dirL, string panel, int pos, bool bl)
        {
            string dirName = "";
            string fileName = "";
            int count = 0;
            if (panel == "right")
            {
                DirectoryInfo[] dirs = dirR.GetDirectories();
                for (int i = 0; i < dirs.Length; i++)
                {
                    dirName = dirs[i].Name.Length <= 12 ? dirs[i].Name.PadRight(12) : dirs[i].Name.Substring(0, 12);
                    if (dirName == list[pos][0])
                    {
                        dirName = dirs[i].FullName;
                        count++;
                        break;
                    }
                }
                if (count > 0)
                {
                    if (dirR.FullName != dirR.Root.FullName)
                    {
                        pathR = dirR.FullName;
                        nameR = dirR.Name;
                        nameR = nameR.Length <= 12 ? dirR.Name.PadRight(12) : dirR.Name.Substring(0, 12);
                    }
                }
                else
                {
                    FileInfo[] files = dirR.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Extension == "" && files[i].Name.Length <= 8)
                            fileName = $"{files[i].Name}".PadRight(7) + "     ".PadLeft(5);
                        else if (files[i].Extension == "")
                            fileName = $"{files[i].Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                        else if (files[i].Name.Replace(files[i].Extension, "").Length <= 8)
                            fileName = files[i].Extension.Length <= 4 ? $"{files[i].Name}".Replace(files[i].Extension, "").PadRight(8) +
                            " " + $"{files[i].Extension}".Replace(".", "").PadLeft(3) : $"{files[i].Name}".
                            Replace(files[i].Extension, "").PadRight(7) + " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        else
                            fileName = files[i].Extension.Length <= 4 ? files[i].Name.Replace(files[i].Extension, "").Substring(0, 8).PadRight(8) + " " +
                                    $"{files[i].Extension}".Replace(".", "").PadLeft(3) : files[i].Name.Substring(0, 7).PadRight(7) +
                                    " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        if (fileName == list[pos][0])
                        {
                            fileName = files[i].FullName;
                            break;
                        }
                    }
                    File.Delete(fileName);
                    if (bl)
                    {
                        draw.DrawWindowDell("File Delete!");
                        Thread.Sleep(2000);
                    }
                    pathR = dirR.FullName;
                    pathL = dirL.FullName;
                    launchPanelCommander(pathL, pathR, panel);
                }
            }
            else
            {
                DirectoryInfo[] dirs = dirL.GetDirectories();
                for (int i = 0; i < dirs.Length; i++)
                {
                    dirName = dirs[i].Name.Length <= 12 ? dirs[i].Name.PadRight(12) : dirs[i].Name.Substring(0, 12);
                    if (dirName == list[pos][0])
                    {
                        dirName = dirs[i].FullName;
                        count++;
                        break;
                    }
                }
                if (count > 0)
                {
                    if (dirL.FullName != dirL.Root.FullName)
                    {
                        pathL = dirL.FullName;
                        nameL = dirL.Name;
                        nameL = nameL.Length <= 12 ? dirL.Name.PadRight(12) : dirL.Name.Substring(0, 12);

                    }
                }
                else
                {
                    FileInfo[] files = dirL.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Extension == "" && files[i].Name.Length <= 8)
                            fileName = $"{files[i].Name}".PadRight(7) + "     ".PadLeft(5);
                        else if (files[i].Extension == "")
                            fileName = $"{files[i].Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                        else if (files[i].Name.Replace(files[i].Extension, "").Length <= 8)
                            fileName = files[i].Extension.Length <= 4 ? $"{files[i].Name}".Replace(files[i].Extension, "").PadRight(8) +
                            " " + $"{files[i].Extension}".Replace(".", "").PadLeft(3) : $"{files[i].Name}".
                            Replace(files[i].Extension, "").PadRight(7) + " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        else
                            fileName = files[i].Extension.Length <= 4 ? files[i].Name.Replace(files[i].Extension, "").Substring(0, 8).PadRight(8) + " " +
                                    $"{files[i].Extension}".Replace(".", "").PadLeft(3) : files[i].Name.Substring(0, 7).PadRight(7) +
                                    " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        if (fileName == list[pos][0])
                        {
                            fileName = files[i].FullName;
                            break;
                        }
                    }
                    File.Delete(fileName);
                    draw.DrawWindowDell("File Delete!");
                    Thread.Sleep(2000);
                    pathR = dirR.FullName;
                    pathL = dirL.FullName;
                    launchPanelCommander(pathL, pathR, panel);
                }
            }
            try
            {
                Directory.Delete(dirName, true);
                if (bl)
                {
                    draw.DrawWindowDell("Directory Delete!");
                    Thread.Sleep(2000);
                }
                pathR = dirR.FullName;
                pathL = dirL.FullName;
                launchPanelCommander(pathL, pathR, panel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CopyDirectoryFile(List<string[]> list, DirectoryInfo dirR, DirectoryInfo dirL, string panel, int pos, bool bl)
        {
            string dirName = "";
            string fileName = "";
            int count = 0;
            if (panel == "right")
            {
                if (list[pos][0] == "..".PadRight(12))
                    pos++;
                DirectoryInfo[] dirs = dirR.GetDirectories();
                for (int i = 0; i < dirs.Length; i++)
                {
                    dirName = dirs[i].Name.Length <= 12 ? dirs[i].Name.PadRight(12) : dirs[i].Name.Substring(0, 12);
                    if (dirName == list[pos][0])
                    {
                        count++;
                        break;
                    }
                }
                if (count > 0)
                {
                    if (!Directory.EnumerateFiles(dirR.FullName + "\\" + dirName, "*.*", SearchOption.AllDirectories).Any())
                    {
                        nameL = dirName;
                        string name = $"{dirL.FullName}" + "\\" + nameL;
                        DirectoryInfo newDir = new DirectoryInfo(name);
                        if (!newDir.Exists)
                        {
                            newDir.Create();
                        }
                        pathL = newDir.FullName;
                        nameL = nameL.Length <= 12 ? dirL.Name.PadRight(12) : dirL.Name.Substring(0, 12);
                    }
                    else
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            dirName = dirs[i].Name.Length <= 12 ? dirs[i].Name.PadRight(12) : dirs[i].Name.Substring(0, 12);
                            if (dirName == list[pos][0])
                            {
                                pathR = dirs[i].FullName;
                                nameL = dirs[i].Name;
                                break;
                            }
                        }
                        string name = $"{dirL.FullName}" + "\\" + nameL;
                        DirectoryInfo newDir = new DirectoryInfo(name);
                        if (!newDir.Exists)
                        {
                            newDir.Create();
                        }
                        pathL = newDir.FullName;
                        nameL = nameL.Length <= 12 ? dirL.Name.PadRight(12) : dirL.Name.Substring(0, 12);
                        DirectoryInfo dir = new DirectoryInfo(pathR);
                        FileInfo[] files = dir.GetFiles();
                        for (int i = 0; i < files.Length; i++)
                        {
                            FileInfo file = new FileInfo(files[i].FullName);
                            file.CopyTo(pathL + "\\" + files[i].Name, true);
                        }
                        DirectoryInfo[] newDirs = dir.GetDirectories();
                        if (newDirs.Length > 0)
                        {
                            dirR = new DirectoryInfo(pathR);
                            dirL = new DirectoryInfo(pathL);
                            for (int i = 0; i < newDirs.Length; i++)
                            {
                                CopyDirectoryFile(panels.ConvertDirToList(dir), dirR, dirL, panel, i, false);
                            }

                        }
                    }
                }
                else
                {
                    string nameFile = "";
                    FileInfo[] files = dirR.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Extension == "" && files[i].Name.Length <= 8)
                            fileName = $"{files[i].Name}".PadRight(7) + "     ".PadLeft(5);
                        else if (files[i].Extension == "")
                            fileName = $"{files[i].Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                        else if (files[i].Name.Replace(files[i].Extension, "").Length <= 8)
                            fileName = files[i].Extension.Length <= 4 ? $"{files[i].Name}".Replace(files[i].Extension, "").PadRight(8) +
                            " " + $"{files[i].Extension}".Replace(".", "").PadLeft(3) : $"{files[i].Name}".
                            Replace(files[i].Extension, "").PadRight(7) + " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        else
                            fileName = files[i].Extension.Length <= 4 ? files[i].Name.Replace(files[i].Extension, "").Substring(0, 8).PadRight(8) + " " +
                                    $"{files[i].Extension}".Replace(".", "").PadLeft(3) : files[i].Name.Substring(0, 7).PadRight(7) +
                                    " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        if (fileName == list[pos][0])
                        {
                            fileName = files[i].FullName;
                            nameFile = files[i].Name;
                            break;
                        }
                    }
                    File.Copy(fileName, dirL.FullName + "\\" + nameFile, true);
                    pathR = dirR.FullName;
                    pathL = dirL.FullName;
                    if (bl)
                        launchPanelCommander(pathL, pathR, panel);

                }

                pathR = dirR.Parent.FullName;
                pathL = dirL.Parent.FullName;
                if (bl)
                    launchPanelCommander(pathL, pathR, panel);
            }
            else
            {
                if (list[pos][0] == "..".PadRight(12))
                    pos++;
                DirectoryInfo[] dirs = dirL.GetDirectories();
                for (int i = 0; i < dirs.Length; i++)
                {
                    dirName = dirs[i].Name.Length <= 12 ? dirs[i].Name.PadRight(12) : dirs[i].Name.Substring(0, 12);
                    if (dirName == list[pos][0])
                    {
                        count++;
                        break;
                    }
                }
                if (count > 0)
                {
                    if (!Directory.EnumerateFiles(dirL.FullName + "\\" + dirName, "*.*", SearchOption.AllDirectories).Any())
                    {
                        nameL = dirName;
                        string name = $"{dirR.FullName}" + "\\" + nameL;
                        DirectoryInfo newDir = new DirectoryInfo(name);
                        if (!newDir.Exists)
                        {
                            newDir.Create();
                        }
                        pathR = newDir.FullName;
                        nameR = nameL.Length <= 12 ? dirL.Name.PadRight(12) : dirL.Name.Substring(0, 12);
                    }
                    else
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            dirName = dirs[i].Name.Length <= 12 ? dirs[i].Name.PadRight(12) : dirs[i].Name.Substring(0, 12);
                            if (dirName == list[pos][0])
                            {
                                pathL = dirs[i].FullName;
                                nameR = dirs[i].Name;
                                break;
                            }
                        }
                        string name = $"{dirR.FullName}" + "\\" + nameR;
                        DirectoryInfo newDir = new DirectoryInfo(name);
                        if (!newDir.Exists)
                        {
                            newDir.Create();
                        }
                        pathR = newDir.FullName;
                        nameR = nameR.Length <= 12 ? dirL.Name.PadRight(12) : dirL.Name.Substring(0, 12);
                        DirectoryInfo dir = new DirectoryInfo(pathL);
                        FileInfo[] files = dir.GetFiles();
                        for (int i = 0; i < files.Length; i++)
                        {
                            FileInfo file = new FileInfo(files[i].FullName);
                            file.CopyTo(pathR + "\\" + files[i].Name, true);
                        }
                        DirectoryInfo[] newDirs = dir.GetDirectories();
                        if (newDirs.Length > 0)
                        {
                            dirR = new DirectoryInfo(pathR);
                            dirL = new DirectoryInfo(pathL);
                            for (int i = 0; i < newDirs.Length; i++)
                            {
                                CopyDirectoryFile(panels.ConvertDirToList(dir), dirR, dirL, panel, i, false);
                            }

                        }
                    }
                }
                else
                {
                    string nameFile = "";
                    FileInfo[] files = dirL.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Extension == "" && files[i].Name.Length <= 8)
                            fileName = $"{files[i].Name}".PadRight(7) + "     ".PadLeft(5);
                        else if (files[i].Extension == "")
                            fileName = $"{files[i].Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                        else if (files[i].Name.Replace(files[i].Extension, "").Length <= 8)
                            fileName = files[i].Extension.Length <= 4 ? $"{files[i].Name}".Replace(files[i].Extension, "").PadRight(8) +
                            " " + $"{files[i].Extension}".Replace(".", "").PadLeft(3) : $"{files[i].Name}".
                            Replace(files[i].Extension, "").PadRight(7) + " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        else
                            fileName = files[i].Extension.Length <= 4 ? files[i].Name.Replace(files[i].Extension, "").Substring(0, 8).PadRight(8) + " " +
                                    $"{files[i].Extension}".Replace(".", "").PadLeft(3) : files[i].Name.Substring(0, 7).PadRight(7) +
                                    " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        if (fileName == list[pos][0])
                        {
                            fileName = files[i].FullName;
                            nameFile = files[i].Name;
                            break;
                        }
                    }
                    File.Copy(fileName, dirR.FullName + "\\" + nameFile, true);
                    pathR = dirR.FullName;
                    pathL = dirL.FullName;
                    if (bl)
                        launchPanelCommander(pathL, pathR, panel);
                }

                pathR = dirR.Parent.FullName;
                pathL = dirL.Parent.FullName;
                if (bl)
                    launchPanelCommander(pathL, pathR, panel);
            }
        }


        public void MoveDirectoryFile(List<string[]> list, DirectoryInfo dirR, DirectoryInfo dirL, string panel, int pos)
        {
            string dirName = "";
            string fileName = "";
            string name = "";
            int count = 0;
            if (panel == "right")
            {
                if (list[pos][0] == "..".PadRight(12))
                    pos++;
                DirectoryInfo[] dirs = dirR.GetDirectories();
                for (int i = 0; i < dirs.Length; i++)
                {
                    dirName = dirs[i].Name.Length <= 12 ? dirs[i].Name.PadRight(12) : dirs[i].Name.Substring(0, 12);
                    if (dirName == list[pos][0])
                    {
                        dirName = dirs[i].FullName;
                        name = dirs[i].Parent.FullName;
                        count++;
                        break;
                    }
                }
                if (count > 0)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine(dirName);
                    Console.SetCursorPosition(35, 11);
                    Console.Write("New Name: ");
                    string newName = Console.ReadLine();
                    if (newName == "")
                    {
                        DirectoryInfo dir = new DirectoryInfo(dirR.FullName);

                        CopyDirectoryFile(panels.ConvertDirToList(dir), dirR, dirL, panel, pos, false);
                        DellDirectoryFile(panels.ConvertDirToList(dir), dirR, dirL, panel, pos, false);
                    }
                    else
                        Directory.Move(dirName, name + "\\" + newName);

                }
                else
                {
                    string nameFile = "";
                    FileInfo[] files = dirR.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Extension == "" && files[i].Name.Length <= 8)
                            fileName = $"{files[i].Name}".PadRight(7) + "     ".PadLeft(5);
                        else if (files[i].Extension == "")
                            fileName = $"{files[i].Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                        else if (files[i].Name.Replace(files[i].Extension, "").Length <= 8)
                            fileName = files[i].Extension.Length <= 4 ? $"{files[i].Name}".Replace(files[i].Extension, "").PadRight(8) +
                            " " + $"{files[i].Extension}".Replace(".", "").PadLeft(3) : $"{files[i].Name}".
                            Replace(files[i].Extension, "").PadRight(7) + " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        else
                            fileName = files[i].Extension.Length <= 4 ? files[i].Name.Replace(files[i].Extension, "").Substring(0, 8).PadRight(8) + " " +
                                    $"{files[i].Extension}".Replace(".", "").PadLeft(3) : files[i].Name.Substring(0, 7).PadRight(7) +
                                    " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        if (fileName == list[pos][0])
                        {
                            fileName = files[i].FullName;
                            nameFile = files[i].Name;
                            name = files[i].Extension;
                            break;
                        }
                    }
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine(fileName);
                    Console.SetCursorPosition(35, 11);
                    Console.Write("New Name: ");
                    string newName = Console.ReadLine();
                    if (newName == "")
                        File.Move(fileName, dirL.FullName + "\\" + nameFile);
                    else
                        File.Move(fileName, dirR.FullName + "\\" + newName + name);
                    pathR = dirR.FullName;
                    pathL = dirL.FullName;
                    launchPanelCommander(pathL, pathR, panel);
                }
                pathR = dirR.FullName;
                pathL = dirL.FullName;
                launchPanelCommander(pathL, pathR, panel);
            }
            else
            {
                if (list[pos][0] == "..".PadRight(12))
                    pos++;
                DirectoryInfo[] dirs = dirL.GetDirectories();
                for (int i = 0; i < dirs.Length; i++)
                {
                    dirName = dirs[i].Name.Length <= 12 ? dirs[i].Name.PadRight(12) : dirs[i].Name.Substring(0, 12);
                    if (dirName == list[pos][0])
                    {
                        dirName = dirs[i].FullName;
                        count++;
                        break;
                    }
                }
                if (count > 0)
                {
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine(dirName);
                    Console.SetCursorPosition(35, 11);
                    Console.Write("New Name: ");
                    string newName = Console.ReadLine();

                    if (newName == "")
                    {
                        DirectoryInfo dir = new DirectoryInfo(dirL.FullName);

                        CopyDirectoryFile(panels.ConvertDirToList(dir), dirR, dirL, panel, pos, false);
                        DellDirectoryFile(panels.ConvertDirToList(dir), dirR, dirL, panel, pos, false);
                    }
                    else
                        Directory.Move(dirName, name + "\\" + newName);

                }
                else
                {
                    string nameFile = "";
                    FileInfo[] files = dirL.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Extension == "" && files[i].Name.Length <= 8)
                            fileName = $"{files[i].Name}".PadRight(7) + "     ".PadLeft(5);
                        else if (files[i].Extension == "")
                            fileName = $"{files[i].Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                        else if (files[i].Name.Replace(files[i].Extension, "").Length <= 8)
                            fileName = files[i].Extension.Length <= 4 ? $"{files[i].Name}".Replace(files[i].Extension, "").PadRight(8) +
                            " " + $"{files[i].Extension}".Replace(".", "").PadLeft(3) : $"{files[i].Name}".
                            Replace(files[i].Extension, "").PadRight(7) + " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        else
                            fileName = files[i].Extension.Length <= 4 ? files[i].Name.Replace(files[i].Extension, "").Substring(0, 8).PadRight(8) + " " +
                                    $"{files[i].Extension}".Replace(".", "").PadLeft(3) : files[i].Name.Substring(0, 7).PadRight(7) +
                                    " " + $"{files[i].Extension}".Replace(".", "").PadLeft(4);
                        if (fileName == list[pos][0])
                        {
                            fileName = files[i].FullName;
                            nameFile = files[i].Name;
                            name = files[i].Extension;
                            break;
                        }
                    }
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine(fileName);
                    Console.SetCursorPosition(35, 11);
                    Console.Write("New Name: ");
                    string newName = Console.ReadLine();
                    if (newName == "")
                        File.Move(fileName, dirR.FullName + "\\" + nameFile);
                    else
                        File.Move(fileName, dirL.FullName + "\\" + newName + name);
                    pathR = dirR.FullName;
                    pathL = dirL.FullName;
                    launchPanelCommander(pathL, pathR, panel);
                }
                pathR = dirR.FullName;
                pathL = dirL.FullName;
                launchPanelCommander(pathL, pathR, panel);
            }
        }
    }
}
