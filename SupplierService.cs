using HumanitarianProjectManagement.Models;
using HumanitarianProjectManagement.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Services
{
    public class SupplierService
    {
        private readonly DataAccessLayer.HpmDbContext _context;

        public SupplierService(DataAccessLayer.HpmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Set<Supplier>().ToListAsync();
        }
    }
}
