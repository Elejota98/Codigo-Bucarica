using GS.Apdu;
using GS.Util.Hex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.CRT603Device
{
    public partial class WinSCard
    {
        /// <summary>
        /// A handle to the established resource manager context.
        /// This handle can now be supplied to other functions attempting to do work within this context.
        /// </summary>
        private IntPtr phContext;

        /// <summary>
        /// A handle that identifies the connection to the smart card.
        /// </summary>
        private IntPtr phCARD;

        /// <summary>
        /// List of available readers.
        /// </summary>
        string[] readerStrings;


        /// <summary>
        /// The connected Reader Name
        /// </summary>
        string connectedReaderName;

        /// <summary>
        /// Indicates the established active protocol.
        /// </summary>
        uint activeSCardProtocol;


        /// <summary>
        /// Indicates if the Trace is enabled or not.
        /// </summary>
        private bool scardTrace = true;


        /// <summary>
        /// Initializes a new instance of the <see cref="PCSC"/> class.
        /// </summary>
        public WinSCard()
        {
            this.phContext = (IntPtr)0;
            this.phCARD = (IntPtr)0;
        }

        /// <summary>
        /// The EstablishContext function establishes the smart card resourete manager context.
        /// The context is a user context, and any database operations are performed within the
        /// domain of the user.
        /// </summary>
        public void EstablishContext()
        {
            EstablishContext(SCARD_SCOPE.User);
        }

        /// <summary>
        /// The EstablishContext function establishes the smart card resourete manager context.
        /// </summary>
        /// <param name="dwScope">
        /// Scope of the resource manager context.
        /// </param>
        public void EstablishContext(SCARD_SCOPE dwScope)
        {
            int ret = WinSCardAPIWrapper.SCardEstablishContext((uint)dwScope, IntPtr.Zero, IntPtr.Zero, out phContext);

            if (ret == 0)
            {
                Trace.WriteLineIf(scardTrace, string.Format("    SCard.EstablishContext({0})", (SCARD_SCOPE)dwScope));
            }
            else
            {
                throw new WinSCardException(scardTrace, "SCard.EstablishContext", ret);
            }
        }

        /// <summary>
        /// The SCardListReaders function provides the list of readers.
        /// </summary>
        /// <returns>
        /// The names of available readers.
        /// </returns>
        public string[] ListReaders()
        {
            int pcchReaders = 0;
            readerStrings = null;

            // Get first the mszReaders buffer length
            int ret = WinSCardAPIWrapper.SCardListReaders(phContext, null, null, ref pcchReaders);

            if (ret == 0)
            {
                byte[] mszReaders = new byte[pcchReaders];

                // Get list of readers
                ret = WinSCardAPIWrapper.SCardListReaders(phContext, null, mszReaders, ref pcchReaders);

                if (ret == 0)
                {
                    Trace.WriteLineIf(scardTrace, "    SCard.ListReaders...");

                    if (pcchReaders > 2)
                    {
                        readerStrings = System.Text.Encoding.ASCII.GetString(mszReaders).Substring(0, pcchReaders - 2).Split('\0');

                        for (int i = 0; i < readerStrings.Length; i++)
                        {
                            Trace.WriteLineIf(scardTrace, string.Format("        Reader {0:#0}: {1}", i, readerStrings[i]));
                        }
                    }
                }
                return readerStrings;
            }
            else
            {
                throw new WinSCardException(scardTrace, "SCard.ListReaders", ret);
            }
        }

        /// <summary>
        /// The WaitForCardPresent function blocks execution until there is one card
        /// present in the previous selected reader.
        /// </summary>
        public void WaitForCardPresent()
        {
            if (string.IsNullOrEmpty(this.ReaderName) == false)
            {
                this.WaitForCardPresent(this.connectedReaderName);
            }
        }
        /// <summary>
        /// The WaitForCardPresent function blocks execution until there is one card in the reader.
        /// </summary>
        /// <param name="szReader">
        /// The name of the reader that contains the target card.
        /// </param>
        public bool WaitForCardPresent(string szReader)
        {
            bool ok = false;
            int ret;

            SCARD_READERSTATE[] readerStates = new SCARD_READERSTATE[1];
            readerStates[0].m_szReader = szReader;
            readerStates[0].m_dwEventState = (uint)SCARD_CARD_STATE.UNAWARE;
            readerStates[0].m_dwCurrentState = (uint)SCARD_CARD_STATE.UNAWARE;

            ret = WinSCardAPIWrapper.SCardGetStatusChange(phContext, (uint)10, readerStates, (uint)1);
            if (ret != 0) throw new WinSCardException(scardTrace, "SCard.Connect", ret);

            if ((readerStates[0].m_dwEventState & (uint)SCARD_CARD_STATE.PRESENT) == (uint)SCARD_CARD_STATE.PRESENT)
            {
                ok = true;
            }

            //Trace.WriteLineIf(this.TraceSCard, "    Wait for card present...");

            ret = WinSCardAPIWrapper.SCardGetStatusChange(phContext, (uint)10, readerStates, (uint)1);
            if (ret != 0)
            {
                throw new WinSCardException(scardTrace, "SCard.Connect", ret);
            }


            if ((readerStates[0].m_dwEventState & (uint)SCARD_CARD_STATE.PRESENT) == (uint)SCARD_CARD_STATE.PRESENT)
            {
                ok = true;
            }

            return ok;

        }

        /// <summary>
        /// The WaitForCardRemoval function blocks execution until there is no card         
        /// present in the previous selected the selected reader.
        /// </summary>
        public void WaitForCardRemoval()
        {
            if (string.IsNullOrEmpty(this.ReaderName) == false)
            {
                this.WaitForCardRemoval(this.connectedReaderName);
            }
        }

        /// <summary>
        /// The WaitForCardRemoval function blocks execution until there is no card in the reader.
        /// </summary>
        /// <param name="szReader">
        /// The name of the reader that contains the target card.
        /// </param>
        public void WaitForCardRemoval(string szReader)
        {
            int ret;

            SCARD_READERSTATE[] readerStates = new SCARD_READERSTATE[1];
            readerStates[0].m_szReader = szReader;
            readerStates[0].m_dwEventState = (uint)SCARD_CARD_STATE.UNAWARE;
            readerStates[0].m_dwCurrentState = (uint)SCARD_CARD_STATE.UNAWARE;

            ret = WinSCardAPIWrapper.SCardGetStatusChange(phContext, (uint)10, readerStates, (uint)1);
            if (ret != 0) throw new WinSCardException(scardTrace, "SCard.Connect", ret);

            if ((readerStates[0].m_dwEventState & (uint)SCARD_CARD_STATE.EMPTY) == (uint)SCARD_CARD_STATE.EMPTY)
            {
                return;
            }
            Trace.WriteLineIf(this.TraceSCard, "    Wait for card removal...");

            do
            {
                ret = WinSCardAPIWrapper.SCardGetStatusChange(phContext, (uint)10, readerStates, (uint)1);
                if (ret != 0) throw new WinSCardException(scardTrace, "SCard.Connect", ret);
            } while ((readerStates[0].m_dwEventState & (uint)SCARD_CARD_STATE.EMPTY) != (uint)SCARD_CARD_STATE.EMPTY);
        }

        /// <summary>
        /// Gets a value indicating whether smart card is present.
        /// </summary>
        /// <param name="szReader">
        /// The name of the reader that contains the target card.
        /// </param>
        /// <value><c>true</c> if [card activated]; otherwise, <c>false</c>.</value>
        public bool GetCardPresentState(string szReader)
        {
            int ret;

            SCARD_READERSTATE[] readerStates = new SCARD_READERSTATE[1];
            readerStates[0].m_szReader = szReader;
            readerStates[0].m_dwEventState = (uint)SCARD_CARD_STATE.UNAWARE;
            readerStates[0].m_dwCurrentState = (uint)SCARD_CARD_STATE.UNAWARE;

            ret = WinSCardAPIWrapper.SCardGetStatusChange(phContext, (uint)100, readerStates, (uint)1);
            if (ret != 0) throw new WinSCardException(scardTrace, "SCard.Connect", ret);

            if ((readerStates[0].m_dwEventState & (uint)SCARD_CARD_STATE.PRESENT) == (uint)SCARD_CARD_STATE.PRESENT)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// The SCardConnect function establishes a connection (using a specific resource manager context) 
        /// between the calling application and a smart card contained by a specific reader. 
        /// If no card exists in the specified reader, an error is returned.
        /// </summary>
        /// <param name="szReader">
        /// The name of the reader that contains the target card.
        /// </param>
        public void Connect(string szReader)
        {
            Connect(szReader, SCARD_SHARE_MODE.Shared, SCARD_PROTOCOL.Tx);
        }

        /// <summary>
        /// The SCardConnect function establishes a connection (using a specific resource manager context) 
        /// between the calling application and a smart card contained by a specific reader. 
        /// If no card exists in the specified reader, an error is returned.
        /// </summary>
        /// <param name="szReader">
        /// The name of the reader that contains the target card.
        /// </param>
        /// <param name="dwShareMode">
        /// A flag that indicates whether other applications may form connections to the card.
        /// </param>
        /// <param name="dwPrefProtocol">
        /// A bitmask of acceptable protocols for the connection. Possible values may be combined with the OR operation.
        /// </param>
        public void Connect(string szReader, SCARD_SHARE_MODE dwShareMode, SCARD_PROTOCOL dwPrefProtocol)
        {

            int ret = WinSCardAPIWrapper.SCardConnect(phContext, szReader, (uint)dwShareMode, (uint)dwPrefProtocol, out phCARD, out activeSCardProtocol);
            if (ret == 0)
            {
                connectedReaderName = szReader;
                Trace.WriteLineIf(scardTrace, String.Format("    SCard.Connect({0}, SHARE_MODE.{1}, SCARD_PROTOCOL.{2})",
                                                                  szReader, dwShareMode, (SCARD_PROTOCOL)dwPrefProtocol));
                Trace.WriteLineIf(scardTrace, String.Format("        Active Protocol: SCARD_PROTOCOL.{0} ", (SCARD_PROTOCOL)activeSCardProtocol));
                Trace.WriteLineIf(this.TraceSCard, HexFormatting.Dump("        ATR: 0x", this.Atr, this.Atr.Length, 24));
            }
            else
            {
                connectedReaderName = null;
                throw new WinSCardException(scardTrace, "SCard.Connect", ret);
                //Trace.WriteLineIf(pcscTrace, String.Format("    Error: SCardConnect failed with 0x{0:X8}.", ret));
            }
        }

        /// <summary>
        /// The SCardTransmit function sends a service request to the smart card and expects to receive data back from the card.
        /// </summary>
        /// <param name="sendBuffer">
        /// The actual data to be written to the card.
        /// </param>
        /// <param name="sendLength">
        /// The length, in bytes, of the sendBuffer parameter.
        /// </param>
        /// <param name="responseBuffer">
        /// Returned data from the card.
        /// </param>
        /// <param name="responseLength">
        /// Supplies the length, in bytes, of the responseBuffer parameter and receives the actual
        /// number of bytes received from the smart card.
        /// </param>
        public void Transmit(byte[] sendBuffer, int sendLength, byte[] responseBuffer, ref int responseLength)
        {
            SCARD_IO_REQUEST SCARD_PCI;
            SCARD_PCI.dwProtocol = (uint)activeSCardProtocol;
            SCARD_PCI.cbPciLength = 8;

            Trace.WriteLineIf(this.scardTrace, HexFormatting.Dump("--> C-APDU: 0x", sendBuffer, sendLength, 16, ValueFormat.HexASCII));

            int ret = WinSCardAPIWrapper.SCardTransmit(phCARD, ref SCARD_PCI, sendBuffer,
                                                     sendLength,
                                                     IntPtr.Zero,
                                                     responseBuffer,
                                                     ref responseLength);

            if (ret == 0)
            {
                RespApdu respApdu = new RespApdu(responseBuffer, responseLength);
                Trace.WriteLineIf(scardTrace, respApdu.ToString());
            }
            else
            {
                throw new WinSCardException(scardTrace, "SCard.Transmit", ret);
            }
        }

        /// <summary>
        /// The SCardGetAttrib function gets the current reader attributes.
        /// It does not affect the state of the reader, driver, or card.
        /// </summary>
        /// <param name="AttrId">
        /// Identifier for the attribute to get.
        /// </param>
        public void GetAttrib(SCARD_ATTR AttrId)
        {
            byte[] respBuffer = new byte[512];
            int respLength = respBuffer.Length;
            GetAttrib(AttrId, respBuffer, ref respLength);
        }

        /// <summary>
        /// The SCardGetAttrib function gets the current reader attributes.
        /// It does not affect the state of the reader, driver, or card.
        /// </summary>
        /// <param name="AttrId">
        /// Identifier for the attribute to get.
        /// </param>
        public void GetAttrib(uint AttrId)
        {
            byte[] respBuffer = new byte[512];
            int respLength = respBuffer.Length;
            GetAttrib(AttrId, respBuffer, ref respLength);
        }

        /// <summary>
        /// The SCardGetAttrib function gets the current reader attributes.
        /// It does not affect the state of the reader, driver, or card.
        /// </summary>
        /// <param name="attrId">
        /// Identifier for the attribute to get.
        /// </param>
        /// <param name="responseBuffer">
        /// The response buffer.
        /// </param>
        /// <param name="responseLength">
        /// Supplies the length of the responseBuffer in bytes, and receives the actual length 
        /// of the received attribute.
        /// </param>
        public void GetAttrib(SCARD_ATTR attrId, byte[] responseBuffer, ref int responseLength)
        {
            GetAttrib((uint)attrId, responseBuffer, ref responseLength);
        }

        /// <summary>
        /// The SCardGetAttrib function gets the current reader attributes.
        /// It does not affect the state of the reader, driver, or card.
        /// </summary>
        /// <param name="attrId">
        /// Identifier for the attribute to get.
        /// </param>
        /// <param name="responseBuffer">
        /// The response buffer.
        /// </param>
        /// <param name="responseLength">
        /// Supplies the length of the responseBuffer in bytes, and receives the actual length 
        /// of the received attribute.
        /// </param>
        public void GetAttrib(uint attrId, byte[] responseBuffer, ref int responseLength)
        {

            Trace.WriteLineIf(this.scardTrace, string.Format("    SCard.SCardGetAttrib(AttrId: {0})", (SCARD_ATTR)attrId));

            int ret = WinSCardAPIWrapper.SCardGetAttrib(phCARD, (uint)attrId, responseBuffer, ref responseLength);

            if (ret == 0)
            {
                Trace.WriteLineIf(this.scardTrace, HexFormatting.Dump("        Attr. Value: 0x", responseBuffer, responseLength, 16, ValueFormat.HexASCII));
            }
            else
            {
                throw new WinSCardException(scardTrace, "SCard.Control", ret);
            }
        }


        /// <summary>
        /// The SCardControl function gives you direct control of the reader. 
        /// You can call it any time after a successful call to SCardConnect and before 
        /// a successful call to SCardDisconnect. The effect on the state of the reader 
        /// depends on the control code.
        /// </summary>
        /// <param name="dwControlCode">
        /// Control code for the operation. This value identifies the specific operation to be performed.
        /// </param>
        /// <param name="inBuffer">
        /// A buffer that contains the data required to perform the operation.
        /// This parameter can be null if the dwControlCode parameter specifies an operation that does
        /// not require input data.
        /// </param>
        /// <param name="inBufferLength">
        /// Length of the input buffer.
        /// </param>
        /// <param name="outBuffer">
        /// The output buffer.
        /// </param>
        /// <param name="outBufferSize">
        /// Size, in bytes, of the output buffer.
        /// </param>
        /// <param name="bytesReturned">
        /// Supplies the length, in bytes, of the outBuffer parameter.
        /// </param>
        public void Control(uint dwControlCode, byte[] inBuffer, int inBufferLength, byte[] outBuffer, int outBufferSize, ref int bytesReturned)
        {
            Trace.WriteLineIf(this.scardTrace, string.Format("    SCard.Control (Cntrl Code: 0x{0:X}", dwControlCode));
            //Trace.WriteLineIf( this.scardTrace, HexFormatting.Dump(string.Format( "--> SCard.Control (Cntrl Code: 0x{0:X} ): 0x", 
            //                                                    dwControlCode ), inBuffer, inBufferLength, 16, ValueFormat.HexASCII ) );

            int ret = WinSCardAPIWrapper.SCardControl(phCARD,
                                                    dwControlCode,
                                                    inBuffer,
                                                    inBufferLength,
                                                    outBuffer,
                                                    outBufferSize,
                                                    ref  bytesReturned);
            if (ret == 0)
            {
                Trace.WriteLineIf(this.scardTrace, HexFormatting.Dump("        Value: 0x", outBuffer, bytesReturned, 16, ValueFormat.HexASCII));
            }
            else
            {
                throw new WinSCardException(scardTrace, "SCard.Control", ret);
            }
        }

        /// <summary>
        /// The SCardDisconnect function terminates a connection previously opened between the calling 
        /// application and a smart card in the target reader.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        public void Disconnect()
        {
            Disconnect(SCARD_DISCONNECT.Unpower);
        }


        /// <summary>
        /// The SCardDisconnect function terminates a connection previously opened between the calling 
        /// application and a smart card in the target reader.
        /// </summary>
        /// <param name="disposition">
        /// Action to take on the card in the connected reader on close.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        public void Disconnect(SCARD_DISCONNECT disposition)
        {
            connectedReaderName = null;

            if (this.phCARD != (IntPtr)0)
            {
                int ret = WinSCardAPIWrapper.SCardDisconnect(phCARD, (uint)disposition);
                this.phCARD = (IntPtr)0;

                this.readerStrings = null;
                if (ret == 0)
                {
                    Trace.WriteLineIf(scardTrace, String.Format("    SCard.Disconnect(SCARD_DISCONNECT.{0})...", disposition));
                }
                else
                {
                    throw new WinSCardException(scardTrace, "SCard.Disconnect", ret);
                }
            }
        }

        /// <summary>
        /// The SCardReconnect function reestablishes an existing connection between the calling application and 
        /// a smart card. This function moves a card handle from direct access to general access, or acknowledges 
        /// and clears an error condition that is preventing further access to the card.
        /// </summary>
        public void Reconnect()
        {
            Reconnect(SCARD_SHARE_MODE.Exclusive, SCARD_PROTOCOL.Tx, SCARD_DISCONNECT.Unpower);
        }

        /// <summary>
        /// The SCardReconnect function reestablishes an existing connection between the calling application and 
        /// a smart card. This function moves a card handle from direct access to general access, or acknowledges 
        /// and clears an error condition that is preventing further access to the card.
        /// </summary>
        /// <param name="disconnectAction">
        /// Action to take on the card in the connected reader on close.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        public void Reconnect(SCARD_DISCONNECT disconnectAction)
        {
            Reconnect(SCARD_SHARE_MODE.Exclusive, SCARD_PROTOCOL.Tx, disconnectAction);
        }

        /// <summary>
        /// The SCardReconnect function reestablishes an existing connection between the calling application and 
        /// a smart card. This function moves a card handle from direct access to general access, or acknowledges 
        /// and clears an error condition that is preventing further access to the card.
        /// </summary>
        /// <param name="dwShareMode">
        /// A flag that indicates whether other applications may form connections to the card.
        /// </param>
        /// <param name="dwPrefProtocol">
        /// A bitmask of acceptable protocols for the connection. Possible values may be combined with the OR operation.
        /// </param>
        /// <param name="disconnectAction">
        /// Action to take on the card in the connected reader on close.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        public void Reconnect(SCARD_SHARE_MODE dwShareMode, SCARD_PROTOCOL dwPrefProtocol, SCARD_DISCONNECT disconnectAction)
        {


            int ret = WinSCardAPIWrapper.SCardReconnect(phCARD, (uint)dwShareMode, (uint)dwPrefProtocol,
                                                       (uint)disconnectAction, out activeSCardProtocol);
            if (ret == 0)
            {
                Trace.WriteLineIf(scardTrace, String.Format("    SCard.Reconnect(SHARE_MODE.{0}, SCARD_PROTOCOL.{1}, SCARD_DISCONNECT.{2} )",
                                                                 dwShareMode, (SCARD_PROTOCOL)dwPrefProtocol, (SCARD_DISCONNECT)disconnectAction));
                Trace.WriteLineIf(scardTrace, String.Format("        Active Protocol: SCARD_PROTOCOL.{0} ", (SCARD_PROTOCOL)activeSCardProtocol));
                Trace.WriteLineIf(this.TraceSCard, HexFormatting.Dump("        ATR: 0x", this.Atr, this.Atr.Length, 24));

            }
            else
            {
                throw new WinSCardException(scardTrace, "SCard.Reconnect", ret);
            }
        }

        /// <summary>
        /// The SCardReleaseContext function closes an established resource manager context, 
        /// freeing any resources allocated under that context.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        public void ReleaseContext()
        {
            connectedReaderName = null;


            if (this.phContext != (IntPtr)0)
            {
                int ret = WinSCardAPIWrapper.SCardReleaseContext(phContext);
                this.phContext = (IntPtr)0;

                if (ret == 0)
                {
                    Trace.WriteLineIf(scardTrace, "    SCard.ReleaseContext...");
                }
                else
                {
                    throw new WinSCardException(scardTrace, "SCard.ReleaseContext", ret);
                }
            }
        }

        /// <summary>
        /// This function implements the functionality of the SCARD_CTL_CODE Macro (WinSmCrd.h). 
        /// 
        /// </summary>
        /// <param name="code">The Control Code.</param>
        /// <returns>
        /// The WinSCardControl dwControlCode.
        /// </returns>
        public int GetSCardCtlCode(int code)
        {
            const int FILE_DEVICE_SMARTCARD = 0x00000031;
            const int METHOD_BUFFERED = 0;
            const int FILE_ANY_ACCESS = 0;

            return ((FILE_DEVICE_SMARTCARD) << 16) | ((FILE_ANY_ACCESS) << 14) | ((code) << 2) | (METHOD_BUFFERED);
        }
    }
}
