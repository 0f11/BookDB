using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Domain
{
    public class Comment
    {
        public int  CommentId { get; set; }
        [MaxLength(512)]
        public string CommentText { get; set; } = default!;

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}