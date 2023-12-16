using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika_Ershov.E.D
{
    internal class UISettings : ConfigurationSection
    {
        [ConfigurationProperty("fontsize", DefaultValue = 8)]
        [IntegerValidator(MaxValue = 100, MinValue = 5)]
        public int FontSize
        {
            get { return (int)this["fontsize"]; }
            set { this["fontsize"] = value; }
        }

    }
}
