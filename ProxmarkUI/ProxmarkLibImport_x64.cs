using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ProxmarkInterop
{
    internal class ProxmarkLibImport_x64 : IProxmarkLibImport
    {
        [DllImport("ProxmarkLib-x64", CallingConvention = CallingConvention.StdCall, ExactSpelling = false, EntryPoint = "ProcessData")]
        private static extern int ProcessDataInternal(int start, int count, Notification notification);

        public int ProcessData(int start, int count, Notification notification)
        {
            return ProcessDataInternal(start, count, notification);
        }

        [DllImport("ProxmarkLib-x64", CallingConvention = CallingConvention.StdCall, ExactSpelling = false, EntryPoint = "ComputeReaderMAC")]
        private static extern void ComputeReaderMACInternal(byte[] key, byte[] csn, byte[] cc_nr, Notification notification);

        public void ComputeReaderMAC(byte[] key, byte[] csn, byte[] cc_nr, Notification notification)
        {
            ComputeReaderMACInternal(key, csn, cc_nr, notification);
        }

        [DllImport("ProxmarkLib-x64", CallingConvention = CallingConvention.StdCall, ExactSpelling = false, EntryPoint = "ComputeMAC")]
        private static extern void ComputeMACInternal(byte[] divKey, byte[] data, int size, int isOptimize, Notification notification);

        public void ComputeMAC(byte[] divKey, byte[] data, int size, int isOptimize, Notification notification)
        {
            ComputeMACInternal(divKey, data, size, isOptimize, notification);
        }

        [DllImport("ProxmarkLib-x64", CallingConvention = CallingConvention.StdCall, ExactSpelling = false, EntryPoint = "ComputeCRC")]
        private static extern void ComputeCRCInternal(byte[] data, int size, Notification notification);

        public void ComputeCRC(byte[] data, int size, Notification notification)
        {
            ComputeCRCInternal(data, size, notification);
        }

        [DllImport("ProxmarkLib-x64", CallingConvention = CallingConvention.StdCall, ExactSpelling = false, EntryPoint = "EncryptBlock")]
        private static extern void EncryptBlockInternal(byte[] data, byte[] key, int mode, Notification notification);

        public void EncryptBlock(byte[] data, byte[] key, int mode, Notification notification)
        {
            EncryptBlockInternal(data, key, mode, notification);
        }
    }
}
