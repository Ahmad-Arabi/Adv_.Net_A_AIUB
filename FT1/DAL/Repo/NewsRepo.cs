using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class NewsRepo : IRepo<News, int>
    {
        public void Add(News obj)
        {
            var db = new Net_FT1Entities();
            db.News.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new Net_FT1Entities();
            var ext = (from b in db.News
                       where b.Id == id
                       select b).SingleOrDefault();
            db.News.Remove(ext);
            db.SaveChanges();
        }

        public List<News> Get()
        {
            var db = new Net_FT1Entities();
            return db.News.ToList();
        }

        public News Get(int id)
        {
            var db = new Net_FT1Entities();
            var book = (from b in db.News
                        where b.Id == id
                        select b).SingleOrDefault();
            return book;
        }

        public void Update(News obj)
        {
            var db = new Net_FT1Entities();
            var book = (from b in db.News
                        where b.Id == obj.Id
                        select b).SingleOrDefault();

            db.Entry(book).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
