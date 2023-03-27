namespace MessageBoard.Models
{
    public class User
    {
        public int UserId {get; set;}
        public string UserName {get; set;}
        public List<Post> ListOfPost {get; set;}
        

    }
}
