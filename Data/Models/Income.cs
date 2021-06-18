using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RasorPagesCustomers.Data.Models
{
    public partial class Income
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public decimal? Value { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public int? Number { get; set; }
        public bool? TypePaiment { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
