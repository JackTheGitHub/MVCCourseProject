using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using ASPMVCProject.Models;
using DataAccess;
using ASPMVCProject.Helpers;

namespace ASPMVCProject.Controllers
{
    public class AnimeController : Controller
    {
       
        public ActionResult Edit()
        {

            AnimeRepository repo = new AnimeRepository();

            AnimeViewModel model = new AnimeViewModel(repo.GetAll());

            return View(model);
        }

        [HttpGet]
        public ActionResult EditAnime(int id = 0)
        {

            if (!LoginUserSession.Current.IsAdministrator)
            {
                return RedirectToAction("Edit");
            }

            CategoryRepository categoriesRepo = new CategoryRepository();

            List<Category> categories = categoriesRepo.GetAll();
            Category category = new Category();

            ViewBag.Categories = new SelectList(categories, "ID", "Name");

            AnimeRepository animeRepo = new AnimeRepository();

            AnimeViewModel anime;

            if (id != 0)
            {
                anime = new AnimeViewModel(animeRepo.GetByID(id));
            }
            else
            {
                anime = new AnimeViewModel(new Anime());
            }

            return View(anime);

        }

        [HttpPost]
        public ActionResult EditAnime(AnimeViewModel viewModel)
        {
            if (LoginUserSession.Current.IsAuthenticated)
            {
                if (viewModel == null)
                {
                    TempData["Message"] = "No View Model";
                    return RedirectToAction("Edit");
                }

                AnimeRepository repo = new AnimeRepository();
                Anime anime = repo.GetByID(viewModel.ID);

                if (anime == null)
                {
                    anime = new Anime();
                }

                anime.Name = viewModel.Name;
                anime.AnimeCategory = viewModel.Category;
                anime.Category = viewModel.CategoryID;
                anime.Rating = viewModel.Rating;


                repo.Save(anime);

                TempData["Mesage"] = "Anime was successfully saved!";
                return RedirectToAction("Edit");
            }


            TempData["ErrorMessage"] = "Please log in";
            return RedirectToAction("Login", "Login");

        }

        public ActionResult Delete(int id = 0)
        {

            if (!LoginUserSession.Current.IsAdministrator)
            {
                return Edit();
            }

            AnimeRepository repo = new AnimeRepository();
            if (repo.GetByID(id) != null)
            {
                repo.DeleteByID(id);
                TempData["Message"] = "Successfully deleted the anime!";
            }
            else
            {
                TempData["ErrorMessage"] = "No such anime!";
            }
            return RedirectToAction("Edit");
        }


    }
}