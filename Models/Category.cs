using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{
    [Table("tblCategory")]
    public class Category : BaseEntity
    {
        public String Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public Guid CreatedById { get; set; }
        public User CreadtedBy { get; set; }
    }
}