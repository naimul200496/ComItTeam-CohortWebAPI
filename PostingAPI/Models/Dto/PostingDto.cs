using System.ComponentModel.DataAnnotations;

namespace PostingAPI.Models.Dto
{
    public class PostingDto
    {
  
        public int PostingId { get; set; }
       
        public string UserId
        { get; set; }
   
        public string PostContent
        { get; set; }
       
        public DateTime PostingDate
        { get; set; }
        public int? DeletionFlag { get; set; }
        public ICollection<PostingDetails>? PostDetails { get; set; }

    }
}
