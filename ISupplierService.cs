using System.Collections.Generic;
using System.Threading.Tasks;
using HumanitarianProjectManagement.Models;

namespace HumanitarianProjectManagement.Forms
{
    internal interface ISupplierService
    {
        Task<List<Supplier>> GetAllSuppliersAsync();
    }

    public class SupplierService : ISupplierService
    {
        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            // Replace with actual data access logic
            return await Task.FromResult(new List<Supplier>());
        }
    }
}