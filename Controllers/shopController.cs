using Bootique.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootique.Controllers
{
    public class shopController : Controller
    {
        public ActionResult AddNewshop()
        {
            var con = new DatabaseComponent();
            return View(new shop());
        }
        [HttpPost]
        public ActionResult AddNewshop(shop shop)
        {
            var con = new DatabaseComponent();
            try
            {
                con.AddNewshop(shop);
                return View(new shop());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new shop());
            }
        }
        public ActionResult GetAllshop()
        {
            var con = new DatabaseComponent();
            var shop = con.GetAllshop();
            return View(shop);
        }
        public ActionResult Findshop(string id)
        {
            int shopId = Convert.ToInt32(id);
            var con = new DatabaseComponent();
            try
            {
                var shop = con.Findshop(shopId);
                return View(shop);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult UpdateShop(string id)
        {
            int shopId = Convert.ToInt32(id);
            var con = new DatabaseComponent();
            try
            {
                var shop = con.Findshop(shopId);
                return View(shop);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult Updateshop(shop shop)
        {
            
            var con = new DatabaseComponent();
            try
            {
                con.Updateshop(shop);
                
                return RedirectToAction("GetAllshop");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Deleteshop(string id)
        {
            var con = new DatabaseComponent();
            int shopId = Convert.ToInt32(id);
            try
            {
                con.Deleteshop(shopId);
                return RedirectToAction("GetAllShop");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
  }

       
