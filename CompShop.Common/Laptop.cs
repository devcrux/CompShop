using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Common
{
    /// <summary>
    /// Represents a Laptop
    /// </summary>
    public class Laptop
    {
        /// <summary>
        /// The laptop Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// The laptop brand
        /// </summary>
        public Brand Brand { get; set; }
        /// <summary>
        /// The laptop specifications
        /// </summary>
        public IList<Specification> Specifications {get; set;}
    }
}
