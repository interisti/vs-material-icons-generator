using System;

namespace MaterialIconsGenerator.Core.Utils
{
    public static class OSUtils
    {
        public static bool ISRunningOnWindows()
        {
            int p = (int)Environment.OSVersion.Platform;
            if ((p == 4) || (p == 6) || (p == 128))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
