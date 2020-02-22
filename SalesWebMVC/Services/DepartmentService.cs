using SalesWebMVC.Models;
using System.Linq;
using System.Collections.Generic;

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

        public List<Department> FindAll()
        {
            //return _context.Department.ToList(); ou
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
