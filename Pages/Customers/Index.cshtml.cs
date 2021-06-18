using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RasorPagesCustomers.Data.Models;

namespace RasorPagesCustomers.Pages.Customers
{
    public class CustomersModel : PageModel
    {
        private readonly CustomersContext _context;

        public CustomersModel(CustomersContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
