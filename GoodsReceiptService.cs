using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Services
{
    public class GoodsReceiptService
    {
        private readonly HpmDbContext _context;

        public GoodsReceiptService(HpmDbContext context)
        {
            _context = context;
        }

        public async Task<List<GoodsReceipt>> GetAllGoodsReceiptsAsync()
        {
            // Fix: Use Set<GoodsReceipt>() to get the DbSet<GoodsReceipt>
            return await _context.Set<GoodsReceipt>().ToListAsync();
        }
    }
}
