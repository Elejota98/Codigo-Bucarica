using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.WCFProxy.SeccionConfiguration
{
    public class ColeccionServerServices : ConfigurationElementCollection
    {

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "ServerService";
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return new ConfigurationPropertyCollection();
            }
        }

        public ConfiguracionServerService this[int Indice]
        {
            get
            {
                return (ConfiguracionServerService)base.BaseGet(Indice);
            }
            set
            {
                if (base.BaseGet(Indice) != null) base.BaseRemoveAt(Indice);
                base.BaseAdd(Indice, value);
            }
        }

        public void Add(ConfiguracionServerService Elemento)
        {
            base.BaseAdd(Elemento);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfiguracionServerService();
        }

        protected override object GetElementKey(ConfigurationElement Elemento)
        {
            return ((ConfiguracionServerService)Elemento).Valor;
        }

        public bool ExistElement(string Clave, ref ConfigurationElement Elemento)
        {
            var resultado = from p in base.BaseGetAllKeys().Select
                                ((num, indice) => new { clave = num, indice })
                            where p.clave.Equals(Clave)
                            select p.indice;

            if (resultado.Count() > 0 && this[(int)resultado.First()] != null)
                Elemento = this[(int)resultado.First()];
            else
                Elemento = null;

            return Elemento != null;
        }

        public ConfiguracionServerService GetElement(string ClienTag)
        {
            var resultado = from p in base.BaseGetAllKeys().Select
                                ((num, indice) => new { clave = num.ToString().ToUpper(), indice })
                            where p.clave.Contains(ClienTag.ToString().ToUpper())
                            select p.indice;

            if (resultado.Count() > 0 && this[(int)resultado.First()] != null)
                return this[(int)resultado.First()];

            return null;
        }

        public void Remove(ConfiguracionServerService Elemento)
        {
            base.BaseRemove(Elemento);
        }

        public void RemoveAt(int Indice)
        {
            base.BaseRemoveAt(Indice);
        }

    }
}
