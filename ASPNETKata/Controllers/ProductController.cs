using ASPNETKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ASPNETKata.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var connString = "Server = localhost; Database = adventureworks; Uid = root; Pwd = huffmanhigh1;";
            using (var conn = new MySqlConnection(connString))
            {
                var list = conn.Query<Product>("SELECT * FROM product ORDER BY ProductId DESC");
                return View(list);
            }
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
            var connString = "Server = localhost; Database = adventureworks; Uid = root; Pwd = huffmanhigh1;";
            using (var conn = new MySqlConnection(connString))
            {
                conn.Execute("INSERT INTO product (Name) VALUES (@Name)", new { Name = collection["Name"] });
                return RedirectToAction("Index");
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
            var connString = "Server = localhost; Database = adventureworks; Uid = root; Pwd = huffmanhigh1;";
            using (var conn = new MySqlConnection(connString))
            {
                conn.Execute("UPDATE product SET Name = @Name WHERE ProductId = @Id", new { Id = id, Name = collection["Name"] });
                return RedirectToAction("Index");
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
            var connString = "Server = localhost; Database = adventureworks; Uid = root; Pwd = huffmanhigh1;";
            using (var conn = new MySqlConnection(connString))
            {
                conn.Execute("Delete product SET Name = @Name WHERE ProductId = @Id", new { Id = id, Name = collection["Name"] });
                return RedirectToAction("Index");
            }
        }
    }
}
