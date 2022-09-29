using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{

    public enum Status
    {
        BANNED = -1, DEACTIVE = 0, ACTIVE = 1
    }
    [Table("tblUser")]
    public class User : BaseEntity
    {

        public User()
        {
            Articles = new HashSet<Article>();
            Categories = new HashSet<Category>();
            Comments = new HashSet<Comment>();
        }
        public Guid IdentityId { get; set; }
        public String FirstName { get; set; } = default!;
        public String LastName { get; set; } = default!;
        public String Email { get; set; } = default!;
        public String Phone { get; set; } = default!;
        public DateTime DateOfBirth { get; set; } = default!;
        public String Country { get; set; } = default!;

        public String Address { get; set; } = default!;
        public String MobileNumber { get; set; } = default!;
        public String Sex { get; set; } = default!;
        public String DisplayName { get; set; }
        public Status Status { get; set; } = Status.DEACTIVE;


        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public List<ArticleLiker> ArticleLikers { get; set; }

    }
}