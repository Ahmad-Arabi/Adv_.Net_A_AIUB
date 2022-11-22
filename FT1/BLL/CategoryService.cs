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
    public class CategoryService
    {
        public static void Add(CategoryDTO cd)
        {
            var cr = new CategoryRepo();
            var c = new Category();
            c.Name = cd.Name;
            cr.Add(c);
        }
        public static List<CategoryDTO> Get()
        {
            var cat = new List<CategoryDTO>();
            var cr = new CategoryRepo();
            foreach (var item in cr.Get())
            {
                cat.Add(new CategoryDTO() { Id = item.Id, Name = item.Name });
            }
            return cat;
        }
        public static void Delete(int id)
        {
            var cr = new CategoryRepo();
            cr.Delete(id);
        }
        public static CategoryDTO Get(int id)
        {
            var cat = new CategoryDTO();

            var cr = new CategoryRepo();
            var ext = cr.Get(id);
            cat.Id = ext.Id;
            cat.Name = ext.Name;

            return cat;
        }
        public static void Update(CategoryDTO cd)
        {
            var cr = new CategoryRepo();
            var c = new Category();
            c.Id = cd.Id;
            c.Name = cd.Name;
            cr.Update(c);
        }
    }
}
