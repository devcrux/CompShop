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
    public class Brand
    {
        /// <summary>
        /// The brand Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// The name of the brand
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The price associated with the brand
        /// </summary>
        public float Price { get; set; }
    }
}
