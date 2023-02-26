using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Noticeboard.Models
{
    public class NoticeBoard
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedUtc { get; set; }
        public IdentityUser Creater { get; set; } = new IdentityUser();

    }
}
