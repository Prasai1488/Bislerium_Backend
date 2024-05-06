using BisleriumBloggers.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisleriumBloggers.Models;

public class CommentLog : BaseEntity<int>
{
    public int CommentId { get; set; }

    public string Text { get; set; }

    [ForeignKey("CommentId")]
    public virtual Comment? Comment { get; set; }
}
