namespace FullStackReference.ReferenceRequests.Models
{
    public class ReferenceRequest
    {
        [Key]
        public int ReferenceRequestId { get; set; }

        [ForeignKey("NewBId")]
        public int NewBId { get; set; }

        [ForeignKey("PostContentId")]
        public int PostContentId { get; set; }

        public DateTime DateRequested { get; set; }
        public DateTime DateSubmitted { get; set; }

        //For navigation properties
        public User Newb { get; set; }
        public PostContent PostContent { get; set; }
    }
}
