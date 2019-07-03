using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult SubmitPost(FormCollection fomr)
        {
            using (CMSEntities context = new CMSEntities())
            {
                Articles article = new Articles();
                article.Title = fomr["title"];
                article.Contents = fomr["contents"];
                article.Category = fomr["page"];
                context.Articles.Add(article);
                context.SaveChanges();
            }
            return RedirectToAction("AllPosts", "Home");
        }

        public ActionResult EditArticle(int id)
        {
            Session["a"] = id;
            using (CMSEntities context = new CMSEntities())
            {
                ViewBag.Edited = context.Articles.Find(id);  
            }
            return View();
        }

        public ActionResult EditArticleP2(FormCollection fomr)
        {
            using (CMSEntities context = new CMSEntities())
            {
                var a = Session["a"];
                Articles art = context.Articles.Find(a);
                
                {
                    art.Title = fomr["title"];
                    art.Contents = fomr["contents"];
                }
                context.SaveChanges();
            }
            return RedirectToAction("AllPosts", "Home");
        }

        public ActionResult Delete(int id)
        {
            using (var context = new CMSEntities())
            {
                var std = context.Articles.Find(id);
                context.Articles.Remove(std);
                context.SaveChanges();
            }
            return RedirectToAction("AllPosts", "Home");
        }

        public ActionResult NewUser()
        {
            return View();
        }

        public ActionResult AddNewUser(FormCollection fomr)
        {
            using (UserEntites context = new UserEntites())
            {
                users user = new users();
                user.username = fomr["username"];
                user.password = fomr["password"];
                if(fomr["authorized"] == "authorized")
                {
                    user.authority = true;
                }                 
                context.users.Add(user);
                context.SaveChanges();
            }
            return RedirectToAction("AllUsers", "Home");
        }
    }
}