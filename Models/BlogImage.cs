using BisleriumBloggers.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisleriumBloggers.Models;

public class BlogImage : BaseEntity<int>
{
    public string ImageURL { get; set; }

    public int BlogId { get; set; }

    [ForeignKey("BlogId")]
    public virtual Blog Blog { get; set; }
}
