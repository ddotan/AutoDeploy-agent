using System;
namespace AutoDeploy.Agent.Utilities
{
    public  interface IFolderUtilities
    {
        void CopyFolder(string i_Source, string i_Dest);
        void DeleteFolder(string i_Path);
        bool Exists(string i_Path);
        string GetExecutablePath(string i_FolderPath);
        void RenameFolder(string i_SourcePath, string i_DestPath);
    }
}
