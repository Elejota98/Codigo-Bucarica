using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.DataTransferObject
{
    public class DtoUsuario
    {
        private long _Documento;
        private string _Nombres;
        public string Nombres
        {
            get { return _Nombres; }
            set { _Nombres = value; }
        }
        private string _Apellidos;
        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }
        private string _Usuario;
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        private string _Contraseña;
        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }
        private string _Cargo;
        public string Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
        private string _UsuarioCreador;
        public string UsuarioCreador
        {
            get { return _UsuarioCreador; }
            set { _UsuarioCreador = value; }
        }
        private DateTime _FechaCreacion;
        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        private string _IdTarjeta;
        public string IdTarjeta
        {
            get { return _IdTarjeta; }
            set { _IdTarjeta = value; }
        }
        private bool _Estado;
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        private bool _Sincronizacion;
        public bool Sincronizacion
        {
            get { return _Sincronizacion; }
            set { _Sincronizacion = value; }
        }

        public long Documento
        {
            get { return _Documento; }
            set { _Documento = value; }
        }
        
    }
}
