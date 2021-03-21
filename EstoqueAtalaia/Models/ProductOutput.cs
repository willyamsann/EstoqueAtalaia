using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAtalaia.Models
{
    public class ProductOutput
    {
        public new int Id { get; set; }

        public int Qtde { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public DateTime DateTime { get; set; }
    }
}
