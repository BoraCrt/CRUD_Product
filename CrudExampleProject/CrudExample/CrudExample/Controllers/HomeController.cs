using CrudExample.DAL;
using CrudExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudExample.Controllers
{

    public class HomeController : Controller
    {

        private readonly User_DAL _user_DAL;
        private readonly Product_DAL _product_DAL;

        public HomeController(Product_DAL product_DAL, User_DAL user_DAL)
        {
            _product_DAL = product_DAL;
            _user_DAL = user_DAL;
        }
        [HttpPost]

        public IActionResult Login(User user)
        {

            var deneme = _user_DAL.GetUser(user);
            if (deneme == true)
            {
                //HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction("AllProduct");
            }

            return View();
        }

        public IActionResult Login()
        {

            return View();
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            var userRegister = _user_DAL.AddUser(user);
            if (userRegister == true)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        //[Authorize]
        [HttpPost]
        public IActionResult InsertProduct(Product product)
        {
            _product_DAL.AddProduct(product);
            var products = _product_DAL.GetAllProducts();

            return RedirectToAction("AllProduct");
        }


        public IActionResult AllProduct()
        {
            var products = _product_DAL.GetAllProducts();
            return View(products);
        }

        [HttpPost]
        public IActionResult RemoveProduct(Product product)
        {
            var deleteProduct = _product_DAL.DeleteProduct(product);
            if (deleteProduct == true)
            {
                var products = _product_DAL.GetAllProducts();
                return RedirectToAction("AllProduct");
            }
            return RedirectToAction("AllProduct");
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            var getProduct = _product_DAL.GetAllProducts().SingleOrDefault(p => p.ProductID == product.ProductID);

            if (getProduct != null)
            {
                getProduct.ProductName = product.ProductName;
                getProduct.Price = product.Price;
                getProduct.Description = product.Description;
            }

            var updateProduct = _product_DAL.UpdateProduct(getProduct);

            if (updateProduct == true)
            {
                _product_DAL.GetAllProducts();
                return RedirectToAction("AllProduct");
            }
            return RedirectToAction("AllProduct");
        }


    }
}