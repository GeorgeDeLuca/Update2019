using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext contex)
        {
            _context = contex;
        }

        public List<Seller> FindAll()
        {
            // ainda operação sincrona - bloqueia a app ao ser executada
            return _context.Seller.ToList();
        }
    }
}
