using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{
    [Table("tblTag")]
    public class Tag : BaseEntity
    {
        public String Name { get; set; }

        // public virtual ICollection<Article> Articles { get; set; }
        public List<ArticleTag> ArticleTags { get; set; }
    }
}