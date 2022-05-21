using BlogPro.Models;
using BlogPro.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository repo;

        public HomeController(IPostRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
           
                return View(repo.AllPosts());

        }
        [HttpPost]
        public IActionResult Index(string term)
        {
            if (term != null)
            {
                return View(repo.Search(term));
            }
            else
            {
                return View(repo.AllPosts());
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            return View(repo.Find(id));
        }
       
    }
}
