using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Activity
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal moniepointCharge { get; set; }
        public decimal CityCharge { get; set; }

        public long TaskId { get; set; }
        public PosTask Task { get; set; }
    }
}
