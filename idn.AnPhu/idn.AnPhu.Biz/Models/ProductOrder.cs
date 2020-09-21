using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class ProductOrder : EntityBase
    {
        [DataColum]
        public int OrderId { get; set; }

        [DataColum]
        public int ProductId { get; set; }

        [DataColum]
        public int Quantity { get; set; }

        [DataColum]
        public string Note { get; set; }

        [DataColum]
        public decimal ProductPrice { get; set; }

        [DataColum]
        public decimal ToTal { get; set; }
    }
}
