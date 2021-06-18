using System;
using System.Collections.Generic;

#nullable disable

namespace RasorPagesCustomers.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
            Incomes = new HashSet<Income>();
        }

        public int Id { get; set; }
        public string NameCompany { get; set; }
        public string Account { get; set; }
        public string City { get; set; }
        public string Account1 { get; set; }
        public string Region { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }
        public string File { get; set; }
        public string Unp { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }
}
