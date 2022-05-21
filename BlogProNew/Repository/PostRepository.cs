using BlogPro.Data;
using BlogPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPro.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDBContext db;

        public PostRepository(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Post p)
        {
            db.Posts.Add(p);
            db.SaveChanges();
        }

        public List<Post> AllPosts()
        {
            return db.Posts.ToList();
        }
        public Post Find(int id)
        {
           return db.Posts.Find(id);
        }
        public void Edit(Post p)
        {
            db.Posts.Update(p);
            db.SaveChanges();

        }

   

        public Post GetPost(int id)
        {
            return db.Posts.FirstOrDefault(m => m.Id == id);
        }

        public void Remove(Post p)
        {
            db.Posts.Remove(p);
            db.SaveChanges();
        }

        public IEnumerable<Post> Search(string term)
        {
            return db.Posts.Where(m => m.Title.Contains(term));
        }

      
    }
}
