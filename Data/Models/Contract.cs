using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RasorPagesCustomers.Data.Models
{
    public partial class Contract
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public int? Number { get; set; }
        public decimal? Price { get; set; }
        public decimal? Prepayment { get; set; }
        public bool? Available { get; set; }
        public string File { get; set; }
        public string Comment { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
