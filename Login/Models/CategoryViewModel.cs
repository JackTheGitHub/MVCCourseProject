using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace ASPMVCProject.Models
{

    public class CategoriesViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CategoriesViewModel(int id, string name)
        {
            ID = id;
            Name = name;
        }

    }

    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<CategoriesViewModel> categoriesList;

        public CategoryViewModel()
        {
            categoriesList = new List<CategoriesViewModel>();
        }

        public CategoryViewModel( Category category)
        {
            ID = category.ID;
            Name = category.Name;
        }

        public CategoryViewModel(List<Category> categories)
            :this()
        {
            foreach (Category category in categories)
            {
                categoriesList.Add(new CategoriesViewModel(category.ID, category.Name));
            }
        }
    }
}