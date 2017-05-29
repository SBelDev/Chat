using System;

namespace UC_app.Models
{
    public class Comment
    {
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Gender { get; set; }
        public string Text { get; set; }
        public string AvatarBase64 { get; set; }
    }
}