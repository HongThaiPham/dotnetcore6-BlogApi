using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Models
{
    public class ArticleLiker
    {
        public Guid? ArticleId { get; set; }
        public Article Article { get; set; }

        public Guid? LikerId { get; set; }
        public User Liker { get; set; }


        public DateTime LikedAt { get; set; } = DateTime.UtcNow;
    }
}