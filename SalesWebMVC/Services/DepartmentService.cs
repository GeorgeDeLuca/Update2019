using SalesWebMVC.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        // é obrigatório ir no ficheiro Satartup.cs e registar a classe no metodo ConfigureServices
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext contex)
        {
            _context = contex;
        }

        /*
        public List<Department> FindAll()
        {
            // este método é síncrono
            //return _context.Department.ToList(); ou
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
        */

        public async Task<List<Department>> FindAllAsync()
        {
            // método assíncrono
            // o nome do método por padrão tem que ter a palavra "Async" por norma - FindAll"Async"
            // ** async e await
            // veja o método ToListAsync() - using Microsoft.EntityFrameworkCore;
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

    }
}
