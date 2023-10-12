using GS.Util.Hex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.CRT603Device
{
    public partial class WinSCard
    {
        /// <summary>
        /// Gets or sets a value indicating whether the WinSCard trace is enabled or not.
        /// </summary>
        /// <value><c>true</c> if [PCSC trace]; otherwise, <c>false</c>.</value>
        public bool TraceSCard
        {
            get { return scardTrace; }
            set { scardTrace = value; }
        }

        /// <summary>
        /// Gets the established active protocol.
        /// </summary>
        /// <value>The active protocol.</value>
        private SCARD_PROTOCOL SCardProtocol
        {
            get { return (SCARD_PROTOCOL)activeSCardProtocol; }
        }

        /// <summary>
        /// Gets a value indicating whether the resourete manager context is extablished.
        /// </summary>
        /// <value><c>true</c> if [context extablished]; otherwise, <c>false</c>.</value>
        public bool IsRMContextEstablished
        {
            get
            {
                if (phContext == (IntPtr)0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the card context is extablished.
        /// </summary>
        /// <value><c>true</c> if [context extablished]; otherwise, <c>false</c>.</value>
        public bool IsCardContextEstablished
        {
            get
            {
                if (phCARD == (IntPtr)0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether smart card is present in the previous selected reader.
        /// </summary>
        /// <value><c>true</c> if [card activated]; otherwise, <c>false</c>.</value>
        public bool IsCardPresent
        {
            get
            {
                if (string.IsNullOrEmpty(this.ReaderName) == false)
                {
                    return this.GetCardPresentState(this.connectedReaderName);
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// Gets the Answer to reset (ATR).
        /// </summary>
        /// <value>The Answer to reset (ATR).</value>
        public byte[] Atr
        {
            get
            {
                if (phCARD != (IntPtr)0)
                {
                    byte[] result = new byte[256];
                    int resultLength = result.Length;

                    int ret = WinSCardAPIWrapper.SCardGetAttrib(phCARD,
                                                 (uint)SCARD_ATTR.ATR_STRING,
                                                 result,
                                                 ref resultLength);

                    if (resultLength > 0)
                    {
                        byte[] baATR = new byte[resultLength];
                        Array.Copy(result, baATR, resultLength);
                        return baATR;
                    }
                }
                return null;
            }
        }


        /// <summary>
        /// Gets the Answer to reset (ATR) string.
        /// </summary>
        /// <value>The Answer to reset (ATR) string.</value>
        public string AtrString
        {
            get
            {
                byte[] baATR = Atr;

                if (baATR != null)
                {
                    return HexFormatting.ToHexString(baATR, true);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets an array of the names of available readers.
        /// </summary>
        /// <value>The names of available readers.</value>
        public string[] ReaderNames
        {
            get
            {
                return readerStrings;
            }
        }

        /// <summary>
        /// Gets the name of the previous selected reader.
        /// </summary>
        /// <value>The name of the selected reader.</value>
        public string ReaderName
        {
            get
            {
                return this.connectedReaderName;
            }
        }



    }
}
