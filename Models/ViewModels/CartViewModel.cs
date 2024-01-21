using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<Cart> CartList { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public int OrderTotal { get; set; }
    }
}
