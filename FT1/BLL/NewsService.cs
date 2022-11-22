using BLL.DTO;
using DAL.EF;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsService
    {
        public static void Add(NewsDTO cd)
        {
            var cr = new NewsRepo();
            var c = new News();
            c.Title = cd.Title;
            c.CategoryId = cd.CategoryId;
            c.Date = cd.Date;
            cr.Add(c);
        }
        public static List<NewsDTO> Get()
        {
            var cat = new List<NewsDTO>();
            var cr = new NewsRepo();
            foreach (var item in cr.Get())
            {
                cat.Add(new NewsDTO() { Id = item.Id, Title = item.Title, CategoryId = item.CategoryId, Date = item.Date });
            }
            return cat;
        }
        public static void Delete(int id)
        {
            var cr = new NewsRepo();
            cr.Delete(id);
        }
        public static NewsDTO Get(int id)
        {
            var cat = new NewsDTO();

            var cr = new NewsRepo();
            var ext = cr.Get(id);
            cat.Id = ext.Id;
            cat.Title = ext.Title;
            cat.CategoryId = ext.CategoryId;
            cat.Date = ext.Date;

            return cat;
        }
        public static void Update(NewsDTO cd)
        {
            var cr = new NewsRepo();
            var c = new News();
            c.Id = cd.Id;
            c.Title = cd.Title;
            c.CategoryId = cd.CategoryId;
            c.Date = cd.Date;
            cr.Update(c);
        }
    }
}
