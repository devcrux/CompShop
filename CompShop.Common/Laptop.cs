using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Common
{
    /// <summary>
    /// Represent the brand of any given laptop
    /// </summary>
    public class Laptop
    {
        /// <summary>
        /// The laptop Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// The brand name of the laptop
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The price associated with the brand
        /// </summary>
        public float Price { get; set; }
    }
}
