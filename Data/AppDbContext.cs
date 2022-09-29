
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(article =>
            {
                // article.HasKey(a => a.Id);
                article.HasOne<Category>(c => c.Category).WithMany(a => a.Articles).HasForeignKey(a => a.CategoryId);
                article.HasOne<User>(u => u.Author).WithMany(a => a.Articles).HasForeignKey(a => a.AuthorId).OnDelete(DeleteBehavior.Cascade);

                // article.HasMany<User>(u => u.Likers).WithMany(a => a.ArticlesLiked)
                // .UsingEntity<Dictionary<string, object>>("tblAticleLiker",
                // j => j.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
                // j => j.HasOne<Article>().WithMany().HasForeignKey("ArticleId").OnDelete(DeleteBehavior.Cascade));

                // article.HasMany<Tag>(t => t.Tags).WithMany(a => a.Articles)
                // .UsingEntity<Dictionary<string, object>>("tblAticleTag",
                // j => j.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.Cascade),
                // j => j.HasOne<Article>().WithMany().HasForeignKey("ArticleId").OnDelete(DeleteBehavior.Cascade));
            });
            modelBuilder.Entity<User>(user =>
            {
                user.HasMany<Category>(u => u.Categories).WithOne(c => c.CreadtedBy).HasForeignKey(c => c.CreatedById);
                user.HasMany<Article>(u => u.Articles).WithOne(c => c.Author).HasForeignKey(a => a.AuthorId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
            });



            modelBuilder.Entity<ArticleTag>(at =>
            {
                at.ToTable("tblArticleTag");
                at.HasKey(k => new { k.ArticleId, k.TagId });
                at.HasOne(at => at.Article).WithMany(t => t.ArticleTags).HasForeignKey(at => at.ArticleId);
                at.HasOne(at => at.Tag).WithMany(t => t.ArticleTags).HasForeignKey(at => at.TagId);
            });


            modelBuilder.Entity<ArticleLiker>(al =>
            {
                al.ToTable("tblArticleLiker");
                al.HasKey(k => new { k.ArticleId, k.LikerId });
                al.HasOne(a => a.Article).WithMany(j => j.ArticleLikers).HasForeignKey(u => u.ArticleId);
                al.HasOne(u => u.Liker).WithMany(j => j.ArticleLikers).HasForeignKey(a => a.LikerId);
            });

            var category = modelBuilder.Entity<Category>();
            var comment = modelBuilder.Entity<Comment>();
            var tag = modelBuilder.Entity<Tag>();






            category.HasMany<Article>(c => c.Articles).WithOne(a => a.Category).HasForeignKey(c => c.CategoryId);

            comment.HasOne<User>(c => c.Author).WithMany(u => u.Comments).HasForeignKey(c => c.AuthorId).IsRequired();
            comment.HasOne<Article>(c => c.Article).WithMany(c => c.Comments).HasForeignKey(c => c.ArticleId);

            // tag.HasMany<Article>(t => t.Articles).WithMany(a => a.Tags).UsingEntity(j => j.ToTable("tblArticleTag"));
        }
    }
}