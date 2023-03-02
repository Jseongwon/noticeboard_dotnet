using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Noticeboard.Models
{
    public class NoticeBoard
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }
        public IdentityUser? Creater { get; set; }

    }
}
