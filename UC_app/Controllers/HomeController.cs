using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC_app.Models;
using UC_app.ModelsVM;

namespace UC_app.Controllers
{
    public class HomeController : Controller
    {
        private object _lockObj = new object();

        public ActionResult Index()
        {
            var model = new UserCommentVM();
            model.Comments = GetCommentsByName();

            return View("Index", model);
        }

        public ActionResult PostComment(string UserName, string Date, string Gender, string Text)
        {
            if (ModelState.IsValid)
            {
                AddComment(new Comment()
                {
                    UserName = UserName,
                    Date = DateTime.ParseExact(Date,"yyyy-MM-dd HH:mm", null),
                    Gender = Gender,
                    Text = Text
                });
            }

            var model = GetCommentsByName();

            return PartialView("Comments", model);
        }

        public ActionResult SearchComments(string SearchText)
        {
            var model = GetCommentsByName(SearchText);

            return PartialView("Comments", model);
        }

        private List<Comment> GetCommentsByName(string text = "")
        {
            List<Comment> comments = (List<Comment>)this.Session["Comments"];
            if (comments == null)
            {
                comments = new List<Comment>();
                this.Session["Comments"] = comments;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                comments = comments.Where(x => x.Text.Contains(text) || x.UserName.Contains(text)).ToList();
            }
            return comments.OrderByDescending(x => x.Date).ToList();
        }

        private void AddComment(Comment comment)
        {
            lock (_lockObj)
            {
                (this.Session["Comments"] as List<Comment>).Add(comment);
            }
        }
    }
}