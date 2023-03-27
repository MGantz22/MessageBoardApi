namespace MessageBoard.Models
{
    public class Group
    {
        public int GroupId {get; set;}
        public string GroupName {get; set;}
        public List<Post> ListOfPost {get; set;}

    }
}
