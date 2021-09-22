/***************************************************************
* Name        : HomeController.cs
* Author      : Tom Sorteberg
* Created     : 07/18/2020
* Course      : CIS 169 - C#
* Version     : 1.0
* OS          : Windows 10 Pro, Visual Studio Community 2019
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : This controller class file represents the controller for an MVC
*               ASP.NET Core Web Application, which has been prepared
*               for my final project submission for CIS-169.
*               Input is passed from the view into ViewBag containers,
*               which are then used to call methods from the Lotto
*               class.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access 
* to my program.         
***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LottoNumbersSorteberg.Models;

namespace LottoNumbersSorteberg.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.NumberMatching = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Lotto model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.NumberMatching = model.Compare();
                ViewBag.WinningNumber = model.DisplayTicket();
            }
            else
            {
                ViewBag.NumberMatching = 0;
            } 
            return View(model);
        }
    }
}
