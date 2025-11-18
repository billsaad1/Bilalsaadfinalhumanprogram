using HumanitarianProjectManagement.DataAccessLayer;
using HumanitarianProjectManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.Services
{
    public class PurchaseRequisitionService
    {
        private readonly HpmDbContext _context;

        public PurchaseRequisitionService()
        {
        }

        public PurchaseRequisitionService(HpmDbContext context)
        {
            _context = context;
        }

         public async Task<List<PurchaseRequisition>> GetAllPurchaseRequisitionAsync() => await _context.Set<PurchaseRequisition>().ToListAsync();

        internal async Task GetAllPurchaseRequisitionsAsync()
        {
            throw new NotImplementedException();
        }
    }
    }

