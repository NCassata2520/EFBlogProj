using System;
using EFTutorial.Models;
using System.Linq;
using System.Linq.Expressions;

namespace EFTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
           
             Console.WriteLine("1. Display Blogs");
             Console.WriteLine("2. Add Blogs");
             Console.WriteLine("3. Display Posts");
             Console.WriteLine("4. Add Post");
            var answer = Console.ReadLine();
            switch (answer) { 
            // 1. List Posts for Blog #1
            case "1":
            using (var db = new BlogContext()) 
            {
                var blog2 = db.Blogs.Where(x=>x.BlogId == 1).FirstOrDefault();
                 var blogsList = blog2; // convert to List from IQueryable

                System.Console.WriteLine($"Posts for Blog {blog2.Name}");

                foreach (var post in blog2.Posts) {
                    System.Console.WriteLine($"\tPost {post.PostId} {post.Title}");
                }
            }
            break;
            // 2. Add Blog to Database
            case "2":
             System.Console.WriteLine("Enter your Blog name");
             var blogName = Console.ReadLine();

            // // Create new Blog
             var blog = new Blog();
            blog.Name = blogName;
            
            // // Save blog object to database
             using (var db = new BlogContext()) 
            {
                db.Add(blog);
                db.SaveChanges();
            }
             break;
           
            // 3. Read Blogs from database
              case "3":
             using (var db = new BlogContext()) 
             {
               System.Console.WriteLine("Here is the list of blogs");
                foreach (var b in db.Blogs) {
                    System.Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
                }
            }

            break;
            // 4. Add Post to database
            case "4":
            Console.WriteLine("Select the blodid");
            var blogid = Console.ReadLine();

            System.Console.WriteLine("Enter your Post title");
            var postTitle = Console.ReadLine();

            var post2 = new Post();
            post2.Title = postTitle;
            post2.Content = postTitle;
            post2.BlogId = 1;

                    try
                    {
                        using (var db = new BlogContext())
                        {
                            db.Posts.Add(post2);
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.InnerException);
                    }
            break;
                default:
            break;
            }
        }
    }
}
