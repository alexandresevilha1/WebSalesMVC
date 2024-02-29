﻿using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Services;

namespace WebSalesMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _selllerService;

        public SellersController(SellerService selllerService)
        {
            _selllerService = selllerService;
        }

        public IActionResult Index()
        {
            var list = _selllerService.FindAll();
            return View(list);
        }
    }
}
