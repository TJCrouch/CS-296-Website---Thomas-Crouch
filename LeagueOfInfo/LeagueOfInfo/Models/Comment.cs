using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueOfInfo.Models
{
    public class Comment
    {
        [Key]
        [Required]
        public int CommentID { get; set; }

        [Required]
        [StringLength(20)]
        public string AuthorName { get; set; }

        [Required]
        public string CommentBody { get; set; }

        [Required]
        public int PostID { get; set; }

        public int ChampionID { get; set; }

        public virtual Champion Champions { get; set; }
    }
}
