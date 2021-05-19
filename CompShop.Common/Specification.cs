using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Common
{
    /// <summary>
    /// Represent the specification of any given Laptop
    /// </summary>
    public class Specification
    {
        /// <summary>
        /// The specification Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Represent the name of the specification
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The configuration and attributes of the specification
        /// </summary>
        public Config Config { get; set; }
    }
}
