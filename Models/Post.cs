using System.ComponentModel.DataAnnotations;

namespace Voyager.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Display(Name = "Post Title")]
        public string PostName { get; set; }

        [Display(Name = "Post Description")]
        public string PostDescription { get; set; }
     
        public DateTime TimeStamp { get; set; }
        public Post()
        {
            TimeStamp = DateTime.Now;
        }


    }
}
