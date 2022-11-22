using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Repo
{
    public class CategoryRepo : IRepo<Category, int>
    {
        public void Add(Category obj)
        {
            var db = new Net_FT1Entities();
            db.Categories.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new Net_FT1Entities();
            var ext = (from b in db.Categories
                       where b.Id == id
                       select b).SingleOrDefault();

            var ext2 = (from a in db.News where a.CategoryId == id select a).ToList();
            foreach(var item in ext2)
            {
                db.News.Remove(item);
            }
            db.SaveChanges();
            db.Categories.Remove(ext);
            db.SaveChanges();
        }

        public List<Category> Get()
        {
            var db = new Net_FT1Entities();
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            var db = new Net_FT1Entities();
            var book = (from b in db.Categories
                        where b.Id == id
                        select b).SingleOrDefault();
            return book;
        }

        public void Update(Category obj)
        {
            var db = new Net_FT1Entities();
            var book = (from b in db.Categories
                        where b.Id == obj.Id
                        select b).SingleOrDefault();

            db.Entry(book).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
