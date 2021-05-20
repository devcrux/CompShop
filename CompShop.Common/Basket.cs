using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Common
{
    public class Basket
    {
        public int Id { get; set; }        
        public  virtual Laptop Laptop { get; set; }
        public virtual List<Specification> Specifications { get; set; }
        public float FinalPrice { get; set; }
    }
}
