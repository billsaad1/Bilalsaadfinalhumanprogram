using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Services
{
    public class PurchaseOrderService
    {
        private readonly HpmDbContext _context;

        public PurchaseOrderService(HpmDbContext context)
        {
            _context = context;
        }

        public PurchaseOrderService()
        {
        }

        public async Task<List<PurchaseOrder>> GetAllPurchaseOrdersAsync()
        {
            return await _context.PurchaseOrders
                .Include(po => po.Supplier)
                .Include(po => po.IssuedByUser)
                .Include(po => po.PurchaseRequisition)
                .Include(po => po.Items)
                    .ThenInclude(poi => poi.Product)
                .ToListAsync();
        }

        public async Task<PurchaseOrder> GetPurchaseOrderByIdAsync(int id)
        {
            return await _context.PurchaseOrders
                .Include(po => po.Supplier)
                .Include(po => po.IssuedByUser)
                .Include(po => po.PurchaseRequisition)
                .Include(po => po.Items)
                    .ThenInclude(poi => poi.Product)
                .FirstOrDefaultAsync(po => po.POID == id);
        }

        public async Task AddPurchaseOrderAsync(PurchaseOrder po)
        {
            _context.PurchaseOrders.Add(po);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePurchaseOrderAsync(PurchaseOrder po)
        {
            _context.Entry(po).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePurchaseOrderAsync(int id)
        {
            var po = await _context.PurchaseOrders.FindAsync(id);
            if (po != null)
            {
                _context.PurchaseOrders.Remove(po);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PurchaseOrder>> SearchPurchaseOrdersAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllPurchaseOrdersAsync();
            }

            return await _context.PurchaseOrders
                .Include(po => po.Supplier)
                .Include(po => po.IssuedByUser)
                .Include(po => po.PurchaseRequisition)
                .Include(po => po.Items)
                    .ThenInclude(poi => poi.Product)
                .Where(po => po.Supplier.Name.Contains(searchTerm) ||
                            po.Status.Contains(searchTerm) ||
                            po.IssuedByUser.FullName.Contains(searchTerm) ||
                            po.Items.Any(item => item.Product.Name.Contains(searchTerm)))
                .ToListAsync();
        }
    }
}
