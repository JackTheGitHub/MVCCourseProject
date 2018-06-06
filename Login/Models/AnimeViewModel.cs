using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace ASPMVCProject.Models
{
    public class AnimesViewModel
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public AnimesViewModel(Anime anime)
        {
            ID = anime.ID;
            Name = anime.Name;
            Rating = anime.Rating;
            CategoryID = anime.Category;
            Category = anime.AnimeCategory;
        }

    }

    public class AnimeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<AnimesViewModel> animeList;

        public AnimeViewModel()
        {
            animeList = new List<AnimesViewModel>();
        }

        public AnimeViewModel(Anime anime)
        {
            ID = anime.ID;
            Name = anime.Name;
            Rating = anime.Rating;
            CategoryID = anime.Category;
            Category = anime.AnimeCategory;
        }

        public AnimeViewModel(List<Anime> animes)
            : this()
        {
            foreach (Anime anime in animes)
            {
                animeList.Add(new AnimesViewModel(anime));
            }
        }
    }

}