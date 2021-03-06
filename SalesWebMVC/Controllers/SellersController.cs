﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services.Exceptions;
using SalesWebMVC.Models.ViewModes;
using System.Diagnostics;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        /*
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            // o obj list será passado para o ficheiro Index.cshtml que está dentro da pasta View/Sellers
            return View(list);
        }
        */

        public async Task<IActionResult> Index()
        {
            // método assíncrono
            // o nome dos métodos no Controller não deve ser alterado
            var list = await _sellerService.FindAllAsync();
            // o obj list será passado para o ficheiro Index.cshtml que está dentro da pasta View/Sellers
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            // busca todos os departamentos
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModels { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // previne ataques CSRF
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModels { Seller = seller, Departments = departments };
                return View(viewModel);
                //return View(seller);
            }
            await _sellerService.InsertAsync(seller);
            //return RedirectToAction("Index"); ou
            return RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not provided"});
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // previne ataques CSRF
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
              return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            // abre a tela de edicao
            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModels viewModel = new SellerFormViewModels { Seller = obj, Departments = departments };
            // passa para a view do MVC
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // previne ataques CSRF
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModels { Seller = seller, Departments = departments};
                return View(viewModel);
                //return View(seller);
            }
            if (id != seller.Id)
            {
                //return BadRequest();
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            //catch (NotFoundException e)
            catch (ApplicationException e)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            /*
            catch (DbConcurrencyException e)
            {
                //return BadRequest();
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            */
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                // retorna o ID interno da requisicao
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}