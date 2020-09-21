using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class LocationDiscount : EntityBase
    {
        [DataColum]
        public int LocationDiscountId { get; set; }

        [DataColum]
        public string LocationDiscountValue { get; set; }

        [DataColum]
        public string LocationDiscountName { get; set; }

        [DataColum]
        public string Note { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }

        [DataColum]
        public string Culture { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        public List<Location> Location
        {
            get;
            set;
        }
    }
}
