using BlogPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPro.Repository
{
    public interface IPostRepository
    {
        Post GetPost(int id);
        Post Find(int id);
        List<Post> AllPosts();
      
       void Add(Post p);
       void Edit(Post p);
        void Remove(Post p);
        IEnumerable<Post> Search(string term);

    }
}
