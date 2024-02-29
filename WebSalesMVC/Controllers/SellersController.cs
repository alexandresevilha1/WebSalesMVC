using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Models;
using WebSalesMVC.Models.ViewModels;
using WebSalesMVC.Services;

namespace WebSalesMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _selllerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService selllerService, DepartmentService departmentService)
        {
            _selllerService = selllerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _selllerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var ViewModel =  new SellerFormViewModel { Departments = departments };
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) 
        {
            _selllerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
