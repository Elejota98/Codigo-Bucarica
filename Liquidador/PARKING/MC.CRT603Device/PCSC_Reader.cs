using GS.Apdu;
using GS.Util.Hex;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.CRT603Device
{
    public partial class PCSCReader
    {
        /// <summary>
        /// Stores the actual smartcard reader name.
        /// </summary>
        private string readerName;

        /// <summary>
        /// WinScard Functions.
        /// </summary>
        public WinSCard SCard;


        /// <summary>
        /// Initializes a new instance of the <see cref="PCSCReader"/> class.
        /// </summary>
        public PCSCReader()
        {
            this.SCard = new WinSCard();
            readerName = null;
        }

        /// <summary>
        /// Establishes the smart card resourete manager context and provides the list of readers.
        /// </summary>
        public ResultadoOperacion Connect()
        {
            ResultadoOperacion oResultadoOperacion = Connect(null);

            return oResultadoOperacion;
        }

        /// <summary>
        /// Establishes the smart card resourete manager context and provides the list of readers.
        /// </summary>
        /// <param name="dwScope">Scope of the resource manager context.</param>
        public void Connect(SCARD_SCOPE dwScope)
        {
            Connect(null, dwScope);
        }

        /// <summary>
        /// Establishes the smart card resourete manager context and selectes the specified reader.
        /// </summary>
        /// <param name="szReader">
        /// The name of the reader that contains the target card.
        /// </param>
        public ResultadoOperacion Connect(string szReader)
        {
            ResultadoOperacion oResultadoOperacion = Connect(szReader, SCARD_SCOPE.System);

            return oResultadoOperacion;
        }

        /// <summary>
        /// Establishes the smart card resourete manager context and selectes the specified reader.
        /// </summary>
        /// <param name="szReader">
        /// The name of the reader that contains the target card.
        /// </param>
        /// <param name="dwScope">Scope of the resource manager context.</param>
        public ResultadoOperacion Connect(string szReader, SCARD_SCOPE dwScope)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                this.SCard.EstablishContext(dwScope);

                if (!string.IsNullOrEmpty(szReader))
                {
                    this.readerName = szReader;
                    oResultadoOperacion.EntidadDatos = this.readerName;
                    return oResultadoOperacion;
                }

                this.SCard.ListReaders();

                if (this.SCard.ReaderNames.Length == 1)
                {
                    this.readerName = this.SCard.ReaderNames[0];
                    oResultadoOperacion.EntidadDatos = this.readerName;
                    return oResultadoOperacion;
                }

                for (int i = 0; i < this.SCard.ReaderNames.Length; i++)
                {
                    string crc = this.SCard.ReaderNames[i];

                    if (crc == "CREATOR CRT-603 (CZ1) CCR RF 0")
                    {
                        oResultadoOperacion.EntidadDatos = crc;
                        break;
                    }

                }

                this.readerName = oResultadoOperacion.EntidadDatos.ToString();
                oResultadoOperacion.Mensaje = "lector CRT conectado OK";
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
            }
            catch (WinSCardException ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            return oResultadoOperacion;
        }

        /// <summary>
        /// Activates the card.
        /// </summary>
        public ResultadoOperacion ActivateCard()
        {
            ResultadoOperacion oResultadoOperacion = ActivateCard(SCARD_SHARE_MODE.Exclusive, SCARD_PROTOCOL.Tx);

            return oResultadoOperacion;
        }

        /// <summary>
        /// Activates the card.
        /// </summary>
        /// <param name="dwPrefProtocol">
        /// A bitmask of acceptable protocols for the connection. Possible values may be combined with the OR operation.
        /// </param>
        public void ActivateCard(SCARD_PROTOCOL dwPrefProtocol)
        {
            ActivateCard(SCARD_SHARE_MODE.Exclusive, dwPrefProtocol);
        }

        /// <summary>
        /// Activates the card.
        /// </summary>
        /// <param name="dwShareMode">
        /// A flag that indicates whether other applications may form connections to the card.
        /// </param>
        /// <param name="dwPrefProtocol">
        /// A bitmask of acceptable protocols for the connection. Possible values may be combined with the OR operation.
        /// </param>
        public ResultadoOperacion ActivateCard(SCARD_SHARE_MODE dwShareMode, SCARD_PROTOCOL dwPrefProtocol)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                if (this.SCard.WaitForCardPresent(this.readerName))
                {
                    this.SCard.Disconnect();
                    this.SCard.Connect(this.readerName, dwShareMode, dwPrefProtocol);
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.Mensaje = "Esperando Tarjeta...";
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                }
            }
            catch (WinSCardException ex)
            {
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }

        /// <summary>
        /// Disconnects the an established connection to a smart card and closes 
        /// an established resource manager context, freeing any resources allocated 
        /// under that context.
        /// </summary>
        public void Disconnect()
        {
            Disconnect(SCARD_DISCONNECT.Unpower);
        }

        /// <summary>
        /// Disconnects the an established connection to a smart card and closes 
        /// an established resource manager context, freeing any resources allocated 
        /// under that context.
        /// </summary>
        /// <param name="disposition">Action to take on the card in the connected reader on close.</param>
        public void Disconnect(SCARD_DISCONNECT disposition)
        {
            try
            {
                this.SCard.Disconnect(disposition);
                this.SCard.ReleaseContext();
                this.readerName = null;
            }
            catch (WinSCardException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ///////////////////////////////////exca

        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card. 
        /// </summary>
        /// <param name="cmdApdu">Hexadecimal string containing the command ADPU.</param>
        /// <returns></returns>
        public RespApdu Exchange(string cmdApdu)
        {
            return this.Exchange(cmdApdu, null);
        }

        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="cmdApdu">Hexadecimal  string containing the command APDU.</param>
        /// <param name="expectedSW1SW2">The expected status word SW1SW2.</param>
        /// <returns></returns>
        public RespApdu Exchange(string cmdApdu, ushort? expectedSW1SW2)
        {
            byte[] responseBuffer = this.Exchange(HexEncoding.GetBytes(cmdApdu), expectedSW1SW2);
            RespApdu respApdu = new RespApdu(responseBuffer);
            return respApdu;
        }

        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="cmdApdu">The command ADPU.</param>
        /// <returns>The response APDU.</returns>
        public RespApdu Exchange(CmdApdu cmdApdu)
        {
            return this.Exchange(cmdApdu, null);
        }

        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="cmdApdu">The command ADPU.</param>
        /// <param name="expectedSW1SW2">The expected status word SW1SW2.</param>
        /// <returns>The response APDU.</returns>
        public RespApdu Exchange(CmdApdu cmdApdu, ushort? expectedSW1SW2)
        {
            byte[] responseBuffer = this.Exchange(cmdApdu.GetBytes(), expectedSW1SW2);
            RespApdu respApdu = new RespApdu(responseBuffer);
            return respApdu;
        }

        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="sendBuffer">The command ADPU.</param>
        /// <returns>The response APDU.</returns>
        public byte[] Exchange(byte[] sendBuffer)
        {
            return this.Exchange(sendBuffer, null);
        }

        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="sendBuffer">The command ADPU.</param>
        /// <param name="expectedSW1SW2">The expected status word SW1SW2.</param>
        /// <returns>The response APDU.</returns>
        public byte[] Exchange(byte[] sendBuffer, ushort? expectedSW1SW2)
        {
            byte[] responseBuffer = null;
            this.Exchange(sendBuffer, out responseBuffer, expectedSW1SW2);
            return responseBuffer;
        }


        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="sendBuffer">The command ADPU.</param>
        /// <param name="responseBuffer">The response APDU.</param>
        public void Exchange(byte[] sendBuffer, out byte[] responseBuffer)
        {
            this.Exchange(sendBuffer, out responseBuffer, null);
        }


        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="sendBuffer">The command ADPU.</param>
        /// <param name="responseBuffer">The response APDU.</param>
        /// <param name="expectedSW1SW2">The expected status word SW1SW2.</param>
        public void Exchange(byte[] sendBuffer, out byte[] responseBuffer, ushort? expectedSW1SW2)
        {
            int responseLength = 0;
            this.Exchange(sendBuffer, sendBuffer.Length, out responseBuffer, out responseLength, expectedSW1SW2);
        }

        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="sendBuffer">The command ADPU.</param>
        /// <param name="sendLength">Length of the command ADPU.</param>
        /// <param name="responseBuffer">The response APDU.</param>
        /// <param name="responseLength">Length of the response APDU.</param>
        public void Exchange(byte[] sendBuffer, int sendLength, out byte[] responseBuffer, out int responseLength)
        {
            this.Exchange(sendBuffer, sendLength, out responseBuffer, out responseLength, null);
        }

        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="sendBuffer">The command ADPU.</param>
        /// <param name="sendLength">Length of the command ADPU.</param>
        /// <param name="responseBuffer">The response APDU.</param>
        /// <param name="responseLength">Length of the response APDU.</param>
        /// <param name="expectedSW1SW2">The expected status word SW1SW2.</param>
        public void Exchange(byte[] sendBuffer, int sendLength, out byte[] responseBuffer, out int responseLength, ushort? expectedSW1SW2)
        {
            responseBuffer = null;

            CmdApdu cmdApud;

            if (sendBuffer.Length == sendLength)
            {
                cmdApud = new CmdApdu(sendBuffer);
            }
            else
            {
                byte[] baSendTemp = new byte[sendLength];
                Array.Copy(sendBuffer, baSendTemp, sendLength);
                cmdApud = new CmdApdu(baSendTemp);
            }

            int respBufferSize = 2;

            if ((cmdApud.Le != null))
            {
                respBufferSize = (int)cmdApud.Le + 2;
            }
            byte[] baTempResp = new byte[respBufferSize];
            responseLength = baTempResp.Length;

            this.Exchange(sendBuffer, sendLength, baTempResp, ref responseLength, expectedSW1SW2);

            responseBuffer = new byte[responseLength];
            Array.Copy(baTempResp, responseBuffer, responseLength);
        }

        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="sendBuffer">The command ADPU.</param>
        /// <param name="sendLength">Length of the command ADPU.</param>
        /// <param name="responseBuffer">The response APDU.</param>
        /// <param name="responseLength">
        /// Supplies the length, in bytes, of the response APDU buffer  and 
        /// receives the actual number of bytes received from the smart card.
        /// </param>
        public void Exchange(byte[] sendBuffer, int sendLength, byte[] responseBuffer, ref int responseLength)
        {
            this.Exchange(sendBuffer, sendLength, responseBuffer, ref responseLength, null);
        }

        /// <summary>
        /// The function Exchange sends a command APDU to a smart card and returns the response ADPU from the card.
        /// </summary>
        /// <param name="sendBuffer">The command ADPU.</param>
        /// <param name="sendLength">Length of the command ADPU.</param>
        /// <param name="responseBuffer">The response APDU.</param>
        /// <param name="responseLength">
        /// Supplies the length, in bytes, of the response APDU buffer  and 
        /// receives the actual number of bytes received from the smart card.
        /// </param>
        /// <param name="expectedSW1SW2">The expected status word SW1SW2.</param>
        public void Exchange(byte[] sendBuffer, int sendLength, byte[] responseBuffer, ref int responseLength, ushort? expectedSW1SW2)
        {
            if (sendBuffer == null)
            {
                throw new ArgumentNullException("snd_buf");
            }

            if (responseBuffer == null)
            {
                throw new ArgumentNullException("rec_buf");
            }

            this.SCard.Transmit(sendBuffer, sendLength, responseBuffer, ref responseLength);

            RespApdu respApdu = new RespApdu(responseBuffer, responseLength);

            if (expectedSW1SW2 != null)
            {
                // Verify for a valid response status word SW1SW2.
                if (expectedSW1SW2 != respApdu.SW1SW2)
                {
                    throw new ApduException(this.SCard.TraceSCard, 0, (ushort)expectedSW1SW2, respApdu.SW1SW2);
                }
            }
        }



    }
}
