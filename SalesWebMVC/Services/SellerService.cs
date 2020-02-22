using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        // é obrigatório ir no ficheiro Satartup.cs e registar a classe no metodo ConfigureServices
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

        public void Insert(Seller obj)
        {
            //obj.Department = _context.Department.First();
            _context.Add(obj);  // add ao contexto
            _context.SaveChanges(); // grava no BD
        }
    }
}
