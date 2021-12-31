﻿using CosmeticsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeticsShop.Controllers
{
    public class CategoryManageController : Controller
    {
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult Index(string keyword = "")
        {
            List<Category> categories = new List<Category>();
            if (keyword != "")
            {
                categories = db.Categories.Where(x => x.Name.Contains(keyword)).ToList();
            }
            else
            {
                categories = db.Categories.Where(x => x.Name.Contains(keyword)).ToList();
            }
            return View(categories);
        }
        public ActionResult ToggleActive(int ID)
        {
            Category category = db.Categories.Find(ID);
            category.IsActive = !category.IsActive;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int ID)
        {
            Category category = db.Categories.Find(ID);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Category categoryUpdate = db.Categories.Find(category.ID);
            categoryUpdate.Name = category.Name;
            db.SaveChanges();
            ViewBag.Message = "Cập nhật thành công";
            return View("Details", categoryUpdate);
        }
        public ActionResult Edit()
        {
            return RedirectToAction("Index");
        }
    }
}