using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

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

        /*
        // método síncrono
        public List<Seller> FindAll()
        {
            // ainda operação sincrona - bloqueia a app ao ser executada
            return _context.Seller.ToList();
        }
        */

        public async Task<List<Seller>> FindAllAsync()
        {
            // método assíncrono
            return await _context.Seller.ToListAsync();
        }

        /*
        // método síncrono
        public void Insert(Seller obj)
        {
            //obj.Department = _context.Department.First();
            _context.Add(obj);  // add ao contexto
            _context.SaveChanges(); // grava no BD
        }
        */

        public async Task InsertAsync(Seller obj)
        {
            // método assíncrono
            _context.Add(obj);  // add ao contexto
            await _context.SaveChangesAsync(); // grava no BD
        }

        /*
        public Seller FindById(int id)
        {
            // método síncrono
            // retorna somente o obj do Seller
            //return _context.Seller.FirstOrDefault(obj => obj.Id == id);

            // faz um join com Department - eager loading
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }
        */

        public async Task<Seller> FindByIdAsync(int id)
        {
            // método assíncrono
            // retorna somente o obj do Seller
            // faz um join com Department - eager loading
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        /*
        public void Remove(int id)
        {
           // método síncrono
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
        */

        public async Task RemoveAsync(int id)
        {
            // método assíncrono
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        /*
        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        */

        public async Task UpdateAsync(Seller obj)
        {
            // a var hasAny é apenas didática
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj); // em memória, não precisa do await
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
