using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Services
{
    public class InvoiceService
    {
        private readonly HpmDbContext _context;

        public InvoiceService(HpmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices
                .Include(i => i.PurchaseOrder)
                    .ThenInclude(po => po.Supplier)
                .Include(i => i.Payments)
                .ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.PurchaseOrder)
                    .ThenInclude(po => po.Supplier)
                .Include(i => i.Payments)
                .FirstOrDefaultAsync(i => i.InvoiceID == id);
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Invoice>> SearchInvoicesAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllInvoicesAsync();
            }

            return await _context.Invoices
                .Include(i => i.PurchaseOrder)
                    .ThenInclude(po => po.Supplier)
                .Include(i => i.Payments)
                .Where(i => i.InvoiceNumber.Contains(searchTerm) ||
                            i.Status.Contains(searchTerm) ||
                            i.Supplier.Name.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
