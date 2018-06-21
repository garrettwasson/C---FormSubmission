using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class MainController : Controller
    {
        private readonly DbConnector _dbConnector;
        public MainController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        [HttpGet("")]
        public IActionResult Main()
        {   
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(string first_name, string last_name, int? age, string email, string password)
        {
            User NewUser = new User
            {
                FirstName = first_name,
                LastName = last_name,
                Age = age,
                Email = email,
                Password = password, 
            };
            // if validation fails, redirect back to form
            if (TryValidateModel(NewUser) == false)
            {
                ViewBag.errors = ModelState.Values;
                return View();
            }
            // if validation passes, add user to database and redirect to success 
            else 
            {   
                string query = $"INSERT INTO form (FirstName, LastName, Age, Email, Password) VALUES ('{first_name}', '{last_name}', '{age}', '{email}', '{password}');";
                _dbConnector.Query(query);
                return RedirectToAction("Success");
            }
        }
        [HttpGet("success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
