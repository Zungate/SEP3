using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSkeletonMVCClient.Models;

namespace RestSkeletonMVCClient.Controllers
{
    public class ProductController : Controller
    {
        public string GetJSON(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute(new RestRequest());
            
            return response.Content;
        }
        // GET: Product
        public ActionResult Index()
        {
            //Produces JSON
            var json = GetJSON("http://localhost:8080/RestSkeleton/products");

            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            return View(products);
        }

        // POST: Product/Buy
        
        public ActionResult Buy()
        {
            var json = GetJSON("http://localhost:8080/RestSkeleton/products/get10");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            var client = new RestClient("http://localhost:8080/RestSkeleton/products/");
            var request = new RestRequest("buy", Method.POST);

            
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            client.Execute(request);
            

            return View(products);

        }
        
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
