using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.WCFProxy.SeccionConfiguration
{
    public class ConfiguracionServerService : ConfigurationElement
    {


        [ConfigurationProperty("Valor", IsRequired = true, IsKey = true)]
        public string Valor
        {
            get
            {
                return (string)this["Valor"];
            }
            set
            {
                this["Valor"] = value;
            }
        }



    }
}
