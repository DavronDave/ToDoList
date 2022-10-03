using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_domain_entities.Models;
using System.ComponentModel.DataAnnotations;

namespace AllMVC.Controllers
{
    public class ToDoController : Controller
    {
        private IToDoRepository repository;
        private ICategoryRepository catRepo;
        public ToDoController(IToDoRepository repo , ICategoryRepository cRepo)
        {
            repository = repo;
            catRepo = cRepo;
        }

        public ActionResult Index()
        {
            ViewBag.page = "show";
            ViewBag.catId = 0;
            ViewBag.defaultCatId = -1;
            ViewBag.Categories = catRepo.GetCategories();
            ViewBag.message = "Active to do list items";
            return View(repository.toDoItems.Where(x => x.Show));
        }
        public IActionResult All()
        {
            ViewBag.page = "all";
            ViewBag.catId = 0;
            ViewBag.defaultCatId = -1;
            ViewBag.Categories = catRepo.GetCategories();
            ViewBag.message = "All to do list items";
            return View("All",repository.toDoItems);
        }

        public IActionResult Hide()
        {
            ViewBag.page = "hide";
            ViewBag.catId = 0;
            ViewBag.defaultCatId = -1;
            ViewBag.Categories = catRepo.GetCategories();
            ViewBag.message = "Hidden to do list items";
            return View("Index", repository.toDoItems.Where(x => !x.Show));
        }

        [HttpPost]
        public ActionResult Delete(int id, string returnUrl)
        {
            repository.Delete(id);
            return Redirect(returnUrl); 
        }

        [HttpPost]
        public IActionResult ShowHide(int id, string returnUrl)
        {
            ViewBag.defaultCatId = -1;
            ToDoItem item = repository.GetToDo(id);
            if (item != null)
            {
                item.Show = !item.Show;
                repository.Update(item);
            }
            return Redirect(returnUrl);
        }

        public IActionResult Create(int defaultCatId, string returnUrl)
        {

            ViewBag.categories = catRepo.GetCategories();
            ViewBag.returnUrl = returnUrl;
            return View(new ToDoItem { id = 0, CategoryId = defaultCatId, GetStatus = Status.NotStarted, Show = true, DueDate=DateTime.Now });
        }

        [HttpPost]
        public IActionResult Create(ToDoItem item, string returnUrl, string categoryName)
        {

            if (item.CategoryId == -1)
            {
                ModelState.AddModelError(nameof(item.CategoryId), "category is required");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = catRepo.GetCategories();
                ViewBag.returnUrl = returnUrl;
                return View(item);
            }

            item.CreationDate = DateTime.Now;
            item.Show = true;
            if (item.CategoryId == 0)
            {
                item.Category = new Category { id = 0, Name = categoryName };

            }

            repository.Create(item);
            return Redirect(returnUrl);
        }

        public IActionResult Edit(int id, string returnUrl)
        {
            ViewBag.defaultCatId = -1;
            ToDoItem item = repository.GetToDo(id);
            ViewBag.Categories = catRepo.GetCategories();
            ViewBag.returnUrl = returnUrl;
            return View(item);
     
        
        }
        [HttpPost]
        public IActionResult Edit(ToDoItem item, string returnUrl)
        {
            if (item.CategoryId == -1)
            {
                ModelState.AddModelError(nameof(item.CategoryId), "category is required");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = catRepo.GetCategories();
                ViewBag.returnUrl = returnUrl;
                return View(item);
            }

            repository.Update(item);
            return Redirect(returnUrl);
        }

        public IActionResult Today()
        {
            ViewBag.page = "today";
            ViewBag.catId = 0;
            ViewBag.defaultCatId = -1;
            ViewBag.Categories = catRepo.GetCategories();
            ViewBag.message = $"Today : {DateTime.Now:M}";
            return View("Index", repository.GetToday());
        }

        public IActionResult GetByCategory(int id)
        {
            ViewBag.page = "category";
            ViewBag.catId = id;
            ViewBag.defaultCatId = id;
            ViewBag.Categories = catRepo.GetCategories();
            Category category = catRepo.GetCategory(id);
            ViewBag.message = $"This category is {category.Name}";
            return View("Index", repository.GetByCategory(category));
        }
        [HttpPost]
        public IActionResult ChangeCategory(int id,[Required] string catName, string returnUrl)
        {
            Category category = catRepo.GetCategory(id);
            category.Name = catName;
            if(ModelState.IsValid)
                catRepo.Update(category);
            return Redirect(returnUrl);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            catRepo.Delete(id);
            return catRepo.Count()==0?Redirect("/"):GetByCategory(catRepo.GetCategories().Min(x => x.id));
        }
    }
}
