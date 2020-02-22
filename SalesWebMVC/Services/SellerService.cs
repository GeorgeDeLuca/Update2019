﻿using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public Seller FindById(int id)
        {
            // retorna somente o obj do Seller
            //return _context.Seller.FirstOrDefault(obj => obj.Id == id);

            // faz um join com Department - eager loading
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
