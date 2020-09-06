using System.Runtime.InteropServices;

namespace ProxmarkInterop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void Notification(string value);

    public interface IProxmarkLibImport
    {
        int ProcessData(int start, int count, Notification notification);
        void ComputeReaderMAC(byte[] key, byte[] csn, byte[] cc_nr, Notification notification);
        void ComputeMAC(byte[] divKey, byte[] data, int size, int isOptimise, Notification notification);
        void ComputeCRC(byte[] data, int size, Notification notification);
        void EncryptBlock(byte[] data, byte[] key, int mode, Notification notification);
    }
}