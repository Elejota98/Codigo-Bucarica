using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.WCFProxy.SeccionConfiguration
{
    public class Server
    {
        private string _IPServer;
        private bool _Activo;
        private bool _Principal;
        private string _Uri;


        public string IPServer
        {
            get { return _IPServer; }
            set { _IPServer = value; }
        }
        public bool Principal
        {
            get { return _Principal; }
            set { _Principal = value; }
        }
        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }
        public string Uri
        {
            get { return _Uri; }
            set { _Uri = value; }
        }
    } 
}
