using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;
using Dapper;
using MeuTrabalho.Models.Repository;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        private IAppRepository _repository = null;

        public HomeController(IAppRepository repository)
        {            
            _repository = repository;            
        }

        public IActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Account");
        }

        public IActionResult Dashboard(string name)
        {
            if( name == null )
            {
                throw new ArgumentNullException(name);
            }

            ViewBag.Name = name;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            _repository.Insert("about");

            /*
            using (SqlConnection connection = new SqlConnection("Server=.; Database=MEUDB; Trusted_Connection = True;"))
            {
                try
                {
                    
                    
                    connection.Open();
                    SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('about')", connection);
                    //sql.ExecuteReader();
                    sql.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    ViewData["Message"] = "ERROR ABOUT";
                }
            }
            */
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            _repository.Insert("contact");

            /*
            using (SqlConnection connection = new SqlConnection("Server=.; Database=MEUDB; Trusted_Connection = True;"))
            {
                try
                {
                    //connection.Open();
                    //SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('contact')", connection);
                    //sql.ExecuteScalar();
                    //sql.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error");
                }
            }
            */

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }        
    }
}
