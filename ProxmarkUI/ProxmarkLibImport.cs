using System;

namespace ProxmarkInterop
{
    public static class ProxmarkLibImport
    {
        public static IProxmarkLibImport Select()
        {
            if (IntPtr.Size == 4) // 32-bit application
            {
                return new ProxmarkLibImport_x86();
            }
            else // 64-bit application
            {
                return new ProxmarkLibImport_x64();
            }
        }
    }
}
