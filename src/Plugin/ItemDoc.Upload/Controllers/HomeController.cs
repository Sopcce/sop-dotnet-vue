﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemDoc.Upload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Log()
        {
            ViewBag.Message = "Your Log page.";

            return View();
        }


        public ActionResult Test()
        {
            ViewBag.Message = "这是接口测试";

            return View();
        }
        public ActionResult Doc()
        {
            ViewBag.Message = "这是接口文档";

            return View();
        }


    }
}