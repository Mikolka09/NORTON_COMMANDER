﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NortonCommander
{
    class ConvertPanels
    {
        public List<string[]> ConvertDirToList(DirectoryInfo dir)
        {
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            List<string[]> list = new List<string[]>();
            string[] strD;
            string[] strF;
            int i = 0;
            if (dir.FullName != dir.Root.FullName)
            {
                strD = new string[4];
                strD[i++] = $"..".PadRight(12);
                strD[i++] = $">UP--DIR<".PadLeft(9);
                strD[i++] = $"{DateTime.Now.Date:dd-MM-yy}".PadLeft(8);
                strD[i++] = $"{DateTime.Now.ToShortTimeString()}".PadLeft(6);
                list.Add(strD);
            }
            foreach (var item in dirs)
            {
                if (item.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;
                else if (item.Name.Length <= 12)
                {
                    i = 0;
                    strD = new string[4];
                    strD[i++] = $"{item.Name}".PadRight(12);
                    strD[i++] = ">SUB-DIR<";
                    strD[i++] = $"{item.CreationTimeUtc.Date:dd-MM-yy}";
                    strD[i++] = $"{item.CreationTimeUtc.ToShortTimeString()}".PadLeft(6);
                    list.Add(strD);
                }
                else
                {
                    i = 0;
                    strD = new string[4];
                    strD[i++] = item.Name.Substring(0, 12);
                    strD[i++] = ">SUB-DIR<";
                    strD[i++] = $"{item.CreationTimeUtc.Date:dd-MM-yy}";
                    strD[i++] = $"{item.CreationTimeUtc.ToShortTimeString()}".PadLeft(6);
                    list.Add(strD);
                }
                i++;
            }
            foreach (var item in files)
            {

                if (item.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;
                else if (item.Extension == "" && item.Name.Length <= 8)
                {
                    i = 0;
                    strF = new string[4];

                    strF[i++] = $"{item.Name}".PadRight(7) + "     ".PadLeft(5);
                    strF[i++] = $"{item.Length}".Length <= 9 ? $"{item.Length}".PadLeft(9) : $"{item.Length}".Substring(0, 9);
                    strF[i++] = $"{item.CreationTimeUtc.Date:dd-MM-yy}";
                    strF[i++] = $"{item.CreationTimeUtc.ToShortTimeString()}".PadLeft(6);
                    list.Add(strF);
                }
                else if (item.Extension == "")
                {
                    i = 0;
                    strF = new string[4];

                    strF[i++] = $"{item.Name}".Substring(0, 7).PadRight(8) + " ".PadLeft(4);
                    strF[i++] = $"{item.Length}".Length <= 9 ? $"{item.Length}".PadLeft(9) : $"{item.Length}".Substring(0, 9);
                    strF[i++] = $"{item.CreationTimeUtc.Date:dd-MM-yy}";
                    strF[i++] = $"{item.CreationTimeUtc.ToShortTimeString()}".PadLeft(6);
                    list.Add(strF);
                }
                else if (item.Name.Replace(item.Extension, "").Length <= 8)
                {
                    i = 0;
                    strF = new string[4];

                    strF[i++] = item.Extension.Length <= 4 ? $"{item.Name}".Replace(item.Extension, "").PadRight(8) +
                        " " + $"{item.Extension}".Replace(".", "").PadLeft(3) : $"{item.Name}".
                        Replace(item.Extension, "").PadRight(7) + " " + $"{item.Extension}".Replace(".", "").PadLeft(4);
                    strF[i++] = $"{item.Length}".Length <= 9 ? $"{item.Length}".PadLeft(9) : $"{item.Length}".Substring(0, 9);
                    strF[i++] = $"{item.CreationTimeUtc.Date:dd-MM-yy}";
                    strF[i++] = $"{item.CreationTimeUtc.ToShortTimeString()}".PadLeft(6);
                    list.Add(strF);
                }
                else
                {
                    i = 0;
                    strF = new string[4];
                    strF[i++] = item.Extension.Length <= 4 ? item.Name.Replace(item.Extension, "").Substring(0, 8).PadRight(8) + " " + $"{item.Extension}".
                    Replace(".", "").PadLeft(3) : item.Name.Substring(0, 7).PadRight(7) + " " + $"{item.Extension}".Replace(".", "").PadLeft(4);
                    strF[i++] = $"{item.Length}".Length <= 9 ? $"{item.Length}".PadLeft(9) : $"{item.Length}".Substring(0, 9);
                    strF[i++] = $"{item.CreationTimeUtc.Date:dd-MM-yy}";
                    strF[i++] = $"{item.CreationTimeUtc.ToShortTimeString()}".PadLeft(6);
                    list.Add(strF);
                }
            }
            return list;
        }
    }
}
