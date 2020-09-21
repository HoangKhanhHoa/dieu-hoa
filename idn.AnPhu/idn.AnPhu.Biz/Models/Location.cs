using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class Location : EntityBase
    {
        [DataColum]
        public int LocationId { get; set; }

        [DataColum]
        public string LocationName { get; set; }

        [DataColum]
        public int LocationDiscountId { get; set; }

        [DataColum]
        public string LocationValue { get; set; }

        [DataColum]
        public string Note { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public string Culture { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        public List<Location> Locations
        {
            get;
            set;
        }
    }
}
