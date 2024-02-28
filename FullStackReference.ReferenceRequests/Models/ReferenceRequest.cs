public class ReferenceRequest
{

    public int ReferenceRequestId {get; set;}
    public int NewBId {get; set;}
    public int PostContentId {get; set;}
    public DateTime DateRequested {get; set;}
    public DateTime DateSubmitted {get; set;}


    //For foreign keys
    public User Newb {get; set;}
    public PostContent PostContent {get; set;}

}