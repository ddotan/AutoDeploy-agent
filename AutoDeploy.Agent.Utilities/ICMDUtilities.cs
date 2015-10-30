using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDeploy.Agent.Utilities
{
    public interface ICMDUtilities
    {
        void ExecuteCmdCommand(params string[] i_Commands);
    }
}
