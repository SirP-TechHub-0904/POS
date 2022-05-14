using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Expenditure
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public long TaskId { get; set; }
        public PosTask Task { get; set; }
    }
}
