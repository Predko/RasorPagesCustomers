using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RasorPagesCustomers.Data.Models
{
    public partial class Expense
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public decimal? Value { get; set; }
        public int? Number { get; set; }
        public string Comment { get; set; }
    }
}
