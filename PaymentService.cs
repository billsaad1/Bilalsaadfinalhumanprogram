using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Services
{
    public class PaymentService
    {
        private readonly HpmDbContext _context;

        public PaymentService(HpmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync() => await _context.Set<Payment>().ToListAsync();
    }
}
