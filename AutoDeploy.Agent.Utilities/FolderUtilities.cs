using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoDeploy.Agent.Utilities
{
    public  class FolderUtilities : IFolderUtilities
    {
        public  void DeleteFolder(string i_Path)
        {
            if (Directory.Exists(i_Path))
            {
                Directory.Delete(i_Path, true);
            }
            else
            {
                throw new Exception("Folder : " + i_Path + " Doesnt exists");
            }
        }
        public  void CopyFolder(string i_Source, string i_Dest)
        {

            string destFile = i_Dest;
            if (Directory.Exists(i_Source))
            {
                foreach (string dir in Directory.GetDirectories(i_Source, "*", System.IO.SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(i_Dest + dir.Substring(i_Source.Length));

                }

                foreach (string file_name in Directory.GetFiles(i_Source, "*.*", System.IO.SearchOption.AllDirectories))
                {
                    File.Copy(file_name, i_Dest + file_name.Substring(i_Source.Length));
                }
            }
            else
            {
                throw new Exception("Folder : " + i_Source + " not exists");
            }
        }
        public  void RenameFolder(string i_SourcePath, string i_DestPath)
        {
            Directory.Move(i_SourcePath, i_DestPath);
        }
        public  bool Exists(string i_Path)
        {
            return Directory.Exists(i_Path);
        }
        public  string GetExecutablePath(string i_FolderPath)
        {
            string executablePath = string.Empty;
            if (Directory.Exists(i_FolderPath))
            {
                string[] Executables = Directory.GetFiles(i_FolderPath, "*.exe");
                if (Executables.Length > 0)
                {
                    executablePath = Executables[0];
                }
            }
            return executablePath;
        }
    }
}

