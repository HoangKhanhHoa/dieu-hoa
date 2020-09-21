using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class Order : EntityBase
    {
        [DataColum]
        public int OrderId { get; set; }

        [DataColum]
        public int CustomerId { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public DateTime DeliveryDate { get; set; }

        [DataColum]
        public string Note { get; set; }

        [DataColum]
        public decimal ToTalMoney { get; set; }

        [DataColum]
        public bool IsActive { get; set; }
    }
}
