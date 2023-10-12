using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPCSC
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SCARD_IO_REQUEST
    {
        /// <summary>
        /// Protocol in use.
        /// </summary>
        public UInt32 dwProtocol;

        /// <summary>
        /// Length, in bytes, of the SCARD_IO_REQUEST structure plus any following PCI-specific information.
        /// </summary>
        public UInt32 cbPciLength;
    }

    /// <summary>
    /// The SCARD READERSTATE structure is used by functions for tracking smart cards within readers.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SCARD_READERSTATE
    {
        /// <summary>
        /// A pointer to the name of the reader being monitored.
        /// Set the value of this member to "\\\\?PnP?\\Notification" 
        /// and the values of all other members to zero to be notified of the arrival of a new smart card reader.
        /// </summary>
        public string m_szReader;

        /// <summary>
        /// Not used by the smart card subsystem. This member is used by the application.
        /// </summary>
        public IntPtr m_pvUserData;

        /// <summary>
        /// Current state of the reader, as seen by the application. This field can take on any of the following values, in combination, as a bitmask. 
        /// </summary>
        public UInt32 m_dwCurrentState;

        /// <summary>
        /// Current state of the reader, as known by the smart card resource manager. This field can take on any of the following values, in combination, as a bitmask. 
        /// </summary>
        public UInt32 m_dwEventState;

        /// <summary>
        /// Number of bytes in the returned ATR.
        /// </summary>
        public UInt32 m_cbAtr;

        /// <summary>
        /// ATR of the inserted card, with extra alignment bytes.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_rgbAtr;
    }
}
