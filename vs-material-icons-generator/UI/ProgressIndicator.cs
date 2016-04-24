using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSMaterialIcons.UI
{
    class ProgressIndicator
    {
        public ProgressIndicator(IVsStatusbar statusBar)
        {
            this.StatusBar = statusBar;
        }

        public IVsStatusbar StatusBar
        {
            get;
            private set;
        }
        
        public void DisplayProgress(string message)
        {
            // Make sure the status bar is not frozen
            int frozen;
            this.StatusBar.IsFrozen(out frozen);
            if (frozen != 0)
                this.StatusBar.FreezeOutput(0);

            object icon = (short)Constants.SBAI_Deploy;
            this.StatusBar.Animation(1, ref icon);
            this.StatusBar.SetText(message);
        }

        public void ClearProgress()
        {
            object icon = (short)Constants.SBAI_Deploy;
            this.StatusBar.Animation(0, ref icon);
            this.StatusBar.SetText("");
            this.StatusBar.Clear();
        }
    }
}
