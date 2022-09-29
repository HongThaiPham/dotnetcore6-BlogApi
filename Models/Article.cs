using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{
    [Table("tblArticle")]
    public class Article : BaseEntity
    {
        public String Title { get; set; }
        public String Content { get; set; }


        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid AuthorId { get; set; }
        public User Author { get; set; }

        public int ViewCount { get; set; }


        // public virtual ICollection<Tag> Tags { get; set; }
        public List<ArticleTag> ArticleTags { get; set; }
        public List<ArticleLiker> ArticleLikers { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}