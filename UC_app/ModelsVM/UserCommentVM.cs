using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using UC_app.Models;

namespace UC_app.ModelsVM
{
    public class UserCommentVM
    {
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Gender { get; set; }
        public string Text { get; set; }
        public string Search { get; set; }
        public List<Comment> Comments { get; set; }
    }
}