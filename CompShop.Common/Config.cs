using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Common
{
    public class Config
    {
        /// <summary>
        /// The configuration Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// The attribute of the laptop configuration
        /// </summary>
        public string Attribute { get; set; }
        /// <summary>
        /// The price associated with the configuration
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// The type of the laptop configuration
        /// </summary>
        public ConfigType ConfigType { get; set; }
    }

    public enum ConfigType
    {
        RAM,
        HDD,
        COLOR
    }
}
