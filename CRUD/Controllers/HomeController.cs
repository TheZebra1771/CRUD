using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {              
        public ActionResult Index()
        {          
            List<Articles> articlelist = new List<Articles>();
            using (CMSEntities context = new CMSEntities())
            {
                foreach (Articles articles in context.Articles)
                {
                    var a = new Articles();
                    a.Title = articles.Title;
                    a.Contents = articles.Contents;
                    a.Category = articles.Category;
                    a.PostID = articles.PostID;
                    if (a.Category == "index")
                    {
                        articlelist.Add(a);
                    }
                    else
                    {
                        continue;
                    }
                }
                ViewBag.indexarticles = articlelist;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            List<Articles> articlelist = new List<Articles>();
            using (CMSEntities context = new CMSEntities())
            {
                foreach (Articles articles in context.Articles)
                {
                    var a = new Articles();
                    a.Title = articles.Title;
                    a.Contents = articles.Contents;
                    a.Category = articles.Category;
                    a.PostID = articles.PostID;
                    if (a.Category == "about")
                    {
                        articlelist.Add(a);
                    }
                    else
                    {
                        continue;
                    }
                }
                ViewBag.aboutarticles = articlelist;
                return View();
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            List<Articles> articlelist = new List<Articles>();
            using (CMSEntities context = new CMSEntities())
            {
                foreach (Articles articles in context.Articles)
                {
                    var a = new Articles();
                    a.Title = articles.Title;
                    a.Contents = articles.Contents;
                    a.Category = articles.Category;
                    a.PostID = articles.PostID;
                    if (a.Category == "contact")
                    {
                        articlelist.Add(a);
                    }
                    else
                    {
                        continue;
                    }
                }
                ViewBag.contactarticles = articlelist;
                return View();
            }
        }

        public ActionResult AddPost()
        {
            ViewBag.Message = "Add a new Post.";
            return View();
        }

        public ActionResult AllPosts()
        {
            List<Articles> articlelist = new List<Articles>();
            using (CMSEntities context = new CMSEntities())
            {
                foreach (Articles articles in context.Articles)
                {
                    var a = new Articles();
                    a.Title = articles.Title;
                    a.Contents = articles.Contents;
                    a.Category = articles.Category;
                    a.PostID = articles.PostID;
                    articlelist.Add(a);
                }
                ViewBag.articlelist = articlelist;
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoggedIn(FormCollection fomr)
        {
            //int loggedin;
            using (UserEntites context= new UserEntites())
            {
                List<users> authorizeduserlist = new List<users>();
                foreach(users user in context.users)
                {
                    if(fomr["username"]==user.username)
                    {
                        if (fomr["password"] == user.password)
                        {
                            if (user.authority.Equals(true))
                            {
                                Session["signedin"] = "1";
                                break;
                            }
                        }            
                    }
                }
            }       
                return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            Session["signedin"] = "0";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AllUsers()
        {
            List<users> userlist = new List<users>();
            using (UserEntites context = new UserEntites())
            {
                foreach (users user in context.users)
                {
                    var a = new users();
                    a.username = user.username;
                    a.password = user.password;
                    a.authority = user.authority;                 
                    userlist.Add(a);
                }
                ViewBag.userlist = userlist;
            }

            return View();
        }


    }
}


    