using BlogPro.Models;
using BlogPro.Repository;
using BlogProNew.Repository;
using BlogProNew.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProNew.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IPostRepository repo;
        private readonly IFileManger file;

        public AdminController(IPostRepository repo,IFileManger file )
        {
            this.repo = repo;
            this.file = file;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(repo.AllPosts());
        }
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(PostVM postVM)
        {
            var item = new Post
            {
                Id = postVM.Id,
                Title = postVM.Title,
                Body = postVM.Body,
                Images = await file.SaveImage(postVM.Images),
                Description=postVM.Description,
                Tags=postVM.Tags,
               Category=postVM.Category 
            };
            repo.Add(item);
        
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = repo.Find(id);
            return View(new PostVM{
            Id=item.Id,
            Title=item.Title,
             Body=item.Body,
                Description = item.Description,
                Tags = item.Tags,
                Category = item.Category
            }
            );
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Edit(PostVM postVM)
        {
            var item = new Post
            {
                Id = postVM.Id,
                Title = postVM.Title,
                Body = postVM.Body,
                Description = postVM.Description,
                Tags = postVM.Tags,
                Category = postVM.Category,
                Images = await file.SaveImage(postVM.Images)
            };
            if (ModelState.IsValid)
            {
                repo.Edit(item);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            return View(repo.Find(id));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            return View(repo.Find(id));
        }
        [HttpPost]
        public IActionResult Delete(Post p)
        {
            repo.Remove(p);

            return RedirectToAction(nameof(Index));
        }
    }
}
