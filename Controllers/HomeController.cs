using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(UserModel model)
        //{
        //    try
        //    {
        //        ManagementObjectSearcher searcher =
        //            new ManagementObjectSearcher("root\\CIMV2",
        //            "SELECT * FROM Win32_UserAccount");

        //        foreach (ManagementObject queryObj in searcher.Get())
        //        {
        //            if(model.User == queryObj["Name"].ToString())
        //            {
        //                return View("Check", $"Пользователь {model.User} есть");
        //            }
        //        }
        //        return View("Check", $"Пользователя {model.User} нет");
        //    }
        //    catch (ManagementException e)
        //    {
        //        return View("Check", "An error occurred while querying for WMI data: " + e.Message);
        //    }

        //}

        [HttpGet]
        public IActionResult Check(UserModel model)
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_UserAccount");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (model.User == queryObj["Name"].ToString())
                    {
                        return View("Check", $"Пользователь {model.User} есть");
                    }
                }
                return View("Check", $"Пользователя {model.User} нет");
            }
            catch (ManagementException e)
            {
                return View("Check", "An error occurred while querying for WMI data: " + e.Message);
            }
        }

    }
}
