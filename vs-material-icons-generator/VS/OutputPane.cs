using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace VSMaterialIcons.VS
{
    public class OutputPane
    {
        public static void Output(string message)
        {
            var outputPane = ServiceLocator.GetGlobalService<SVsGeneralOutputWindowPane, IVsOutputWindowPane>();

            outputPane.OutputStringThreadSafe(message + Environment.NewLine);
        }

        public static void Activate()
        {
            var outputPane = ServiceLocator.GetGlobalService<SVsGeneralOutputWindowPane, IVsOutputWindowPane>();

            outputPane.Activate();
        }
    }
}
