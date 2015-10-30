using System;
namespace AutoDeploy.Agent.Utilities
{
    public interface IFileUtilities
    {
        void CopyFile(string i_Source, string i_Dest);
        string GetVersion(string i_Path);
    }
}
