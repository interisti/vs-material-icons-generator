using Microsoft.VisualStudio.Shell.Interop;

namespace VSMaterialIcons.VS
{
    public class StatusBar
    {
        public static void DisplayMessage(string message)
        {
            var statusBar = ServiceLocator.GetGlobalService<SVsStatusbar, IVsStatusbar>();

            // Make sure the status bar is not frozen
            int frozen;
            statusBar.IsFrozen(out frozen);
            if (frozen != 0)
                statusBar.FreezeOutput(0);

            object icon = (short)Constants.SBAI_Deploy;
            statusBar.Animation(1, ref icon);
            statusBar.SetText(message);
        }

        public static void Clear()
        {
            var statusBar = ServiceLocator.GetGlobalService<SVsStatusbar, IVsStatusbar>();

            object icon = (short)Constants.SBAI_Deploy;
            statusBar.Animation(0, ref icon);
            statusBar.SetText("");
            statusBar.Clear();
        }
    }
}
