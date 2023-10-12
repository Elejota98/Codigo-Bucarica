using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.Entities
{
    [DataContract(Name = "ServiceUsuarios", Namespace = "http://www.MillensCorp.com/types/")]
    public class Usuarios
    {
        private long _Documento;
        private string _Nombres;
        [DataMember]
        public string Nombres
        {
            get { return _Nombres; }
            set { _Nombres = value; }
        }
        private string _Apellidos;
        [DataMember]
        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }
        private string _Usuario;
        [DataMember]
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        private string _Contraseña;
        [DataMember]
        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }
        private string _Cargo;
        [DataMember]
        public string Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
        private string _UsuarioCreador;
        [DataMember]
        public string UsuarioCreador
        {
            get { return _UsuarioCreador; }
            set { _UsuarioCreador = value; }
        }
        private DateTime _FechaCreacion;
        [DataMember]
        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        private string _IdTarjeta;
        [DataMember]
        public string IdTarjeta
        {
            get { return _IdTarjeta; }
            set { _IdTarjeta = value; }
        }
        private bool _Estado;
        [DataMember]
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        private bool _Sincronizacion;
        [DataMember]
        public bool Sincronizacion
        {
            get { return _Sincronizacion; }
            set { _Sincronizacion = value; }
        }

        [DataMember]
        public long Documento
        {
            get { return _Documento; }
            set { _Documento = value; }
        }
        
       
    }
}
